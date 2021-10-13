using FluentAssertions;
using HumanResources.Database;
using HumanResources.DataModel.Builders;
using HumanResources.DataModels;
using HumanResources.Repositories;
using System;
using TechTalk.SpecFlow;

namespace HumanResources.Services.Tests.Steps
{
    [Binding]
    public class UpdateHumanResourceSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public UpdateHumanResourceSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am a Human resources manager")]
        public void GivenIAmAHumanResourcesManager()
        {
            var databaseConnections = new DatabaseConnections();
            var databaseConnection = new AccreditHrDatabaseConnectionFactory(databaseConnections).Create();

            var humanResourceRepository = new HumanResourceRepository(databaseConnection);
            var humanResourceService = new HumanResourceService(humanResourceRepository);
            _scenarioContext["HumanResourceService"] = humanResourceService;

                var newResource = new RandomHumanResourceBuilder().Build();
            _scenarioContext["ExistingResource"] = humanResourceService.Create(newResource);
        }

        [When(@"I update an existing human resource with valid data")]
        public void WhenIUpdateAnExistingHumanResourceWithValidData()
        {
            var existingResource = (HumanResource)_scenarioContext["ExistingResource"];

            var updatedResource = new RandomHumanResourceBuilder().Build();
            updatedResource.Status = new RandomStatusBuilder().ExcludeStatus(existingResource.Status).Build();
            updatedResource.EmployeeNumber = existingResource.EmployeeNumber;

            var humanResourceService = (HumanResourceService)_scenarioContext["HumanResourceService"];
            _scenarioContext["UpdatedResource"] = humanResourceService.Update(updatedResource);
        }

        [Then(@"the database record will be updated")]
        public void ThenTheDatabaseRecordWillBeUpdated()
        {
            var existingResource = (HumanResource)_scenarioContext["ExistingResource"];
            var updatedResource = (HumanResource)_scenarioContext["UpdatedResource"];

            updatedResource.FirstName.Should().NotBeEquivalentTo(existingResource.FirstName);
            updatedResource.LastName.Should().NotBeEquivalentTo(existingResource.LastName);
            updatedResource.DateOfBirth.Should().BeAfter(existingResource.DateOfBirth);
            updatedResource.Department.Should().NotBeEquivalentTo(existingResource.Department);
            updatedResource.Email.Should().NotBeEquivalentTo(existingResource.Email);
            updatedResource.Status.Should().NotBeEquivalentTo(existingResource.Status);
        }
    }
}
