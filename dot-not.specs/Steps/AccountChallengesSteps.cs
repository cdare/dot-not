using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Security.Cryptography;
using System.Text;
using dot_not.specs.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Utilities.Encoders;
using TechTalk.SpecFlow;
using TechTalk.SpecRun.Helper;

namespace dot_not.specs.Steps
{
    [Binding]
    public class AccountChallengesSteps {

        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }
        private AccountChallengePage accountChallengePage;
        private string baseUrl = "http://localhost/DotNot/AccountChallenge";
        private string adminId = "1";
        private string hashCookie = "";

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

        [Given(@"the admin ID is (.*)")]
        public void GivenTheAdminIdIs(string adminid)
        {
            this.adminId = adminid;
        }
        
        [Given(@"the user cookie is a md5 hash of (.*)")]
        public void GivenTheUserCookieIsAMdHashOf(string toHash)
        {
            //new HexEncoder().Encode()
            //new MD5Digest().Update(Encoding.UTF8.GetBytes(toHash));
            //this.hashCookie = Convert.MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(toHash));
        }
        
        [When(@"I browse to /account/(.*)")]
        public void WhenIBrowseToAccount(string urlId)
        {
            accountChallengePage = new AccountChallengePage(this.Driver);
            accountChallengePage.url = baseUrl + urlId;
            accountChallengePage.Navigate();
            //is this the right place to add a cookie, after navigate?
            if (!this.hashCookie.IsNullOrWhiteSpace())
            {
                this.Driver.Manage().Cookies.AddCookie(new Cookie("userid", this.hashCookie));
            }

        }
        
        [Then(@"I the flag comment will be (.*)")]
        public void ThenITheFlagCommentWillBeSuccess(string comment)
        {
            Assert.IsTrue(accountChallengePage.FlagStatus.Text == comment);
        }
    }
}
