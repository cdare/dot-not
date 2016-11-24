using System;
using System.Drawing;
using System.IO;
using System.Net;
using dot_not;
using dot_not.specs.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace dot_not.specs.Steps
{
    [Binding]
    public class ChallengeSteps
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }
        private ChallengePage challengePage;
        private string responseText;
        private HttpWebRequest request;

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

        [Given(@"the Challenge ID is (.*)")]
        public void GivenTheChallengeIdIs(string id)
        {
            request = (HttpWebRequest)WebRequest.Create("http://localhost/DotNot/Challenges/Challenge" + id);
        }

        [Given(@"the (.*) header is (.*)")]
        public void GivenTheHeaderIs(string name, string value)
        {
            if (name == "User-Agent")
            {
                request.UserAgent = value;
            }
            else
            {
                request.Headers.Add(name, value);
            }
        }

        [When(@"I browse to Challenge (.*)")]
        public void WhenIBrowseToChallenge(string id)
        {
            ChallengePage challengePage = new ChallengePage(this.Driver);
            challengePage.url = "http://localhost/DotNot/Challenges/Challenge"+id;
            challengePage.Navigate();
        }

        [When(@"I send an HTTP request to Challenge (.*)")]
        public void WhenIHttpToChallenge(string id)
        {
            if (request == null)
            {
                request = (HttpWebRequest)WebRequest.Create("http://localhost/DotNot/Challenges/Challenge" + id);
            }
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            responseText = reader.ReadToEnd();
        }

        [Then(@"I should see ""(.*)"" in the response")]
        public void ThenIShouldSeeInTheResponse(string p0)
        {
            Assert.True(responseText.Contains(p0));
        }


    }
}
