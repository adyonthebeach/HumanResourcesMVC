Feature: DeleteHumanResource
	As a Human resources manager 
	I would like to delete an existing human resource

@DeleteHumanResource
Scenario: Add two numbers
	Given I am a Human Resources Manager
	When I delete an existing human resource
	Then the database record will be deleted