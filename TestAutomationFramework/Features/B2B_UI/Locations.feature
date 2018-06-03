Feature: B2B Locations feature
	In order to verify Locations feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_ Locations - Add location
	Given I login to the system as "Oleksii" (b2b)
	And I navigate to the "Locations" page (b2b)
	When I click on the "Add Location" button (b2b)
	And I populate the Location form with correct data (b2b)
	And I click on the "Create" button (b2b)
	Then Popup window with "Location created successfully" message and "done" status should be displayed (b2b)

@b2b @web
Scenario: B2B_Web_ Locations - Delete Location

@b2b @web
Scenario: B2B_Web_ Locations - Create sublocations

@b2b @web
Scenario: B2B_Web_ Locations - Delete Sublocations

@b2b @web
Scenario: B2B_Web_ Locations - Add second location with existing Location name
	Given I login to the system as "Oleksii" (b2b)
	And I navigate to the "Locations" page (b2b)
	When I click on the "Add Location" button (b2b)
	And I populate the Location form with correct data (b2b)
	And I click on the "Create" button (b2b)
	Then Popup window with "Location with name 'Test Location' already exists" message and "error" status should be displayed (b2b)