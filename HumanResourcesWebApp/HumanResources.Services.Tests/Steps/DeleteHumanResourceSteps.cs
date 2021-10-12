using System;
using TechTalk.SpecFlow;

namespace HumanResources.Services.Tests.Steps
{
    [Binding]
    public class DeleteHumanResourceSteps
    {
        [When(@"I delete an existing human resource")]
        public void WhenIDeleteAnExistingHumanResource()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the database record will be deleted")]
        public void ThenTheDatabaseRecordWillBeDeleted()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
