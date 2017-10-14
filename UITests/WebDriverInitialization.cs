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
    public class WebDriverInitialization
    {
        //private static bool ReuseWebSession
        //{
        //    get { return ConfigurationManager.AppSettings["ReuseWebSession"] == "true"; }
        //}

        [BeforeScenario()]
        public static void BeforeWebScenario()
        {
            WebDriverController.Instance.Start();
        }

        [AfterScenario()]
        public static void AfterWebScenario()
        {
            //if (!ReuseWebSession)
                WebDriverController.Instance.Stop();
        }
    }
}
