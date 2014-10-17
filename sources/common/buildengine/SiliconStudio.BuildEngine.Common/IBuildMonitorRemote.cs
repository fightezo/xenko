﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace SiliconStudio.BuildEngine
{
    public class MicrothreadNotification
    {
        public enum NotificationType
        {
            JobStarted,
            JobEnded,
        };

        public int ThreadId;
        public long MicrothreadId;
        public long MicrothreadJobInfoId;
        public long Time;
        public NotificationType Type;

        public MicrothreadNotification() { }

        internal MicrothreadNotification(int threadId, long microthreadId, long microthreadJobId, long time, NotificationType type)
        {
            ThreadId = threadId;
            MicrothreadId = microthreadId;
            MicrothreadJobInfoId = microthreadJobId;
            Time = time;
            Type = type;
        }
    }

    [ServiceContract]
    public interface IBuildMonitorRemote
    {
        [OperationContract]
        int Ping();

        [OperationContract(IsOneWay = true)]
        void StartBuild(Guid buildId, DateTime time);

        [OperationContract(IsOneWay = true)]
        [UseParadoxDataContractSerializer]
        void SendBuildStepInfo(Guid buildId, long executionId, string description, DateTime startTime);

        [OperationContract(IsOneWay = true)]
        [UseParadoxDataContractSerializer]
        void SendCommandLog(Guid buildId, DateTime startTime, long microthreadId, List<SerializableTimestampLogMessage> messages);

        [OperationContract(IsOneWay = true)]
        void SendMicrothreadEvents(Guid buildId, DateTime startTime, DateTime now, IEnumerable<MicrothreadNotification> microthreadJobInfo);

        [OperationContract(IsOneWay = true)]
        void SendBuildStepResult(Guid buildId, DateTime startTime, long microthreadId, ResultStatus status);

        [OperationContract(IsOneWay = true)]
        void EndBuild(Guid buildId, DateTime time);
    }
}