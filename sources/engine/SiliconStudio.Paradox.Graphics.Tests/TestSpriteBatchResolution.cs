﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System.Threading.Tasks;

using NUnit.Framework;

using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Games;
using SiliconStudio.Paradox.Input;

namespace SiliconStudio.Paradox.Graphics.Tests
{
    [TestFixture]
    public class TestSpriteBatchResolution : TestGameBase
    {
        private SpriteFont staticFont;
        private SpriteFont dynamicFont;
        private SpriteBatch spriteBatch;

        private Texture2D round;
        private Texture2D colorTexture;
        private SpriteGroup spheres;

        public TestSpriteBatchResolution()
        {
            CurrentVersion = 2;
        }

        protected override void RegisterTests()
        {
            base.RegisterTests();

            FrameGameSystem.Draw(()=>SetVirtualResolutionAndDraw(new Vector2(1, 1))).TakeScreenshot();
            FrameGameSystem.Draw(()=>SetVirtualResolutionAndDraw(new Vector2(1.5f, 1.5f))).TakeScreenshot();
            FrameGameSystem.Draw(()=>SetVirtualResolutionAndDraw(new Vector2(0.5f, 0.5f))).TakeScreenshot();
            FrameGameSystem.Draw(()=>SetVirtualResolutionAndDraw(new Vector2(1.75f, 1.25f))).TakeScreenshot();
        }

        protected override async Task LoadContent()
        {
            await base.LoadContent();

            spriteBatch = new SpriteBatch(GraphicsDevice);
            spheres = Asset.Load<SpriteGroup>("SpriteSphere");
            round = Asset.Load<Texture2D>("round");
            staticFont = Asset.Load<SpriteFont>("StaticFonts/CourierNew10");
            dynamicFont = Asset.Load<SpriteFont>("DynamicFonts/CourierNew10");
            colorTexture = Texture2D.New(GraphicsDevice, 1, 1, PixelFormat.R8G8B8A8_UNorm, new[] { Color.White });
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            if (!ScreenShotAutomationEnabled)
                DrawSprites();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Input.IsKeyReleased(Keys.Left))
                spriteBatch.VirtualResolution = 3 / 4f * spriteBatch.VirtualResolution;
            if (Input.IsKeyReleased(Keys.Right))
                spriteBatch.VirtualResolution = 4 / 3f * spriteBatch.VirtualResolution;
        }

        private void SetVirtualResolutionAndDraw(Vector2 factor)
        {
            spriteBatch.VirtualResolution = new Vector3(factor.X * GraphicsDevice.BackBuffer.Width, factor.Y*GraphicsDevice.BackBuffer.Height, 100);

            DrawSprites();
        }

        private void DrawSprites()
        {
            GraphicsDevice.Clear(GraphicsDevice.BackBuffer, Color.Black);
            GraphicsDevice.Clear(GraphicsDevice.DepthStencilBuffer, DepthStencilClearOptions.DepthBuffer);
            GraphicsDevice.SetRenderTarget(GraphicsDevice.DepthStencilBuffer, GraphicsDevice.BackBuffer);

            spriteBatch.Begin();
            
            var x = 20f;
            var y = 20f;

            PerformStringDraws(ref x, ref y, false);
            PerformStringDraws(ref x, ref y, true);

            y += 10;

            spriteBatch.Draw(round, new Vector2(x, y), Color.Red);

            x += round.Width + 5;

            var sphere = spheres[0];
            spriteBatch.Draw(sphere.Texture, new Vector2(x, y), sphere.Region, Color.White);

            x += spheres[0].Region.Width + 5;

            spriteBatch.Draw(round, new RectangleF(x, y, round.Width / 2f, round.Height / 2f), Color.GreenYellow);
            
            spriteBatch.End();
        }

        private void PerformStringDraws(ref float x, ref float y, bool useDynamicFont)
        {
            var fontName = useDynamicFont ? "Dynamic" : "Static";
            var spriteFont = useDynamicFont ? dynamicFont : staticFont;
            var resolutionRatio = Vector2.One;
            if (useDynamicFont)
            {
                resolutionRatio.X = GraphicsDevice.BackBuffer.Width / spriteBatch.VirtualResolution.X;
                resolutionRatio.Y = GraphicsDevice.BackBuffer.Height / spriteBatch.VirtualResolution.Y;
            }

            var text = fontName + " font drawn with SpriteBatch(text).";
            var dim = spriteBatch.MeasureString(spriteFont, text);

            spriteBatch.Draw(colorTexture, new RectangleF(x, y, dim.X, dim.Y), Color.Green);

            spriteFont.PreGenerateGlyphs(text, spriteFont.Size * resolutionRatio);
            spriteBatch.DrawString(spriteFont, text, new Vector2(x, y), Color.White);

            y += 1.4f * dim.Y;

            var fontSize = 1.5f * spriteFont.Size;
            text = fontName + " font drawn with SpriteBatch(text, size).";
            dim = spriteBatch.MeasureString(spriteFont, text, fontSize);

            spriteBatch.Draw(colorTexture, new RectangleF(x, y, dim.X, dim.Y), Color.Green);

            spriteFont.PreGenerateGlyphs(text, fontSize * resolutionRatio);
            spriteBatch.DrawString(spriteFont, text, fontSize, new Vector2(x, y), Color.White);

            y += 1.4f * dim.Y;
        }

        public static void Main()
        {
            using (var game = new TestSpriteBatchResolution())
                game.Run();
        }

        /// <summary>
        /// Run the test
        /// </summary>
        [Test]
        public void RunTestSpriteBatchResolution()
        {
            RunGameTest(new TestSpriteBatchResolution());
        }
    }
}