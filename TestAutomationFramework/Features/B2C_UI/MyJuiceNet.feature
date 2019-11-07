Feature: B2C MyJuiceNet
	In order to verify JuiceNet functionality
	we run next scenarios

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_01and02 - Add/Delete JuiceNet Device
	Preconditions: corresponding config file should contains correctly filled fields "api_account_token",
	"api_device_id", "xxx_unit_id" and "xxx_token". Where "xxx" prefix shoulde be single word without
	underscore symble, since we use it for parsing. 

	Given JuiceNet device with key in config "test1_unit_id" is not added (b2c)
	And I login to the system as "WebUser" (b2c)
	When I click on button with name "Add JuiceNet Device" (b2c)
	When I set field "inputUnitID" to "test1_unit_id" from config (b2c)
	And I click on button with name "Add JuiceNet Device" (b2c)
	Then JuiceNet device with key in config "test1_unit_id" should exist is "True" (b2c)
	When I click More Details for device with key in config "test1_unit_id" (b2c)
	And I click on button with name "Delete" (b2c)
	And I click on button with name "Yes, remove from my account" (b2c)
	Then JuiceNet device with key in config "test1_unit_id" should exist is "False" (b2c)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_03 - JuiceNet Device Status
	Given I login to the system as "WebUser" (b2c)
	When I click More Details for device with key in config "test4_unit_id" (b2c)
	Then field with Label "Allowed Current" should be equal to "60" (b2c)
	And field with Label "Charging Limit" should be equal to "0" (b2c)
	Given all checkboxes on panel with Id "panelNotify" is not activated (b2c)
	When I click all checkboxes on panel with Id "panelNotify" (b2c)
	When I click on button with Id "saveNotificationsButton" (b2c)
	Then all checkboxes on panel with Id "panelNotify" should be activated (b2c)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_04 - JuiceNet Device History
	Given I login to the system as "WebUser" (b2c)
	When I click More Details for device with key in config "test4_unit_id" (b2c)
	And I click on tab with label "History" (b2c)
	When I get data from table with Id "usagetable" (b2c)
	Then table should be empty (b2c)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_05 - JuiceNet Device states on dashboard
	Given  I login to the system as "WebUser" (b2c)
	When I send UDP package with status "Standby" to device with key in config "test3_unit_id"
	Then icon color for device with key in config "test3_unit_id" should be changed to "grey" (b2c)
	And device with key in config "test3_unit_id" should have status "Available" (b2c)
	When I send UDP package with status "Connected" to device with key in config "test3_unit_id"
	Then icon color for device with key in config "test3_unit_id" should be changed to "violet" (b2c)
	And device with key in config "test3_unit_id" should have status "Plugged in" (b2c)
	When I remember charging and saving values for device with key in config "test3_unit_id" (b2c)
	And I send UDP package with status "Charging" to device with key in config "test3_unit_id"
	Then icon color for device with key in config "test3_unit_id" should be changed to "green" (b2c)
	And device with key in config "test3_unit_id" should have status "Charging" (b2c)
	And energy and savings for device with key in config "test3_unit_id" should grow (b2c)
	Then I send UDP package with status "Standby" to device with key in config "test3_unit_id"

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_06 - JuiceNet Device Settings and Savings Parameters
	Given  I login to the system as "WebUser" (b2c)
	When I click More Details for device with key in config "test3_unit_id" (b2c)
	And I click on tab with label "Settings" (b2c)
	When I populate the JuiceNet Device Settings form with "initial_JDS" data (b2c)
	And I click on the Update button for pannel with Id "panelSettings" (b2c)
	Then JuiceNet Device Settings form fields values should be equal to "initial_JDS" data (b2c)
	When I populate the JuiceNet Device Settings form with "updated_JDS" data (b2c)
	And I click on the Update button for pannel with Id "panelSettings" (b2c)
	Then JuiceNet Device Settings form fields values should be equal to "updated_JDS" data (b2c)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_07 - JuiceNet Device Settings. Empty Zip code
	Given  I login to the system as "WebUser" (b2c)
	When I click More Details for device with key in config "test3_unit_id" (b2c)
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
Scenario: B2C_Web_MyJuiceNet_08 - Time-of-Use (TOU)
	Given I login to the system as "WebUser" (b2c)
	When I click More Details for device with key in config "test3_unit_id" (b2c)
	And I click on tab with label "Settings" (b2c)
	Given switch with Id "toggleTOU" is not activated (b2c)
	And field with Id "MinChargeKWh" is equal to "0.0" (b2c)
	When I click on switch with Id "toggleTOU" (b2c)
	Then switch with Id "toggleTOU" should be enabled is "True" (b2c)
	When I remeber the current time on device (b2c)
	And I set TOU time to "not current" (b2c)
	And I click on the Update button for pannel with Id "panelTOU" (b2c)
	And I refresh page (b2c)
	And I click on tab with label "Settings" (b2c)
	Then TOU time should be equal to "not current" (b2c)
	When I click on tab with label "Status" (b2c)
	And I send UDP package with status "Standby" to device with key in config "test3_unit_id"
	Then UDP response should contain "A00"
	And device should cheange status to "Available" (b2c)
	When I send UDP package with status "Connected" to device with key in config "test3_unit_id"
	Then UDP response should contain "A00"
	And device should cheange status to "Plugged In" (b2c)
	When I click on the override switch (b2c)
	And I send UDP package with status "Connected" to device with key in config "test3_unit_id"
	Then UDP response should contain amperage higher than "00"
	Then I send UDP package with status "Charging" to device with key in config "test3_unit_id"
	And device should cheange status to "Charging" (b2c)
	When I click on the override switch (b2c)
	And I send UDP package with status "Connected" to device with key in config "test3_unit_id"
	Then UDP response should contain "A00"
	Then I send UDP package with status "Connected" to device with key in config "test3_unit_id"
	And device should cheange status to "Plugged In" (b2c)
	When I click on tab with label "Settings" (b2c)
	And I set TOU time to "current" (b2c)
	And I click on the Update button for pannel with Id "panelTOU" (b2c)
	And I click on tab with label "Status" (b2c)
	And I send UDP package with status "Connected" to device with key in config "test3_unit_id"
	Then UDP response should contain amperage higher than "00"
	Then I send UDP package with status "Charging" to device with key in config "test3_unit_id"
	And device should cheange status to "Charging" (b2c)
	When I click on tab with label "Settings" (b2c)
	And I click on switch with Id "toggleTOU" (b2c)
	And I click on the Update button for pannel with Id "panelTOU" (b2c)
	Then switch with Id "toggleTOU" should be enabled is "False" (b2c)
	And I send UDP package with status "Standby" to device with key in config "test3_unit_id"

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_09 - TOU Persistence
	#Given I login to the system as "WebUser" (b2c)
	#When I click More Details for device with key in config "test3_unit_id" (b2c)
	#And I click on tab with label "Settings" (b2c)
	#Given switch with Id "toggleTOU" is not activated (b2c)
	#When I click on swith with Id "toggleTOU" (b2c)
	#Then switch with Id "toggleTOU" should be enabled is "True" (b2c)
	#When I remeber the current time on device (b2c)
	#And I set TOU time to "not current" (b2c)
	#And I click on the Update button for pannel with Id "panelTOU" (b2c)
	#And I refresh page (b2c)
	#And I click on tab with label "Settings" (b2c)
	#Then TOU time should be equal to "not current" (b2c)

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

