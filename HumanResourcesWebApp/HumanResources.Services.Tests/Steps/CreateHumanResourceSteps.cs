using System;
using TechTalk.SpecFlow;

namespace HumanResources.Services.Tests.Steps
{
    [Binding]
    public class CreateHumanResourceSteps
    {
        [Given(@"I am a Human Resources Manager")]
        public void GivenIAmAHumanResourcesManager()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I create a new human resourec with valid data")]
        public void WhenICreateANewHumanResourecWithValidData()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a new record will be added to the database")]
        public void ThenANewRecordWillBeAddedToTheDatabase()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
