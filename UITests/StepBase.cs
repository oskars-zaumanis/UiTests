using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UITests
{
    [Binding]
    public class StepBase
    {
        protected IWebDriver Driver
        {
            get
            {
                return WebDriverController.Instance.Driver;
            }
        }

        private static bool ReuseWebSession
        {
            get { return ConfigurationManager.AppSettings["ReuseWebSession"] == "true"; }
        }

        [BeforeScenario("web")]
        public void BeforeWebScenario()
        {
            WebDriverController.Instance.Start();
        }

        [AfterScenario("web")]
        public void AfterWebScenario()
        {
            if (!ReuseWebSession)
                WebDriverController.Instance.Stop();
        }
    }
}