#@b2c 
#Scenario: B2C_Web_MyJuiceNet Test
	#Then I send UDP package with status "Connected" to unit "373709011"
	#Then I send UDP package with status "Standby" to unit "373709011"
	#Then I send UDP package with status "Charging" to unit "373709011"
	#Given I send udp package "373709011:V2284,L123,S0,T51,E0,i0,e0,t10,f5915,m40:"
	#Given I send udp package "373709011:V2329,L123,S1,T23,E0,i5,e0,t3,f6146,m60:"
	#Given I send udp package "373709011:V2289,L123,S1,T49,E0,i18,e0,t3,f6125,m60:"



@b2c @web
Scenario: B2C_Web_MyJuiceNet_10 - Minimal charge. Charging starts before TOU start time.
	Given I login to the system as "WebUser" (b2c)
	When I click More Details for device with key in config "test3_unit_id" (b2c)
	And I click on tab with label "Settings" (b2c)
	Given switch with Id "toggleTOU" is not activated (b2c)
	And field with Id "MinChargeKWh" is equal to "0.0" (b2c)
	When I set field "MinChargeKWh" to "10" (b2c)
	And I click on switch with Id "toggleTOU" (b2c)
	Then switch with Id "toggleTOU" should be enabled is "True" (b2c)
	When I remeber the current time on device (b2c)
	And I set TOU time to "not current" (b2c)
	And I click on the Update button for pannel with Id "panelTOU" (b2c)
	And I refresh page (b2c)
	And I click on tab with label "Settings" (b2c)
	Then TOU time should be equal to "not current" (b2c)
	When I click on tab with label "Status" (b2c)
	When I send UDP package with status "Connected" to device with key in config "test3_unit_id"
	Then UDP response should contain amperage higher than "00"
	Then I send UDP package with status "Charging" to device with key in config "test3_unit_id"
	And device should cheange status to "Charging" (b2c)
	When I click on tab with label "Settings" (b2c)
	And I set field "MinChargeKWh" to "0.0" (b2c)
	And I click on the Update button for pannel with Id "panelTOU" (b2c)
	And I refresh page (b2c)
	And I click on tab with label "Settings" (b2c)
	Then field with Id "MinChargeKWh" should be equal to "0.0" (b2c)
	When I click on tab with label "Status" (b2c)
	And I send UDP package with status "Connected" to device with key in config "test3_unit_id"
	Then UDP response should contain "A00"
	And device should cheange status to "Plugged In" (b2c)

	#it looks like previous test cover this funtionality
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
	Given I login to the system as "WebUser" (b2c)
	And I navigate to the "Load groups" page (b2c)
	Given load group table is empty (b2c)
	When I click on button with name "New Load Group" (b2c)
	And I set field with Id "lg-add-modal-group-name" to "TestGroup1" (b2c)
	And I click on button with name "Save" (b2c)
	Then Alert with status "success" and text "Load Group TestGroup1 created sucessfully" should be displayed (b2c)
	When I click on button with name "Close" (b2c)
	Then Load group with name "TestGroup1" should apear in the table is "true" (b2c)
	When I click on button with name "New Load Group" (b2c)
	And I set field with Id "lg-add-modal-group-name" to "TestGroup2" (b2c)
	And I click on button with name "Save" (b2c)
	Then Alert with status "error" and text "User already has one empty load group" should be displayed (b2c)
	When I click on button with name "Close" (b2c)
	Then Load group with name "TestGroup2" should apear in the table is "false" (b2c)
	When I click "edit" button for load group "TestGroup1" (b2c)
	And I set field with Id "lg-add-modal-group-name" to "TestGroup2" (b2c)
	And I set field with Id "lg-add-modal-max-current" to "5" (b2c)
	And I click on button with name "Save" (b2c)
	Then Alert with status "success" and text "Load Group TestGroup2 modified successfully" should be displayed (b2c)
	When I click on button with name "Close" (b2c)
	Then Load group with name "TestGroup2" should apear in the table is "true" (b2c)
	#Probably we have to check maximum current, or maybe it should be another test
	When I click "delete" button for load group "TestGroup2" (b2c)
	Then Alert with status "" and text "Are you sure you want delete the group TestGroup2 ?" should be displayed (b2c)
	When I click on button with name "Delete LoadGroup" (b2c)
	And I click on button with name "Close" (b2c)
	Then Load group table should be empty (b2c)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_14 - Add devices to Load group.
	Given JuiceNet device is not added (b2c)
	And I login to the system as "WebUser" (b2c)
	And I navigate to the "Load groups" page (b2c)
	Given load group table is empty (b2c)
	When I click on button with name "New Load Group" (b2c)
	And I set field with Id "lg-add-modal-group-name" to "TestGroup14" (b2c)
	And I click on button with name "Save" (b2c)
	Then Alert with status "success" and text "Load Group TestGroup14 created sucessfully" should be displayed (b2c)
	When I click on button with name "Close" (b2c)
	Then Load group with name "TestGroup14" should apear in the table is "true" (b2c)

	Given I click on empty Load group with name "TestGroup14" string in table (b2c)
	When I select multiple keys from config "<ConfigKey>" on selector with Id "user-device-list" (b2c)
		| ConfigKey     |
		| test3_unit_id |
		| test4_unit_id |
	And I click on button with name "Add selected JNDevices to Load Group" (b2c)
	#Then Alert with status "success" and text "This devices were added successfully:" should be displayed (b2c)
	When I click on button with name "Close" (b2c)
	Then I check load group "TestGroup14" for "2" units in table (b2c)
	And I navigate to the "My JuiceNet Devices" page (b2c)
	Then Device with key in config "test3_unit_id" area contain load group icon (b2c)
	And Device with key in config "test3_unit_id" area contain load group icon (b2c)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_15a - Notifications Charging start/stop
