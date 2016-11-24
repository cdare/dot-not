using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using dot_not.specs.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI; 

namespace dot_not.specs.Steps
{
    [Binding]
    public class BaseSteps : TechTalk.SpecFlow.Steps
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }

        [Then(@"I should see ""(.*)"" on the screen")]
        public void ThenIShouldSeeOnTheScreen(string searchStr)
        {
            Assert.IsTrue(this.Driver.PageSource.Contains(searchStr));
        }


    }
}
