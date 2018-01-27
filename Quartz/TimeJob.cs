using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz
{
    public class TimeJob : IJob
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        public void Execute(IJobExecutionContext context)
        {
            _log.Info("任务执行时间：" + DateTime.Now);
        }
    }
}