#	Then I send UDP package with status "Standby" to device with key in config "test3_unit_id"
#
#	Given I login to the system as "WebUser" (b2c)
#	When I click More Details for device with key in config "test3_unit_id" (b2c)
#	Given all checkboxes on panel with Id "panelNotify" is not activated (b2c)
#	When I click all checkboxes on panel with Id "panelNotify" (b2c)
#	When I click on button with Id "saveNotificationsButton" (b2c)
#	Then all checkboxes on panel with Id "panelNotify" should be activated (b2c)
#	Then I click on tab with label "Settings" (b2c)
#	Given switch with Id "toggleTOU" is not activated (b2c)
#	When I click on switch with Id "toggleTOU" (b2c)
#	Then switch with Id "toggleTOU" should be enabled is "True" (b2c)
#	When I remeber the current time on device (b2c)
#	And I click on tab with label "Status" (b2c)
#	And I send UDP package with status "Charging" to device with key in config "test3_unit_id"
#	Then device should cheange status to "Charging" (b2c)
#
#	Given I login to the system as "Admin" (b2c)
#	And I navigate to the "Service Bus Events" page (b2c)
#	When I set field with Id "dateRangeStart" to "current" DateTime (b2c)
#	And I set field with Id "dateRangeEnd" to "currentPlusHour" DateTime (b2c)
#	And I click on button with Id "get-sb-events-button" (b2c)
#	Then event with the label "ChargingStarted" for the device with key in config "test3_unit_id" should contains text "charging started" (b2c)
#	And event with the label "NotificationCreated" for the device with key in config "test3_unit_id" should contains text "Email" (b2c)
#	And event with the label "NotificationCreated" for the device with key in config "test3_unit_id" should contains text "Push" (b2c)
#
#	Given I login to the system as "WebUser" (b2c)
#	When I click More Details for device with key in config "test3_unit_id" (b2c)
#	Then I click on tab with label "Settings" (b2c)
#	Given switch with Id "toggleTOU" is not activated (b2c)
#	When I click on switch with Id "toggleTOU" (b2c)
#	Then switch with Id "toggleTOU" should be enabled is "True" (b2c)
#	When I remeber the current time on device (b2c)
#	And I click on tab with label "Status" (b2c)
#	And I send UDP package with status "Connected" to device with key in config "test3_unit_id"
#	Then device should cheange status to "Plugged In" (b2c)
#
#	Given I login to the system as "Admin" (b2c)
#	And I navigate to the "Service Bus Events" page (b2c)
#	When I set field with Id "dateRangeStart" to "current" DateTime (b2c)
#	And I set field with Id "dateRangeEnd" to "currentPlusHour" DateTime (b2c)
#	And I click on button with Id "get-sb-events-button" (b2c)
#	Then event with the label "ChargingStoped" for the device with key in config "test3_unit_id" should contains text "charging stop" (b2c)
#	And event with the label "NotificationCreated" for the device with key in config "test3_unit_id" should contains text "Email" (b2c)
#	And event with the label "NotificationCreated" for the device with key in config "test3_unit_id" should contains text "Push" (b2c)
#
#	Then I send UDP package with status "Standby" to device with key in config "test3_unit_id"

