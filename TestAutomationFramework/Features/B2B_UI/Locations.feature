Feature: B2B Locations feature
	In order to verify Locations feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_Locations_01 - Add location
	Given I wait for "5" seconds (b2c)
	Given I login to the system as "Web user" (b2b)
	#And I navigate to the "Locations" page (b2b)
	#And I delete location "Test Location" if exist (b2b)
	#Then Location with name "Test Location" exist in the table is "False" (b2b)
	#When I click on the "Add Location" button (b2b)
	#And I populate the Location form with correct data (b2b)
	#And I click on the "Create" button (b2b)
	#Then Popup window with "Successfully created" message and "done" status should be displayed (b2b)
	#When I click on the "View locations" button (b2b)
	#Then Location with name "Test Location" exist in the table is "True" (b2b)

@b2b @web
Scenario: B2B_Web_Locations_02 - Create sublocations
	#Given I login to the system as "Web user" (b2b)
	#And I navigate to the "Locations" page (b2b)
	#Then Location with name "Test Location" exist in the table is "True" (b2b)
	#When I click on the "Test Location" link by name (b2b)
	#And I click on the "Add SubLocation" button (b2b)
	#And I populate the Location form with correct data and "New Sublocation" title (b2b)
	#And I click on the "Create" button (b2b)
	#Then Popup window with "Successfully created" message and "done" status should be displayed (b2b)
	#When I click on the "View locations" button (b2b)
	#Then Location with name "New Sublocation" exist in the table is "True" (b2b)
	#And Location with name "Test Location" is parent for "New Sublocation" (b2b)

@b2b @web
Scenario: B2B_Web_Locations_03 - Delete Sublocations

@b2b @web
Scenario: B2B_Web_Locations_04 - Add second location with existing Location name
	#Given I login to the system as "Web user" (b2b)
	#And I navigate to the "Locations" page (b2b)
	#When I click on the "Add Location" button (b2b)
	#And I populate the Location form with correct data (b2b)
	#And I click on the "Create" button (b2b)
	#Then Popup window with "Location with name 'Test Location' already exists" message and "error" status should be displayed (b2b)

@b2b @web
Scenario: B2B_Web_Locations_05 - Delete Location
	#Given I login to the system as "Web user" (b2b)
	#And I navigate to the "Locations" page (b2b)
	#When I click on the "Test Location" link by name (b2b)
	#And I click on the "Delete Location" button (b2b)
	#And I click on the "Remove" button (b2b)
	#Then Location with name "Test Location" exist in the table is "False" (b2b)


