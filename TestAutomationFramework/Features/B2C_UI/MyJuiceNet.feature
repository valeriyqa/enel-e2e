Feature: B2C MyJuiceNet
	In order to verify JuiceNet functionality
	we run next scenarios

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_01 - Add/Delete JuiceNet Device
	Note! We collect add and delete scenarios together to avoid parallel execution collision,
	when separate scenarios may perform mutually exclusive actions.

	Given JuiceNet device is not added (b2c)
	And I login to the system as "Oleksii" (b2c)
	When I click on button with name "Add JuiceNet Device" (b2c)
	And I set field "inputUnitID" to "373708002" (b2c)
	And I click on button with name "Add JuiceNet Device" (b2c)
	And I click on "Browse My JuiceNet Devices" link (b2c)
	Then JuiceNet device with Id "373708002" should exist is "True" (b2c)
	When I click More Details for device with Id "373708002" (b2c)
	And I click on button with name "Delete" (b2c)
	And I click on button with name "Yes, remove from my account" (b2c)
	Then JuiceNet device with Id "373708002" should exist is "False" (b2c)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_02 - JuiceNet Device Status
	Given  I login to the system as "Oleksii" (b2c)
	When I click More Details for device with Id "373709011" (b2c)
	Then field with Label "Allowed Current" should be equal to "60" (b2c)
	And field with Label "Charging Limit" should be equal to "0" (b2c)
	Given all checkboxes on panel with Id "panelNotify" is not activated (b2c)
	When I click all checkboxes on panel with Id "panelNotify" (b2c)
	When I click on button with Id "saveNotificationsButton" (b2c)
	Then all checkboxes on panel with Id "panelNotify" should be activated (b2c)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_03 - JuiceNet Device History
	Given  I login to the system as "Oleksii" (b2c)
	When I click More Details for device with Id "373709011" (b2c)
	And I click on tab with label "History" (b2c)
	When I get data from table with Id "usagetable" (b2c)
	Then table should be empty (b2c)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_04 - JuiceNet Device states on dashboard
	Given  I login to the system as "Oleksii" (b2c)
	When I send UDP package with status "Standby" to unit "373709011"
	Then panel color for device with Id "373709011" should be changed to "primary" (b2c)
	And device with Id "373709011" should have status "Standby" (b2c)
	When I send UDP package with status "Connected" to unit "373709011"
	Then panel color for device with Id "373709011" should be changed to "green" (b2c)
	And device with Id "373709011" should have status "Plugged in" (b2c)
	When I remember charging and saving values for device with Id "373709011" (b2c)
	And I send UDP package with status "Charging" to unit "373709011"
	Then panel color for device with Id "373709011" should be changed to "yellow" (b2c)
	And device with Id "373709011" should have status "Charging" (b2c)
	And energy and savings for device with Id "373709011" should grow (b2c)
	Then I send UDP package with status "Standby" to unit "373709011"

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_05 - JuiceNet Device Settings and Savings Parameters
	Given  I login to the system as "Oleksii" (b2c)
	When I click More Details for device with Id "373709011" (b2c)
	And I click on tab with label "Settings" (b2c)
	When I populate the JuiceNet Device Settings form with "initial_JDS" data (b2c)
	And I click on the Update button for pannel with Id "panelSettings" (b2c)
	Then JuiceNet Device Settings form fields values should be equal to "initial_JDS" data (b2c)
	When I populate the JuiceNet Device Settings form with "updated_JDS" data (b2c)
	And I click on the Update button for pannel with Id "panelSettings" (b2c)
	Then JuiceNet Device Settings form fields values should be equal to "updated_JDS" data (b2c)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_06 - JuiceNet Device Settings. Empty Zip code
	Given  I login to the system as "Oleksii" (b2c)
	When I click More Details for device with Id "373709011" (b2c)
	And I click on tab with label "Settings" (b2c)
	When I populate the JuiceNet Device Settings form with "initial_JDS" data (b2c)
	And I click on the Update button for pannel with Id "panelSettings" (b2c)
	Then JuiceNet Device Settings form fields values should be equal to "initial_JDS" data (b2c)
	When I populate the JuiceNet Device Settings form with "nozip_JDS" data (b2c)
	And I click on the Update button for pannel with Id "panelSettings" (b2c)
	Then Error message "The Zip code field is required." is displayed (b2c)
	When I refresh page (b2c)
	And I click on tab with label "Settings" (b2c)
	Then JuiceNet Device Settings form fields values should be equal to "initial_JDS" data (b2c)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_07 - Time-of-Use (TOU)
	Given I login to the system as "Oleksii" (b2c)
	When I click More Details for device with Id "373709011" (b2c)
	And I click on tab with label "Settings" (b2c)
	Given switch with Id "toggleTOU" is not activated (b2c)
	When I click on swith with Id "toggleTOU" (b2c)
	Then swith with Id "toggleTOU" should be enabled is "True" (b2c)
	Then I print table (test)
	#Then panel with Id "zzz" should change color to "primary" (b2c)
	#When I click on swith with Id "overrideCheckBox" (b2c)
	When I set TOU time to "current" (b2c)



