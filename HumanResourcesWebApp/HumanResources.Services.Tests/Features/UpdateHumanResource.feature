Feature: UpdateHumanResource
	As a Human resources manager 
	I would like to update an existing human resource

@UpdateHumanResource
Scenario: Update an existing Human Resource record
	Given Given I am a Human resources manager
	When I update an existing human resource with valid data
	Then the database record will be updated