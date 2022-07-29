using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Watson.Sample.PageObjects;

namespace Watson.Sample.Test
{
    [TestClass]
    public class SamplePayTestChrome : TestBase
    {
        private string _appUrl;
    
       // public TestContext TestContext { get; set; }


        [TestMethod]
        public void PayCalTest1()
        {            
            Console.WriteLine("Test 1");
           var _appUrl = TestContext.Properties["webAppUrl"];
           Console.WriteLine((string)_appUrl);

            HomePage hpage = new HomePage(driver,(string)_appUrl);
            hpage.PerformFunctionality();
        }

        [TestMethod, TestCategory("Smoke")]
             public void CalPayTest2()
        {

            Console.WriteLine("Test 2");
            var _appUrl = TestContext.Properties["webAppUrl1"];
            Console.WriteLine((string)_appUrl);

            HomePage hpage = new HomePage(driver, (string)_appUrl);
            hpage.PerformFunctionality1();
        }

        [TestMethod]
        public void SeekPayTest3()
        {

            Console.WriteLine("Test 2");
            var _appUrl = TestContext.Properties["webAppUrl2"];
            Console.WriteLine((string)_appUrl);

            HomePage hpage = new HomePage(driver, (string)_appUrl);
            hpage.PerformFunctionality2();
        }
       
    }
}