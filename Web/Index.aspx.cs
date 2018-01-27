using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quartz;
using Quartz.Impl;
using Hi.Quartz;

namespace Web
{
    public partial class Index : System.Web.UI.Page
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        public int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Second5_Click(object sender, EventArgs e)
        {
            _log.Info("5秒后写一条日志：点击方法开始");
            i++;
            QuartzHelper.Buid_Job<TimeJob>(i, "a", DateTime.Now.AddSeconds(5));
            _log.Info("5秒后写一条日志：点击方法结束");
        }

        protected void time_Click(object sender, EventArgs e)
        {
            _log.Info("今天17:15写一条日志：点击方法开始");
            i++;
            QuartzHelper.Buid_Job<TimeJob2>(i, "a", Convert.ToDateTime("2018-01-27 20:53:00"));
            _log.Info("今天17:15写一条日志：点击方法结束");

        }
    }
}