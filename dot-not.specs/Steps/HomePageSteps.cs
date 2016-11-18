using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using dot_not.specs.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace dot_not.specs.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }
        private HomePage homePage;

        [BeforeScenario()]
        public void Setup()
        {
            this.Driver = new FirefoxDriver();
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));
        }

        [AfterScenario()]
        public void TearDown()
        {
            this.Driver.Quit();
        }

        [When(@"I browse to the home page")]
        public void WhenIBrowseToTheHomePage()
        {
            HomePage homePage = new HomePage(this.Driver);
            homePage.Navigate();
        }
        
        [Then(@"I should see ""(.*)"" on the screen")]
        public void ThenIShouldSeeOnTheScreen(string searchStr)
        {
            Assert.IsTrue(this.Driver.PageSource.Contains(searchStr));
        }


    }
}
