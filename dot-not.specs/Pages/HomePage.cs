using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace dot_not.specs.Pages
{
    class HomePage
    {
        private readonly IWebDriver driver;
        private readonly string url = "http://localhost/DotNot";

        public HomePage(IWebDriver webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "page-title")]
        public IWebElement PageTitle { get; set; }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

    }
}
