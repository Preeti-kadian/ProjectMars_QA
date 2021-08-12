Feature: Login
As a user	
	I want to login into account
So that
	I am able to enter profile details.

@login
Scenario: When valid username and password entered login should be successful
	Given I click on signin button on Login page 
    When I enter valid username and valid password credentials
    And Click on login button
    Then I login to my profile successfully.

	@login
Scenario: when invalid username and valid password entered login should be unsuccessful
	Given I click on login button
    When I enter invalid username and valid password
    And Click on login button
    Then I should not be logged in. 

    