#Run "Add JuiceNet Device" test case
#Navigate to dashboard
#Click on "More Details" link in Device area
#User is navigated to device page with active Status tab
#Click on Settings tab
#User is navigated to Settings tab
#Turn TOU On
#Week day and Weekend start/end time appear
#Set TOU starts at the following hour(e.g., if it’s 1:46am at the moment, set TOU to start at 2am and end at 3am)
#Click on "Update" button
#Updated fields display correct data
#Click on Status tab
#Confirm that Override button appears and  the charge stops
#Click override button
#The state changed  to Charging . Back color turn to orange.
#Click override button again to turn it off
#Button goes back to gray and current stops
#Wait until TOU period starts
#Charge starts as expected
#Turn TOU Off
#Click on "Update" button
#Week day and Weekend start/end time not display

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_09 - TOU Persistence**
#Run "Add JuiceNet Device" test case
#Navigate to dashboard
#Click on "More Details" link in Device area
#User is navigated to device page with active Status tab
#Click on Settings tab
#User is navigated to Settings tab
#Turn TOU On
#Week day and Weekend start/end time appear
#Set TOU starts at the following hour(e.g., if it’s 1:46am at the moment, set TOU to start at 2am and end at 3am)
#Click on "Update" button
#Updated fields display correct data
#Disconnect emulator Device from Network
#Confirm the unit appears as "Offline"
#Connect Device back
#Confirm that charging does not automatically resume once connectivity is lost
#Wait until TOU period starts
#Charge starts as expected
#Set TOU ends at the following hour(e.g., if it’s 1:46am at the moment, set TOU to start at 1am and end at 2am)
#Charging ends at the intended end of TOU time
#Reset TOU back to 12am-12am
#Click on "Update" button
#Updated fields display correct data

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_10 - Minimal charge. Charging starts before TOU start time.**
#Run "Add JuiceNet Device" test case
#Navigate to dashboard
#Click on "More Details" link in Device area
#User is navigated to device page with active Status tab
#Click on Settings tab
#User is navigated to Settings tab
#Check Minimal charge is off
#Field displays 0
#Turn TOU On
#Week day and Weekend start/end time appear
#Set TOU starts at the following hour(e.g., if it’s 1:46am at the moment, set TOU to start at 2am and end at 3am)
#Change Minimal charge value to 5KWh
#Click on "Update" button
#Updated fields display correct data
#Click on Status tab
#The state changed  to Charging . Back color turn to orange.
#Click on Settings tab
#User is navigated to Settings tab
#Set Minimal charge value to 0
#Click on "Update" button
#Updated fields display correct data
#Click on Status tab
#The state changed to Plugged In. Back color turn to green.

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_11 - Minimal charge. Charging continues after TOU end time.**
#Run "Add JuiceNet Device" test case
#Navigate to dashboard
#Click on "More Details" link in Device area
#User is navigated to device page with active Status tab
#Click on Settings tab
#User is navigated to Settings tab
#Check Minimal charge is off
#Field displays 0
#Turn TOU to On
#Week day and Weekend start/end time appear
#Set TOU ends at the following hour(e.g., if it’s 1:46am at the moment, set TOU to start at 1am and end at 2am)
#Set Minimal charge value as 5KWh
#Click on "Update" button
#Updated fields display correct data
#Click on Status tab
#The state changed  to Charging . Back color turn to orange.
#Wait until TOU period ends
#Charging continues, in case of Minimal charge value is not equal to 5KWh.
#Click on Status tab
#The state changed  to Charging . Back color turn to orange.
#Click on Settings tab
#User is navigated to Settings tab
#Set Minimal charge value to 0
#Click on "Update" button
#Updated fields display correct data
#Click on Status tab
#The state changed to Plugged In. Back color turn to green.

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_12 - EVSE Efficiency**
#Run "Add JuiceNet Device" test case
#Navigate to dashboard
#Click on "More Details" link in Device area
#User is navigated to device page with active Status tab
#Click on Settings tab
#User is navigated to Settings tab
#Check EVSE Efficiency is 92%
#Set EVSE Efficiency value to 50%
#Click on "Update" button
#Updated fields display correct data
#Click on Status tab
#Energy and Saving value changes
#Click on History tab
#User is navigated to History tab
#Check history entries
#Charging History kWh numbers - DO NOT apply EVSE efficiency.

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_13 - Add empty Load groups.**
#Navigate to Load Group Management
#User is navigated to Load Group page with empty table of groups
#Click on New Load Group button
#Enter Group name
#Click on Save changes button
#New group displays in table
#Click on New Load Group button
#Enter Group name
#Click on Save changes button
#Display error message “Load Group could not be created. User already has one empty load group.”
#Click on Edit button
#Enter new name
#Enter Maximum Current value
#Click on Save changes button
#Updated fields display correct data
#Click on Delete button
#Display warning modal window message “Are you sure you want delete the group <group name> ?.”
#Click on Delete LoadGroup button
#Display operation succeed modal window message “Load Group deleted successfully.”
#Click on Close button
#Load Group page display with empty table of groups

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_14 - Add devices to Load group.**
#Run "Add JuiceNet Device" for 2 units
#Navigate to Load Group Management
#User is navigated to Load Group page with empty table of groups
#Click on New Load Group button
#Enter Group name
#Click on Save changes button
#New group displays in table
#Click on empty Load group string in a table
#JuiceNet devices selector appears
#Select all devices
#Click on Add selected JNDevices to Load Group
#Display Add JuiceNet Devices To Load Group modal window with list of added IDs
#Click on Close button
#Check the List of devices and number of units in a cell.
#Two units displays in a table. Units # = 2
#Navigate to dashboard
#Load groups icon appear on device areas

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_15 - Notifications**
#Add and test all of notifications types
#Email and popup
#Charging start
#Charging stop
#Charging delayed due to ToU
#Unit is back online
#Unit offline
#Unit is not plugged in by (set time in settings)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_16 - SW corrections**
#* 3 phase car and 3 phase unit
#  - Energy 3
#* No selected car and 3 phase unit
#  - Energy 3
#* 1 phase car and 3 phase unit
#  - Energy 1
#* 3 phase car and 1 phase unit
#  - Energy 1
#* 1 phase car and 1 phase unit
#  - Energy 1
#* No selected car and 1 phase unit
#  - Energy 1
#* Go to Admin Utilities - Cars
#* Check that you can change phase for some car