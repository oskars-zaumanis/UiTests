using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests
{
    public class WebDriverController
    {
        public static readonly WebDriverController Instance = new WebDriverController();
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);

        public IWebDriver Driver { get; private set; }

        private void Trace(string message) { Console.WriteLine("-> {0}", message); }

        public void Start()
        {
            if (Driver != null)
                return;

            string appUrl = ConfigurationManager.AppSettings["AppUrl"];

            var options = new ChromeOptions();
            options.AddArgument("test-type");
            Driver = new ChromeDriver(options);
            //Selenium.Manage().Timeouts().ImplicitlyWait(DefaultTimeout);

            Trace("Selenium started");
        }

        public void Stop()
        {
            if (Driver == null) return;

            try
            {
                Driver.Quit();
                Driver.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Selenium stop error");
            }
            Driver = null;
            Trace("Selenium stopped");
        }
    }
}
