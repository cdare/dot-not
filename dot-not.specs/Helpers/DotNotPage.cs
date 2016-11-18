using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;

namespace dot_not.specs.Helpers
{
    class DotNotPage
    {
        private static IWebDriver driver;
        public static string Url = "http://localhost/";

        static DotNotPage NavigateTo(IWebDriver webDriver)
        {
            driver = webDriver;
            return DotNotPage.DoNavigate(webDriver, DotNotPage.Url);

        }

        static DotNotPage DoNavigate(IWebDriver webDriver, string url)
        {
            driver.Navigate().GoToUrl(url);
            var dotNotPage = new DotNotPage();
            PageFactory.InitElements(driver, dotNotPage);
            return dotNotPage;
        }
    }
}

