# HumanResourcesMVC

Technical excercise demonstrating the use of Asp.NET MVC web technology, applications layers, testing using SpecFlow, SOLID coding principles and SQL database queries.

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
5. To seed the database with some meaningful data once the database has been created run the SeedData.sql script
6. Open Visual Studio Solution in VS2019
7. Update the database connection string which can be found in the connectionStrings.json file in the HumanResources.Database ****NOTE : This step is also important ****
8. Build Solution
9. Run Tests to validate the Service layer of the application (NOTE: this will no doubt produce some random garbage data)

## Considerations
1. To be able to scale out the application I would consider extracting the data requests from the UI into an seperate API
2. The application works by requesting the whole list of resources from the database
        a. This approach is not great, but the pagination works really well
        b. This method will only perform well until the dataset gets very big
        c. The filtering is a task that should be performed by the database
        d. I would recommend upgrading this part of the application first
3. The specflow tests work well enough for this demo but I would consider more unit tests on the controller methods, mocking the data and using API tests once the data reqeusts have been split out
