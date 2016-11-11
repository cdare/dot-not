using System;
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
        
        [Then(@"I will get (.*) pointa")]
        public void ThenIWillGetPointa(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
