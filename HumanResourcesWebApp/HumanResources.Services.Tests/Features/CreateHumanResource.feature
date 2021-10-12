Feature: CreateHumanResource
	As a Human resources Manager 
	I would like to create a new Human Resource
	so that i can build a database of Human Resources

@CreateHumanResource
Scenario: Create a new Human Resource record
	Given I am a Human Resources Manager
	When I create a new human resourec with valid data
	Then a new record will be added to the database