﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Amazon;

using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

using Pollster.CommonCode;

namespace Pollster.PollWorkflow
{
    public class EndTimerExpiredActivity : AbstractActivityWorker
    {
        protected override string ActivityType
        {
            get { return Constants.SWF_ACTIVTY_END_TIMER_EXPIRED; }
        }
        protected override string ActivityTaskList
        {
            get { return Constants.SWF_ACTIVTY_END_TIMER_EXPIRED_TASKLIST; }
        }

        protected async override Task ProcessTaskAsync(ActivityTask task)
        {
            var pollId = task.Input;
            await PollProcessor.Instance.DeactivatePoll(pollId);
            Logger.LogMessage("Poll {0} expired", pollId);
        }
    }
}
