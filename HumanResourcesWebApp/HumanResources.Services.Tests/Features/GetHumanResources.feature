Feature: GetHumanResources
	As a Human resources Manager
	I would like to get a list pf all Human Resources

@GetHumanResources
Scenario: Get a list of all Human Resources
	Given I can get a list of all Human Resources
	When I request all the human resources
	Then a list of human resources will be returned