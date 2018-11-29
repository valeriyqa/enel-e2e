Feature: B2C Login
	Check if login functionality works

@b2c @web
Scenario: B2C_Web_ Login to the application as registered user
	Given I login to the b2c system as "Oleksii"
