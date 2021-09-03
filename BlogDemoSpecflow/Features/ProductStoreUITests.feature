Feature: As a new user I should be able to register for a new account

Background: Given that I launch the browser and navigate to the website landing gpage
Given I launch Browser and Navigate to ProductStore Landing Page


Scenario Outline: As a new user I should be able to register for a new account with sample data
	Given I navigate to SignUp
	When I fill the register account dialog with <username>, <password> and submit
	Then I validate that the account was registered
	When I Navigate to Login 
	And I fill the login dialog with <username>, <password> and submit
	Then I validate that I am able to login sucessfully
	Examples:
	| username         | password       |
	| jsnow@stark.got  | winterishere   |
	| nstark@stark.got | winteriscoming |