using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Watson.Sample.PageObjects;

namespace Watson.Sample.Test
{
    [TestClass]
    public class SamplePayTestFirefox : TestBase
    {
        private string _appUrl;
    
       // public TestContext TestContext { get; set; }


        

        [TestMethod]
        public void PayCalTest4()
        {

            Console.WriteLine("Test 1");
            var _appUrl = TestContext.Properties["webAppUrl"];
            Console.WriteLine((string)_appUrl);

            HomePage hpage = new HomePage(driver, (string)_appUrl);
            hpage.PerformFunctionality();
        }

        [TestMethod]
        public void CalPayTest5()
        {

            Console.WriteLine("Test 2");
            var _appUrl = TestContext.Properties["webAppUrl1"];
            Console.WriteLine((string)_appUrl);

            HomePage hpage = new HomePage(driver, (string)_appUrl);
            hpage.PerformFunctionality1();
        }

        [TestMethod]
        public void SeekPayTest6()
        {

            Console.WriteLine("Test 2");
            var _appUrl = TestContext.Properties["webAppUrl2"];
            Console.WriteLine((string)_appUrl);

            HomePage hpage = new HomePage(driver, (string)_appUrl);
            hpage.PerformFunctionality2();
        }
    }
}