@b2c @web
Scenario: B2C_Web_MyJuiceNet_15b - Notifications Charging delayed due to ToU

@b2c @web
Scenario: B2C_Web_MyJuiceNet_15c - Notifications Unit is offline/back online
#	Then event with the label "Online" for the device with key in config "test3_unit_id" should contains text "is online" (b2c)
#	And event with the label "NotificationCreated" for the device with key in config "test3_unit_id" should contains text "Email" (b2c)
#	And event with the label "NotificationCreated" for the device with key in config "test3_unit_id" should contains text "Push" (b2c)
#
#	Then event with the label "Offline" for the device with key in config "test3_unit_id" should contains text "goes offline" (b2c)
#	And event with the label "NotificationCreated" for the device with key in config "test3_unit_id" should contains text "Email" (b2c)
#	And event with the label "NotificationCreated" for the device with key in config "test3_unit_id" should contains text "Push" (b2c)

@b2c @web
Scenario: B2C_Web_MyJuiceNet_15d - Notifications Unit is not plugged in by
#	Given I login to the system as "WebUser" (b2c)
#	When I click More Details for device with key in config "test5_unit_id" (b2c)
#	Then I click on tab with label "Settings" (b2c)
#	Given switch with Id "toggleTOU" is not activated (b2c)
#	When I click on switch with Id "toggleTOU" (b2c)
#	Then switch with Id "toggleTOU" should be enabled is "True" (b2c)
#	When I remeber the current time on device (b2c)
#	And I click on tab with label "Status" (b2c)
#	Given all checkboxes on panel with Id "panelNotify" is not activated (b2c)
#	When I click all checkboxes on panel with Id "panelNotify" (b2c)
#	And I click on button with Id "saveNotificationsButton" (b2c)
#	Then all checkboxes on panel with Id "panelNotify" should be activated (b2c)
#	When I click on button with Id "settings-button-is_not_plugged_in_by" (b2c)
#	And I set field with Id "NotPluggedDateTime" to current time (b2c)
#	And I click on button with Id "saveExtendedSettingsButton" (b2c)
#	And I close current modal window (b2c)
#	And I click on button with Id "saveNotificationsButton" (b2c)
#	Given I wait for "60" seconds (b2c)
#
#	Given I login to the system as "Admin" (b2c)
#	And I navigate to the "Service Bus Events" page (b2c)
#	When I set field with Id "dateRangeStart" to "current" DateTime (b2c)
#	And I set field with Id "dateRangeEnd" to "currentPlusHour" DateTime (b2c)
#	And I click on button with Id "get-sb-events-button" (b2c)
#	Then event with the label "NotPluggedBy" for the device with key in config "test5_unit_id" should contains text "not plugged by" (b2c)
#	And event with the label "NotificationCreated" for the device with key in config "test5_unit_id" should contains text "Email" (b2c)
#	And event with the label "NotificationCreated" for the device with key in config "test5_unit_id" should contains text "Push" (b2c)


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

