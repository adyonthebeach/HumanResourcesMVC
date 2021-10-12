using System;
using TechTalk.SpecFlow;

namespace HumanResources.Services.Tests.Steps
{
    [Binding]
    public class GetHumanResourcesSteps
    {
        [Given(@"I can get a list of all Human Resources")]
        public void GivenICanGetAListOfAllHumanResources()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I request all the human resources")]
        public void WhenIRequestAllTheHumanResources()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a list of human resources will be returned")]
        public void ThenAListOfHumanResourcesWillBeReturned()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
