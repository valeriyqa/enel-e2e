Feature: B2B Manage Devices feature
	In order to verify Manage Devices feature functionality
	we run next scenarios

#@b2b @web @ignore
#Scenario: B2B_Web_ Manage Devices - Add Device(Valid ID)
#	Given I login to the system as "Web user" (b2b)
#	And I navigate to the "Devices" page (b2b)
#	When I click on the "Add Device" button (b2b)
#	And I set input "physicalId" to the value "373708001" (b2b)
#	And I click on the "Create" button (b2b)
#	Then Popup window with "Device created successfully" message and "done" status should be displayed (b2b)
#	When I click on the "View devices" button (b2b)
#	Then Tab "Unlinked Devices" should be selected (b2b)
#	#And Device with ID "373708001" exist in the table is "True" (b2b)
#
#@b2b @web @ignore
#Scenario: B2B_Web_ Manage Devices - Add Device(Already added Unit ID)
#	Given I login to the system as "Web user" (b2b)
#	And I navigate to the "Devices" page (b2b)
#	When I click on the "Add Device" button (b2b)
#	And I set input "physicalId" to the value "373708001" (b2b)
#	And I click on the "Create" button (b2b)
#	Then Popup window with "This Device '373708001' is used by other account." message and "error" status should be displayed (b2b)

@b2b @web
Scenario: B2B_Web_ Manage Devices - Add Device(Incorrect Unit ID)

@b2b @web
Scenario: B2B_Web_ Manage Devices - Link device to Location 

@b2b @web
Scenario: B2B_Web_ Manage Devices - Unlink Device

@b2b @web
Scenario: B2B_Web_ Manage Devices - Link device to Sublocation 

@b2b @web
Scenario: B2B_Web_ Manage Devices - Charging

@b2b @web
Scenario: B2B_Web_ Manage devices - Reset ownership
