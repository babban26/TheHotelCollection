using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Framework.Utils
{
    class Logger
    {
        public static log4net.ILog log { get; set; }

        public static void SetLogger()
        {
            log = log4net.LogManager.GetLogger(NUnit.Framework.TestContext.CurrentContext.Test.FullName);
        }
    }
}
