using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Watson.Sample.PageObjects
{
    public class BasePage
    {
        private readonly IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

      
    }
}