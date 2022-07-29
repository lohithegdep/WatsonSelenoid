using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using WebDriverManager.DriverConfigs.Impl;

namespace Watson.Sample.Test
{
    public class TestBase2
    {
        public IWebDriver driver;
        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void AssemblyInitialize()
        {
            Console.WriteLine("AssemblyInitialize");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Console.WriteLine("AssemblyCleanup");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Console.WriteLine("TestInitialize");
            var options = new EdgeOptions();
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            Dictionary<string, object> selenoidOptions = new Dictionary<string, object>();
            selenoidOptions.Add("enableVNC", true);

            options.AddAdditionalOption("selenoid:options", selenoidOptions);

            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());

            // driver = new RemoteWebDriver(new Uri("http://localhost:4444"), options);
            //driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }



        // 4. Called once after each test before the Dispose method
        [TestCleanup]
        public void TestCleanup()
        {
            Console.WriteLine("TestCleanup");
            driver.Quit();
        }

        // 5. Called once after each test
        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }

    }
}
