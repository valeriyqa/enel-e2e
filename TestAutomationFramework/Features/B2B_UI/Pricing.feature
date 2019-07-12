Feature: B2B Pricing feature
	In order to verify Admin Of Reseller feature functionality
	we run next scenarios

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
