using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace dot_not.specs.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private IWebDriver driver;

        [BeforeScenario()]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }

        [AfterScenario()]
        public void TearDown()
        {
            driver.Quit();
        }

        [When(@"I browse to the home page")]
        public void WhenIBrowseToTheHomePage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see ""(.*)"" on the screen")]
        public void ThenIShouldSeeOnTheScreen(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
