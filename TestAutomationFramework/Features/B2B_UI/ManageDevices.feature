Feature: B2B Manage Devices feature
	In order to verify Manage Devices feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_ManageDevices_01 - Add Device(Valid ID)
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
@b2b @web
Scenario: B2B_Web_ManageDevices_02 - Add Device(Already added Unit ID)
#	Given I login to the system as "Web user" (b2b)
#	And I navigate to the "Devices" page (b2b)
#	When I click on the "Add Device" button (b2b)
#	And I set input "physicalId" to the value "373708001" (b2b)
#	And I click on the "Create" button (b2b)
#	Then Popup window with "This Device '373708001' is used by other account." message and "error" status should be displayed (b2b)

@b2b @web
Scenario: B2B_Web_ManageDevices_03 - Add Device(Incorrect Unit ID)
	#Go to Manage Devices page
	#Click on Add Device button 
	#Add New Device tab appears(Step1/2) 
	#Fill the Device name, ! Incorrect ! Device ID, assign your Device to Location
	#Enter data to Adress/Coordinates fileds 
	#Click Next button
	#Add New Device tab appears(Step2/2)
	#Set Max allowed current for this device, leave free rate assigned
	#Click Done button  
	#"No device found with this ID" - Error

@b2b @web
Scenario: B2B_Web_ManageDevices_04 - Add device to Sublocation 
	#Preconditions: You need to create location and sublocation to link your device to it  
	#Go to Manage Devices page
	#Click on Add Device button 
	#Add New Device tab appears(Step1/2)
	#Fill the Device name, Device ID, assign your Device to Sublocation
	#(first choose your Location from the list, then choose you Sublocation )
	#Enter data to Adress/Coordinates fileds 
	#Click Next button
	#Add New Device tab appears(Step2/2)
	#Set Max allowed current for this device, leave free rate assigned
	#Click Done button 
	#Pop up window is displayed, click View devices
	#Go to Locations page and check that your Device is linked to particular Sublocation

@b2b @web
Scenario: B2B_Web_ManageDevices_05 - Charging
	#Preconditions: you need to add a Device with free rate and public access should be turned on
	#Go to Devices tab 
	#Click on Device name  that you created to enter Device settings 
	#Device settings tab is opened
	#Click on Charge button 
	#Charging started message is shown 
	#Click OK 
	#Explore that Charge button is grey, and Charging icon is displaying in the top left corner 
@b2b @web
Scenario: B2B_Web_ManageDevices_06 - Reset ownership
	#Preconditions: you need to add a Device and link it to Location
	#Go to Devices tab 
	#Click on Device name that you created to enter Device settings 
	#Device settings tab is opened 
	#Click Reset ownership button 
	#Confirmation pop up window displaying
	#Click Reset button
	#Devices tab is opened, and there is no device that you've been removed

@b2b @web
Scenario: B2B_Web_ManageDevices_07 - Add Device(Max allowed current = 0)
	#Preconditions: You need to create location to link your device to it  
	#Go to Manage Devices page
	#Click on Add Device button  
	#Add New Device tab appears(Step1/2)
	#Fill the Device name, Device ID, assign your Device to Location
	#Enter data to Adress/Coordinates fileds 
	#Click Next button
	#Add New Device tab appears(Step2/2) 
	#Leave Max allowed current = 0 for this device, leave free rate assigned
	#Click Done button 
	#"Set allowed current value more then 0 or inherit it from location" - Error 

@b2b @web
Scenario: B2B_Web_Managedevices_08 - Add Device(Inherit data from location)
	#Preconditions: You need to create location to link your device to it
	#Go to Manage Devices page
	#Click on Add Device button
	#Add New Device tab appears(Step1/2)
	#Fill the Device name, Device ID, assign your Device to Location
	#Accept checkbox Use Location Address and Coordinates
	#Add New Device tab appears(Step2/2) 
	#Address and Coordinates tabs disappear 
	#Accept checkbox Use Location configuration
	#Accept checkbox Use Location assigned rate
	#Max allowed current, Public Access, Assign Rate tabs disappear  
	#Pop up window is displayed, click View devices
	#Check that your Device appears in Devices tab and linked to proper Location 
	#and all inherited data (Location Address , Coordinates, Rate, Configuration) is the same that in Location tab

@b2b @web
Scenario: B2B_Web_Managedevices_09 - History tab
	#Preconditions: you need to add a Device with at least one finished charging session
	#Go to Devices tab 
	#Click on Device name  that you created to enter Device settings  
	#Click on History tab 
	#User see list of sessions