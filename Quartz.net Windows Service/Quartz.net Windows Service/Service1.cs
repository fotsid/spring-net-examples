using log4net;
using Quartz;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace MyService
{
    public partial class Service1 : ServiceBase
    {
        private IApplicationContext ctx = ContextRegistry.GetContext();
        private IScheduler _scheduler;
        private static readonly ILog logger = LogManager.GetLogger(typeof(Service1));
        
        public Service1()
        {
            InitializeComponent();
            CanPauseAndContinue = true;
            _scheduler = ctx.GetObject<IScheduler>("ScheduleObject");
        }

        protected override void OnStart(string[] args)
        {
            start();
        }

        protected override void OnStop()
        {
            pause();
        }

        protected override void  OnContinue()
        {
 	        base.OnContinue();
            start();
        }

        protected override void OnPause()
        {
            base.OnPause();
            pause();
        }

        private void pause()
        {
            logger.Debug("PAUSING SERVICE");
            try
            {
                _scheduler.PauseAll();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            logger.Debug("SERVICE PAUSED");
        }

        private void start()
        {
            logger.Debug("STARTING SERVICE");
            try
            {
                if (_scheduler.GetCurrentlyExecutingJobs().Count==0)
                    _scheduler.ResumeAll();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            logger.Debug("SERVICE STARTED");
        }
    }
}
