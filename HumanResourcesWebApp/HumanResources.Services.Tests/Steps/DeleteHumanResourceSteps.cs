using FluentAssertions;
using HumanResources.DataModel.Builders;
using HumanResources.DataModels;
using System;
using TechTalk.SpecFlow;

namespace HumanResources.Services.Tests.Steps
{
    [Binding]
    public class DeleteHumanResourceSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public DeleteHumanResourceSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have created an existing human resource")]
        public void GivenIHaveCreatedAnExistingHumanResource()
        {
            var humanResourceService = (HumanResourceService)_scenarioContext["HumanResourceService"];
            var newResource = new RandomHumanResourceBuilder().Build();
            _scenarioContext["ExistingResource"] = humanResourceService.Create(newResource);
        }


        [When(@"I delete an existing human resource")]
        public void WhenIDeleteAnExistingHumanResource()
        {
            var existingResource = (HumanResource)_scenarioContext["ExistingResource"];

            var humanResourceService = (HumanResourceService)_scenarioContext["HumanResourceService"];
            _scenarioContext["DeleteRecords"] = humanResourceService.Delete(existingResource.EmployeeNumber);
        }
        
        [Then(@"the database record will be deleted")]
        public void ThenTheDatabaseRecordWillBeDeleted()
        {
            var numberOfDeletedRecords = (int)_scenarioContext["DeleteRecords"];

            numberOfDeletedRecords.Should().Be(1);
        }
    }
}
