Feature: DeleteHumanResource
	As a Human resources manager 
	I would like to delete an existing human resource

@DeleteHumanResource
Scenario: Delete an existing Human Resource
	Given I am a Human Resources Manager
	And I have created an existing human resource
	When I delete an existing human resource
	Then the database record will be deleted