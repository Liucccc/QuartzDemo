using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quartz;
using Quartz.Impl;

namespace Web
{
    public partial class Index : System.Web.UI.Page
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Min15_Click(object sender, EventArgs e)
        {
            _log.Info("点击方法开始");
            i++;
            Buid_Job(i, "a", DateTime.Now.AddSeconds(5), c.TimeJob);
            _log.Info("点击方法结束");

        }


        protected void Buid_Job(int MemberID, string Group, DateTime dt)
        {
            //调度器
            IScheduler scheduler;
            //调度器工厂
            ISchedulerFactory factory;

            //创建一个调度器
            factory = new StdSchedulerFactory();
            scheduler = factory.GetScheduler();
            scheduler.Start();

            //2、创建一个任务
            IJobDetail job = JobBuilder.Create<TimeJob>().WithIdentity(MemberID.ToString(), Group).Build();

            //3、创建一个触发器
            //DateTimeOffset runTime = DateBuilder.EvenMinuteDate(DateTimeOffset.UtcNow);
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                //.WithCronSchedule("0/5 * * * * ?")     //5秒执行一次
                .StartAt(dt)//5秒后执行
                .Build();

            //4、将任务与触发器添加到调度器中
            scheduler.ScheduleJob(job, trigger);
            //5、开始执行
            scheduler.Start();
        }
    }
    public class TimeJob : IJob
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        public void Execute(IJobExecutionContext context)
        {
            _log.Info("任务执行时间：" + DateTime.Now);
        }
    }
}