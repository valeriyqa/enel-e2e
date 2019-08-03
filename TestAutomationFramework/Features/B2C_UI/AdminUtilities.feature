Feature: B2C Admin Utilities feature
	In order to verify Admin Utilities functionality
	we run next scenarios

@b2c @web
Scenario: B2C_Web_Admin_Utilities_01 - JuiceNet Device Lookup
	Given I login to the system as "WebUser" (b2c)
	And I navigate to the "My JuiceNet Devices" page (b2c)
	Then JuiceNet device with key in config "test2_unit_id" should exist is "True" (b2c)
	Given I login to the system as "Admin" (b2c)
	And I navigate to the "JuiceNet Device Lookup" page (b2c)
	When I set field "inputUnitID" to "test2_unit_id" from config (b2c)
	And I click on related to the field with Id "inputUnitID" search button (b2c)
	Then Info tab should contains unit with Id "test2_unit_id" from config file (b2c)

@b2c @web
Scenario: B2C_Web_Admin_Utilities_02 - JuiceNet Device Lookup with active TOU
	Given I login to the system as "WebUser" (b2c)
	And I navigate to the "My JuiceNet Devices" page (b2c)
	Then JuiceNet device with key in config "test3_unit_id" should exist is "True" (b2c)
	When I click More Details for device with key in config "test3_unit_id" (b2c)
	And I click on tab with label "Settings" (b2c)
	Given switch with Id "toggleTOU" is not activated (b2c)
	When I click on switch with Id "toggleTOU" (b2c)
	And I remeber the current time on device (b2c)
	And I set TOU time to "current" (b2c)
	And I click on the Update button for pannel with Id "panelTOU" (b2c)
	Given I login to the system as "Admin" (b2c)
	And I navigate to the "JuiceNet Device Lookup" page (b2c)
	When I set field "inputUnitID" to "test3_unit_id" from config (b2c)
	And I click on related to the field with Id "inputUnitID" search button (b2c)
	Then Info tab should contains unit with Id "test3_unit_id" from config file (b2c)
	Then TOU time on the Admin/JuiceNetDeviceLookup page should be equal to "current" (b2c)
	
@b2c @web
Scenario: B2C_Web_Admin_Utilities_03 - JuiceNet Device Lookup. Policy changes
	Given I login to the system as "WebUser" (b2c)
	And I navigate to the "My JuiceNet Devices" page (b2c)
	Then JuiceNet device with key in config "test3_unit_id" should exist is "True" (b2c)
	Given I login to the system as "Admin" (b2c)
	And I navigate to the "Manage Device Policies" page (b2c)
	When I set field "inputUnitID" to "test3_unit_id" from config (b2c)
	And I click on related to the field with Id "inputUnitID" search button (b2c)
	Given related to Device ID policy set to "Default" (b2c)
	When I click on button with name "Set Green WT" (b2c)
	Then I should see related to Device ID policy "Green WT" (b2c)
	When I navigate to the "JuiceNet Device Lookup" page (b2c)
	And I set field "inputUnitID" to "test3_unit_id" from config (b2c)
	And I click on related to the field with Id "inputUnitID" search button (b2c)
	Then Info tab should contains unit with Id "test3_unit_id" from config file (b2c)
	And I should see Unit Policy "Green Box" (b2c)
	When I navigate to the "Manage Device Policies" page (b2c)
	And I set field "inputUnitID" to "test3_unit_id" from config (b2c)
	And I click on related to the field with Id "inputUnitID" search button (b2c)
	When I click on button with name "Default" (b2c)
	Then I should see related to Device ID policy "Default" (b2c)

#Probably we have to add method that change status for all devices to Stanby before check them in the Admin UI,
#since sometimes they can be missing
#@b2c @web
#Scenario: B2C_Web_Admin_Utilities_04 - JuiceNet Device Lookup. Search by IP
#	Given I login to the system as "WebUser" (b2c)
#	And I navigate to the "My JuiceNet Devices" page (b2c)
#	When I remeber id for all added devices (b2c)
#	When I click on button with name "Add JuiceNet Device" (b2c)
#	And I remeber my current IP address (b2c)
#	Given I login to the system as "Admin" (b2c)
#	And I navigate to the "JuiceNet Device Lookup" page (b2c)
#	When I set field "inputIPAddress" to remembered IP addess (b2c)
#	And click search button for field with id "inputIPAddress" (b2c)
#	Then I wait until element with Id "unitBoxInfoAll" will be displayed (b2c)
#	When I get all data from table with Id "table_of_juiceboxes_wrapper" (b2c)
#	Then I assert that column with name "Device ID" contains all remembered IDs (b2c)


@b2c @web
Scenario: B2C_Web_Admin_Utilities_05 - Add Device from User Lookup page
#Create new device in JuiceBox Emulator
#Copy Device ID
#Login as Admin
#Navigate to User Lookup page from Admin Utilities menu
#User is navigated to empty User Lookup page with just search area cell
#Enter user name (user should have 1 or more devices)
#Confirm all user data and devices display
#Go to "Add a JuiceNet device to this user's account" area and enter Device ID
#Select Unit Admin Role
#Click Add JuiceNet Device button
#Device is added to unit table with selected role
#Login as user
#Check dashboard for a new device
#Device display on dashboard

