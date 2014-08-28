using log4net;
using LogManager = log4net.LogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    public class MyJob : IGenericService
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(IGenericService));

        public void doJob()
        {
            logger.Info("Job 1 Executed !!!!");
        }

    }
}
