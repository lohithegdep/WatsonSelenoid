using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Watson.Sample.PageObjects
{
    public class HomePage 
    {

        private IWebDriver driver{ get; set; }
        public HomePage(IWebDriver driver,string _appUrl)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl(_appUrl);
        }


        private IWebElement PayCycleDrpDown => driver.FindElement(By.Id("payCycle"));
        private IWebElement PayCycleDrpDown1 => driver.FindElement(By.Id("duration"));
        private IWebElement YourPayTxt => driver.FindElement(By.Name("Your pay"));
        private IWebElement SalTxt => driver.FindElement(By.Id("salary"));


        public void PerformFunctionality()
        {
            SalTxt.SendKeys(Keys.PageDown);
            Actions action = new Actions(driver);
            action.MoveToElement(PayCycleDrpDown).Perform();
            PayCycleDrpDown.Click();
            var selectElement = new SelectElement(PayCycleDrpDown);
            selectElement.SelectByValue("2");
            Thread.Sleep(2000);
        }

        public void PerformFunctionality1()
        {
            PayCycleDrpDown1.Click();
            var selectElement = new SelectElement(PayCycleDrpDown1);
            selectElement.SelectByValue("fortnightly");
            Thread.Sleep(2000);
        }

        public void PerformFunctionality2()
        {
            YourPayTxt.Clear();
            YourPayTxt.SendKeys("90000");
            Thread.Sleep(2000);
        }
    }

}
