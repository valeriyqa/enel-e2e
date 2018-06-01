Feature: For test onlu
	In order to avoid silly mistakes
	As a math idiot

@b2b @web
Scenario: Test B2B system
	Given I login to the system as "Oleksii" (b2b)
	And I navigate to the "Locations" page (b2b)
	When I click on the "Add Location" button (b2b)
	When I click the Same as parent checkbox (b2b)
	#When I set input "name" to the value "TestName" (b2b)
	#When I set input "address" to the value "TestAddress" (b2b)
	#When I set input "city" to the value "TestCity" (b2b)
	#When I set input "state" to the value "TestState" (b2b)
	#When I set input "zip" to the value "12345" (b2b)
	When I select "(UTC-07:00) Arizona" on the Time zone selector (b2b)
	When I select "Free" on the Assign rate selector (b2b)
