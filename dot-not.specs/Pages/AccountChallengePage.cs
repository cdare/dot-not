using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace dot_not.specs.Pages
{
    class AccountChallengePage
    {
        private readonly IWebDriver driver;
        
        public string url { get; set; }

        public AccountChallengePage(IWebDriver webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "flag-status")]
        public IWebElement FlagStatus { get; set; }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

    }
}
