using System;
using dot_not;
using TechTalk.SpecFlow;

namespace dot_not.specs
{
    [Binding]
    public class ChallengeSteps
    {
        [Given(@"I have entered (.*) in the text box")]
        public void GivenIHaveEnteredInTheTextBox(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press sumbit")]
        public void WhenIPressSumbit()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result will be (.*)")]
        public void ThenTheResultWillBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I will get (.*) points")]
        public void ThenIWillGetPointa(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I view the challenge with ID (.*)")]
        public void WhenIViewTheChallengeWithID(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will see the text ""(.*)"" on the page")]
        public void ThenIWillSeeTheTextOnThePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