#Uncomment when fix
#@b2c @web 
#Scenario: B2C_Web_MyJuiceNet_17 - Load group balancing 
#	Given I login to the system as "WebUser" (b2c)
#	And I navigate to the "Load groups" page (b2c)
#	Given load group table is empty (b2c)
#	When I click on button with name "New Load Group" (b2c)
#	And I set field with Id "lg-add-modal-group-name" to "TestGroupZ" (b2c)
#	And I set field with Id "lg-add-modal-max-current" to "50" (b2c)
#	And I click on button with name "Save" (b2c)
#	Then Alert with status "success" and text "Load Group TestGroupZ created sucessfully" should be displayed (b2c)
#	When I click on button with name "Close" (b2c)
#	Then Load group with name "TestGroupZ" should apear in the table is "true" (b2c)
#	When I click on empty Load group with name "TestGroupZ" string in table (b2c)
#	And I select key from config "test4_unit_id" on selector with Id "user-device-list" (b2c)
#	And I click on button with name "Add selected JNDevices to Load Group" (b2c)
#	And I click on button with name "Close" (b2c)
#	Then sum of the Current Limit for all devices should be lower then "50" (b2c)
#
#	When I navigate to the "My JuiceNet Devices" page (b2c)
#	And I click More Details for device with key in config "test2_unit_id" (b2c)
#	And I click on tab with label "Settings" (b2c)
#	Given switch with Id "toggleTOU" is not activated (b2c)
#	When I click on tab with label "Status" (b2c)
#	And I send UDP package with status "Standby" to device with key in config "test2_unit_id"
#	Then device should cheange status to "Available" (b2c)
#	And I navigate to the "Load groups" page (b2c)
#	When I click on empty Load group with name "TestGroupZ" string in table (b2c)
#	And I select key from config "test2_unit_id" on selector with Id "user-device-list" (b2c)
#	And I click on button with name "Add selected JNDevices to Load Group" (b2c)
#	And I click on button with name "Close" (b2c)
#	Then sum of the Current Limit for all devices should be lower then "50" (b2c)
#
#	When I navigate to the "My JuiceNet Devices" page (b2c)
#	And I click More Details for device with key in config "test3_unit_id" (b2c)
#	And I click on tab with label "Settings" (b2c)
#	Given switch with Id "toggleTOU" is not activated (b2c)
#	When I click on tab with label "Status" (b2c)
#	And I send UDP package with status "Charging" to device with key in config "test3_unit_id"
#	Then device should cheange status to "Charging" (b2c)
#	And I navigate to the "Load groups" page (b2c)
#	When I click on empty Load group with name "TestGroupZ" string in table (b2c)
#	And I select key from config "test3_unit_id" on selector with Id "user-device-list" (b2c)
#	And I click on button with name "Add selected JNDevices to Load Group" (b2c)
#	And I click on button with name "Close" (b2c)
#	Then sum of the Current Limit for all devices should be lower then "50" (b2c)
#
#	When I click "delete" button for load group "TestGroupZ" (b2c)
#	Then Alert with status "" and text "Are you sure you want delete the group TestGroupZ ?" should be displayed (b2c)
#	When I click on button with name "Delete LoadGroup" (b2c)
#	And I click on button with name "Close" (b2c)
#	Then Load group table should be empty (b2c)
#	And I send UDP package with status "Standby" to device with key in config "test2_unit_id"
#	And I send UDP package with status "Standby" to device with key in config "test3_unit_id"
#
#
#@b2c @web 
#Scenario: B2C_Web_MyJuiceNet_18 - Get shared pin
#	Given I login to the system as "WebUser" (b2c)
#	When I switch view to "list" (b2c)
#	And I click pair to "Guest Pin" button for device with key in config "test4_unit_id" (b2c)
#	Then Modal with Id "request-share-pin-modal" should be displayed (b2c)
#	And Modal with Id "request-share-pin-modal" should contain title "JuiceNet Device Pairing Pin Code" (b2c)
#	And field with Id "request-share-pin-modal" should be equal to value from config "test4_unit_id" (b2c)
#	And field with Id "request-share-pin-modal-pincode" should contains "4" symbols (b2c)
#	When I close current modal window (b2c)
#	And I switch view to "grid" (b2c)
#	And I click pair to "Guest Pin" button for device with key in config "test4_unit_id" (b2c)
#	Then Modal with Id "request-share-pin-modal" should be displayed (b2c)
#	And Modal with Id "request-share-pin-modal" should contain title "JuiceNet Device Pairing Pin Code" (b2c)
#	And field with Id "request-share-pin-modal" should be equal to value from config "test4_unit_id" (b2c)
#	And field with Id "request-share-pin-modal-pincode" should contains "4" symbols (b2c)
#	And I remember Guest pairing pin (b2c)
#
#	Given I login to the system as "Admin" (b2c)
#	Given I delete device with key in config "test4_unit_id" via UI if added (b2c)
#	When I click on button with name "Add JuiceNet Device" (b2c)
#	When I set field "inputUnitID" to "test4_unit_id" from config (b2c)
#	And I click on button with name "Add JuiceNet Device" (b2c)
#	Then Modal with Id "share-pin-modal" should be displayed (b2c)
#	And Modal with Id "share-pin-modal" should contain title "JuiceNet Device Sharing PIN Required" (b2c)
#	And field with Id "unit-share-unitid" should be equal to value from config "test4_unit_id" (b2c)
#	When I set previously remembered Guest pairing pin (b2c)
#	And I click on button with name "Share JuiceNet Device" (b2c)
#	Then Modal with Id "unit-added-modal" should be displayed (b2c)
#	And Modal with Id "unit-added-modal" should contain title "Success" (b2c)
#	When I close current modal window (b2c)
#	Then JuiceNet device with key in config "test4_unit_id" should exist is "True" (b2c)
#	Given I delete device with key in config "test4_unit_id" via UI if added (b2c)

