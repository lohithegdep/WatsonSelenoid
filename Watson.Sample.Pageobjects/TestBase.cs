using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using WebDriverManager.DriverConfigs.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace Watson.Sample.Test
{
    public class TestBase
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
            Dictionary<string, object> selenoidOptions = new Dictionary<string, object>();
            selenoidOptions.Add("enableVNC", true);
            selenoidOptions.Add("testName", true);



            string Btype = "";
            Btype = (string)TestContext.Properties["BrowserType"];
            string[] BtypeList = { "chrome", "firefox", "edge" };
            Random rnd = new Random();
            if (Btype.Equals("Any"))
            {
                Btype = BtypeList[rnd.Next(3)];
            }


            switch (Btype.ToLower())
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddAdditionalOption("selenoid:options", selenoidOptions);
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());
                    break;

                case "firefox":
                    FirefoxOptions option1 = new FirefoxOptions();
                    option1.AddAdditionalOption("selenoid:options", selenoidOptions);
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), option1.ToCapabilities());
                    break;

                case "edge":
                    var option2 = new EdgeOptions();
                    option2.AddAdditionalOption("selenoid:options", selenoidOptions);
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), option2.ToCapabilities());
                    break;

                default:
                    ChromeOptions option3 = new ChromeOptions();
                    option3.AddAdditionalOption("selenoid:options", selenoidOptions);
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), option3.ToCapabilities());
                    break;
            }

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
