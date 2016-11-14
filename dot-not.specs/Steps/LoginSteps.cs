using System;
using TechTalk.SpecFlow;

namespace dot_not.specs.Steps
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"The user ""(.*)"" has an account")]
        public void GivenTheUserHasAnAccount(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"The user ""(.*)"" does not exists")]
        public void GivenTheUserDoesNotExists(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user registers an account as ""(.*)""")]
        public void WhenTheUserRegistersAnAccountAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user logs in")]
        public void WhenTheUserLogsIn()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he logs in with an incorrect password")]
        public void WhenHeLogsInWithAnIncorrectPassword()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the user should see ""(.*)""")]
        public void ThenTheUserShouldSee(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