@b2c @web
Scenario: B2C_Web_Admin_Utilities_06 - Delete Device from User Lookup page
#Login as Admin
#Navigate to User Lookup page from Admin Utilities menu
#User is navigated to empty User Lookup page with just search area cell
#Enter user name (user should have 1 or more devices)
#Confirm all user data and devices display
#Click Remove button on a device row
#Device is deleted from unit table
#Login as user
#Check dashboard for a deleted device
#Device is deleted from dashboard

@b2c @web
Scenario: B2C_Web_Admin_Utilities_07 - Assign admin role to user
#Login as Admin
#Navigate to User Lookup page from Admin Utilities menu
#User is navigated to empty User Lookup page with just search area cell
#Enter user name
#Confirm all user data and devices display
#Set user role to Admins
#Login as user
#Check License Agreement appear
#Click Confirm buttom
#Confirm Admin Utilities and OCPP menu items display
#Login as Admin
#Navigate to User Lookup page from Admin Utilities menu
#Enter user name
#Confirm all user data and devices display
#Cancel Admins role
#Login as user
#Confirm no Admin Utilities and OCPP menu items display

@b2c @web
Scenario: B2C_Web_Admin_Utilities_08 - Add a new role
#Login as Admin
#Navigate to Manage roles page from Admin Utilities menu
#User is navigated to empty User Lookup page with just search area cell
#Input some name in Role name field
#Click Add role buttom
#New role appears in a table below
#Select new role in a table below
#List of permissions opens
#Set all permissions to On

@b2c @web
Scenario: B2C_Web_Admin_Utilities_09 - Roles Management. All permissions off
#Create new device in JuiceBox Emulator
#Copy Device ID
#Run "Add a new role" test case
#Set all permissions to Off
#Navigate to User Lookup page from Admin Utilities menu
#User is navigated to empty User Lookup page with just search area cell
#Enter user name (user should have 1 or more devices)
#Confirm all user data and devices display
#Go to "Add a JuiceNet device to this user's account" area and enter Device ID
#Select role, created in step 3 and 4
#Add JuiceNet device
#Device display in table
#Login as user
#Click on "More Details" link in Device area
#User is navigated to device page with active Status tab
#Confirm Allowed Current and Charging Limit are not able to edit
#Click on Settings tab
#User is navigated to Settings tab
#Confirm Wire rating is not able to edit

@b2c @web
Scenario: B2C_Web_Admin_Utilities_10 - Roles Management. All permissions on
#Create new device in JuiceBox Emulator
#Copy Device ID
#Run "Add a new role" test case
#Navigate to User Lookup page from Admin Utilities menu
#User is navigated to empty User Lookup page with just search area cell
#Enter user name (user should have 1 or more devices)
#Confirm all user data and devices display
#Go to "Add a JuiceNet device to this user's account" area and enter Device ID
#Add JuiceNet device  
#Device display in table
#Select role, created in step 3
#Login as user
#Confirm Guest pairing pin buttom appear on a device box area
#Click on "More Details" link in Device area
#User is navigated to device page with active Status tab
#Confirm Allowed Current and Charging Limit are able to edit, nitifications area and History tab appear
#Click on Settings tab
#User is navigated to Settings tab
#Confirm Wire rating is able to edit and Schedule area appear

@b2c @web
Scenario: B2C_Web_Admin_Utilities_11 - Add Load Group
#Login as Admin
#Navigate to Load Group Management page from Admin Utilities menu
#User is navigated to Load Group page with a table of all created groups
#Enter Group name
#Enter Maximum Current = 100A
#Click on Add Load Group button
#New load group appears in List of groups. Owner is "admin's group"
#Select new load group
#Confirm Add JuiceNet Device and List of JuiceNet Device areas appear

@b2c @web
Scenario: B2C_Web_Admin_Utilities_12 - Add Devices to admin's Load Group
#Create 3 devices in JuiceBox Emulator
#Run "Add Load Group " test case from Admin Utilities suit
#Provide unit ID
#Click + button
#Page refreshes with none of groups selected
#Select your load group
#Repeat steps 2 - 4 for 2 other units
#Check the units # value in a cell = 3
#Login as user
#Add all new devices to dashboard
#Load groups icon appear on devices areas
#Navigate to Load Group Management
#User can't see admin's load group
#Check units are disable to be added to user load group

@b2c @web
Scenario: B2C_Web_Admin_Utilities_13 - Delete Load Group with units in it
#Run "Add Load Group " and "Add Devices to admin's Load Group " test case from Admin Utilities suit
#Login as Admin
#Navigate to Load Group Management page from Admin Utilities menu
#User is navigated to Load Group page with a table of all created groups
#Select your load group
#Click on Delete button
#Load group successfully removed
#Login as user
#Check Load groups icon is not display on Devices
#Navigate to Load Group Management
#Click on Add selected JNDevices to Load Group
#Display Add JuiceNet Devices To Load Group modal window with list of added IDs
#Confirm devices added to dropdown list