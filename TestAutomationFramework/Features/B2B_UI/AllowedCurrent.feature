Feature: B2B Allowed Current feature
	In order to verify Allowed Current feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_AllowedCurrent_01 - Change Allowed Current on device
	#Go to Device settings 
	#Start the charge 
	#In setting tab change the Allowed Current for any number > 6
	#The value in State tab (A) is changed to new value 

@b2b @web
Scenario: B2B_Web_AllowedCurrent_02 - Set Allowed Current for Location
	#Create Location 
	#Go to Detail tab, and change Allowed Current value in Configuration window (to value > 6)
	#Update button will appear, after clicking on it value is applied

@b2b @web
Scenario: B2B_Web_AllowedCurrent_03 - Same as Parent functionality when link device to Location
	#Create a Location and set the Allowed Current value to it 
	#Go to Manage Device and add the device 
	#Link this device to Location that you've created, click Move to Location
	#Allowed Current value is the same that you set in the location and checkbox "same as parent" is active
	#Click on Same as parent check box 
	#You'll see Update button
	#Change the value of Allowed Current and click save 
	#You value is changed and checkbox "same as parent" is not active

@b2b @web
Scenario: B2B_Web_AllowedCurrent_04 - Same as Parent functionality for sublocation
	#Create Location and set  Allowed Current value to it 
	#Create Sublocation 
	#Explore that Allowed Current value is the same as the parent Location  
	#Change a value of Allowed Current and remove Same as parent checkbox, than click Update button 
	#New value is displayed

@b2b @web
Scenario: B2B_Web_AllowedCurrent_05 - Check the boarding value 6
	#Add device 
	#Start to charge it 
	#Change allowed current to value < 6 
	#Device status changed to Plugged-in
	#Change allowed current to value > 6
	#Device status changed to Charging