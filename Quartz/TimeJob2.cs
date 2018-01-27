using NLog;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hi.Quartz
{
    public class TimeJob2 : IJob
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        public void Execute(IJobExecutionContext context)
        {
            _log.Info(context.JobDetail.ToString());
        }
    }
}
