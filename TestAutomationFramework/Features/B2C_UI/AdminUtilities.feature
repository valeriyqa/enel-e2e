Feature: B2C Admin Utilities feature
	In order to verify Admin Utilities functionality
	we run next scenarios

@b2c @web
Scenario: B2C_Web_Admin_Utilities_01 - JuiceNet Device Lookup
	#Run "Add JuiceNet Device" test case ?
	Given I login to the system as "Oleksii" (b2c)
	And I navigate to the "My JuiceNet Devices" page (b2c)
	Then JuiceNet device with Id "373708002" should exist is "True" (b2c)
	When I click More Details for device with Id "373708002" (b2c)
	Then I save device "373708002" ID (b2c)

	#Given I login to the system as "Admin" (b2c) ?
	Given I navigate to "Account/Login" page (b2c)
	When I set field with Id "Email" to "pavel.tsios@emotorwerks.com" (b2c)
	And I set field with Id "Password" to "eMW2018" (b2c)
	And I click on button with name "Login" (b2c)
	Given I navigate to the "Admin Utilities" page (b2c)
	And I navigate to the "JuiceNet Device Lookup" page (b2c)
	When I set field Id "inputUnitID" with shared data (b2c)
	And I click on related to the field with Id "inputUnitID" search button (b2c)
	
	#Confirm page data with device details - mock
	Then I should see Unit Id "373708002" (b2c)

@b2c @web
Scenario: B2C_Web_Admin_Utilities_02 - JuiceNet Device Lookup with active TOU
#Run "Add JuiceNet Device" test case
#Navigate to dashboard
#Click on "More Details" link in Device area
#User is navigated to device page with active Status tab
#Click on Settings tab
#User is navigated to Settings tab
#Turn TOU on
#Week day and Weekend start/end time appear
#Login as Admin
#Navigate to JuiceNet Device Lookup page from Admin Utilities menu
#User is navigated to Device Lookup page with active Info tab
#Enter Device ID
#Confirm Time-Of-Use area display schedule

@b2c @web
Scenario: B2C_Web_Admin_Utilities_03 - JuiceNet Device Lookup. Policy changes
#Run "Add JuiceNet Device" test case
#Navigate to dashboard
#User is navigated to device page with active Status tab
#Copy Device ID
#Login as Admin
#Navigate to Manage Device Policies page from Admin Utilities menu
#User is navigated to empty Manage Device Policies page with just search area cell
#Enter Device ID and click search button
#Device information with Id, Name and Current policy appears
#Select Green Policy by clicking Set Green WT button
#Current policy display "Green WT" name and green round
#Navigate to JuiceNet Device Lookup page from Admin Utilities menu
#User is navigated to Device Lookup page with active Info tab
#Enter Device ID
#Confirm Policy name
#Poly name changed to Green Box
#Navigate to Manage Device Policies page from Admin Utilities menu
#User is navigated to empty Manage Device Policies page with just search area cell
#Enter Device ID and click search button
#Device information with Id, Name and Current policy appears
#Select Set Deafult

@b2c @web
Scenario: B2C_Web_Admin_Utilities_04 - JuiceNet Device Lookup. Search by IP
#Run "Add JuiceNet Device" test case
#Navigate to dashboard
#User is navigated to device page with active Status tab
#Open Add JuiceNet Device page
#Copy IP Address
#Login as Admin
#Navigate to JuiceNet Device Lookup page from Admin Utilities menu
#User is navigated to Device Lookup page with active Info tab
#Enter IP Address
#Confirm all devices display

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