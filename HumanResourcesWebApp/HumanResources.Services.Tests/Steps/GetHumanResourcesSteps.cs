using FluentAssertions;
using HumanResources.Database;
using HumanResources.DataModels;
using HumanResources.Repositories;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HumanResources.Services.Tests.Steps
{
    [Binding]
    public class GetHumanResourcesSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private List<HumanResource> _allHumanResources;

        public GetHumanResourcesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I can get a list of all Human Resources")]
        public void GivenICanGetAListOfAllHumanResources()
        {
            var databaseConnections = new DatabaseConnections();
            var databaseConnection = new AccreditHrDatabaseConnectionFactory(databaseConnections).Create();

            var humanResourceRepository = new HumanResourceRepository(databaseConnection);
            _scenarioContext["HumanResourceService"] = new HumanResourceService(humanResourceRepository);
        }
        
        [When(@"I request all the human resources")]
        public void WhenIRequestAllTheHumanResources()
        {
            var humanResourceService = (HumanResourceService)_scenarioContext["HumanResourceService"];
            _allHumanResources = humanResourceService.GetAllHumanResources();
        }
        
        [Then(@"a list of human resources will be returned")]
        public void ThenAListOfHumanResourcesWillBeReturned()
        {
            _allHumanResources.Should().HaveCountGreaterThan(0);
        }
    }
}
