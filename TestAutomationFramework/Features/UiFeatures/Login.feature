Feature: Login
	Check if login functionality works

@web
Scenario: Login user as Administrator
	Given I navigate to application
	And I enter username and password
		| UserName                      | Password   |
		| alexander.burdeyniy@gmail.com | Rjcvjc2020 |
	And I click login
	Then I should see user logged into the application
