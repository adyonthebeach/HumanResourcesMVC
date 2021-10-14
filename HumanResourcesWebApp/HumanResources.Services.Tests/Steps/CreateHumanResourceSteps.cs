using FluentAssertions;
using HumanResources.Database;
using HumanResources.DataModel.Builders;
using HumanResources.DataModels;
using HumanResources.Repositories;
using TechTalk.SpecFlow;

namespace HumanResources.Services.Tests.Steps
{
    [Binding]
    public class CreateHumanResourceSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public CreateHumanResourceSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am a Human Resources Manager")]
        public void GivenIAmAHumanResourcesManager()
        {
            var databaseConnections = new DatabaseConnections();
            var databaseConnection = new AccreditHrDatabaseConnectionFactory(databaseConnections);

            var humanResourceRepository = new HumanResourceRepository(databaseConnection);
            _scenarioContext["HumanResourceService"] = new HumanResourceService(humanResourceRepository);
        }
        
        [When(@"I create a new human resourec with valid data")]
        public void WhenICreateANewHumanResourecWithValidData()
        {
            var humanResourceService = (HumanResourceService)_scenarioContext["HumanResourceService"];
            var newResource = new RandomHumanResourceBuilder().Build();
            _scenarioContext["NewResource"] = humanResourceService.Create(newResource);
        }
        
        [Then(@"a new record will be added to the database")]
        public void ThenANewRecordWillBeAddedToTheDatabase()
        {
            var newResource = (HumanResource)_scenarioContext["NewResource"];

            newResource.EmployeeNumber.Should().BeGreaterThan(0);
        }
    }
}
