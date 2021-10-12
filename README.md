# HumanResourcesMVC

Technical excerise demonstrating the use of Asp.NET MVC web technology, applications layers, SOLID coding principles and SQL database queries.

## User Stories

1	As a Human resources manager I would like to get a list of all human resources

2	As a Human resources manager I would like to create a new human resource 

3	As a Human resources manager I would like to update an existing human resource

4	As a Human resources manager I would like to delete an existing human resource

## Acceptance Criteria

User Story | Acceptance Criteria

1	| Given I am a Human resources manager When I request the Human resources then a list of all human resources will be returned 

2	| Given I am a Human resources manager When I create a new human resource with valid data then a new record will be added to the database

3	| Given I am a Human resources manager When I update an existing human resource with valid data then the database record will be updated

4	| Given I am a Human resources manager When I delete an existing human resource Then the database record will be deleted


## Solution deployment
1. Download repository
2. Open DatabaseScript.sql in MSSQL
3. Update the database installation location on lines 8 & 10 ****NOTE : This step is important ****
4. Run script
5. Open Visual Studio Solution in VS2019
6. Update the database connection string ****NOTE : This step is also important ****
7. Build Solution
8. Run Tests to seed database data (Specflow Extension may be needed)

## Considerations
 
