using Core;
using log4net;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests
{
    public class BaseTest
    {
        protected static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [OneTimeSetUp]
        public void BaseSetUp()
        {
            LogHelper.InitializeLogger();
        }
    }
}