@b2c @web 
Scenario: B2C_Web_MyJuiceNet_19 - CO2
#	Проверяем, что на дашборде в хистори по юниту отображаются две колонки:
#EV CO2
#JN Green CO2
#Колонки должны отображаться только, если у юнита грин полиси
#Проверяем, что на дашборде значения EV CO2
#JN Green CO2 записываются только по окончанию длинной сессии (При текущем чардже - стоит прочерк)
#Проверяем, что расчет энергии происходит “на лету” и не пересчитывается в дальнейшем
#Проверяем, что при смене BA рассчет будет новый при новой сессии
#Проверяем расчет энергии по сессии в БД PendingSessionCalculations и jb_session и jb_unit
#Проверка определения BA автоматической службой ip2location
#Проверка определения BA если задать координаты руками через дашборд
#Проверка определения BA если задать координаты в базе данных
#Проверка работы BA для NY CA BY default (caiso)
#Проверка смены BA если координаты удаляются
#Проверка работы CO2 через API
#Проверка отсутсвия “ошибки”, если координаты не валидны
#Проверка отказоустойчивости при многочисленных юнитах
#Проверяем, что если сессия была без остановок, то экономия энергии = 0
#Проверяем, что данные на дашборде по цо2 совпадают с теми что в базе
#Проверяем, что если мы не сэкономили энергию, в дашборде отображается 0
