using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace dot_not.specs.Pages
{
    class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly string url = "http://localhost/DotNot/Account/Login";

        public LoginPage(IWebDriver webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "page-title")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "LogIn")]
        public IWebElement LogIn { get; set; }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

    }
}
