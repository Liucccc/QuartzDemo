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
            try
            {
                string ID = context.JobDetail.JobDataMap.GetString("ID");
                _log.Info("TimeJob2任务执行时间：" + ID + ":" + DateTime.Now);
            }
            catch (Exception ex)
            {
                _log.Info("TimeJob2任务执行错误：" + ex.Message);
            }

        }
    }
}
