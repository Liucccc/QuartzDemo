using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hi.Quartz
{

    public class QuartzHelper
    {
        /// <summary>
        /// 时间间隔执行任务
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="seconds">时间间隔(单位：毫秒)</param>
        public static void ExecuteInterval<T>(int seconds) where T : IJob
        {
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler();

            //IJobDetail job = JobBuilder.Create<T>().WithIdentity("job1", "group1").Build();
            IJobDetail job = JobBuilder.Create<T>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                                            .StartNow()
                                            .WithSimpleSchedule(x => x.WithIntervalInSeconds(seconds).RepeatForever())
                                            .Build();

            scheduler.ScheduleJob(job, trigger);

            scheduler.Start();
        }

        /// <summary>
        /// 指定时间执行任务
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="cronExpression">cron表达式，即指定时间点的表达式</param>
        public static void ExecuteByCron<T>(string cronExpression) where T : IJob
        {
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler();

            IJobDetail job = JobBuilder.Create<T>().Build();

            //DateTimeOffset startTime = DateBuilder.NextGivenSecondDate(DateTime.Now.AddSeconds(1), 2);
            //DateTimeOffset endTime = DateBuilder.NextGivenSecondDate(DateTime.Now.AddYears(2), 3);

            ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                                    //.StartAt(startTime).EndAt(endTime)
                                    .WithCronSchedule(cronExpression)
                                    .Build();

            scheduler.ScheduleJob(job, trigger);

            scheduler.Start();

            //Thread.Sleep(TimeSpan.FromDays(2));
            //scheduler.Shutdown();
        }

        /// <summary>
        /// 自己写的指定时间执行任务
        /// </summary>
        /// <typeparam name="T">任务类，必须实现IJob接口</typeparam>
        /// <param name="MemberID">会员ID</param>
        /// <param name="Group">分组名称</param>
        /// <param name="dt">执行时间</param>
        public static void Buid_Job<T>(int MemberID, string Group, DateTime dt) where T : IJob
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
            IJobDetail job = JobBuilder.Create<T>()
                //.WithIdentity("job_" + MemberID.ToString(), "job_" + Group)
                .Build();

            //3、创建一个触发器
            //DateTimeOffset runTime = DateBuilder.EvenMinuteDate(DateTimeOffset.UtcNow);
            ITrigger trigger = TriggerBuilder.Create()
                //.WithIdentity("trigger_" + MemberID.ToString(), "trigger_" + Group)
                //.WithCronSchedule("0/5 * * * * ?")     //5秒执行一次
                .StartAt(dt)//指定时间执行
                .EndAt(dt.AddMinutes(1))//指定开始时间后一分钟结束
                .Build();

            // 设置初始参数
            job.JobDataMap.Add("ID", MemberID.ToString());

            //4、将任务与触发器添加到调度器中
            scheduler.ScheduleJob(job, trigger);
            //5、开始执行
            scheduler.Start();
        }
    }
}
