using System;
using TechTalk.SpecFlow;

namespace HumanResources.Services.Tests.Steps
{
    [Binding]
    public class UpdateHumanResourceSteps
    {
        [Given(@"Given I am a Human resources manager")]
        public void GivenGivenIAmAHumanResourcesManager()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I update an existing human resource with valid data")]
        public void WhenIUpdateAnExistingHumanResourceWithValidData()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the database record will be updated")]
        public void ThenTheDatabaseRecordWillBeUpdated()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
