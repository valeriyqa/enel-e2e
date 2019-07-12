Feature: B2B Mobile feature
	In order to verify Mobile feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_Mobile_01 - Change enviroment of mobile app
	#Go to settings, and check that you can access all enviroments 
	#PROD, BETA, ALPHA 

@b2b @web
Scenario: B2B_Web_Mobile_02 - Check that after 5 minutes reserved time for charging device ready too charge again
	#Go to Stations tab 
	#Click on Location 
	#Click on free device to charge 
	#Timer will shown 
	#Wait for 5 minutes 
	#Warning, that device is locked is shown, and button apeeras to reserve this device again

@b2b @web
Scenario: B2B_Web_Mobile_03 - Update rate details
	#Add device link it to location and rate 
	#Open it in mobile app 
	#Change rate in dashboard 
	#Changes accepted to charger info in mobile app 

@b2b @web
Scenario: B2B_Web_Mobile_04 - Update Location name
	#Add device with rate and link it to location 
	#Find and open this device in mobile app 
	#Change name of location in dashboard 
	#Name of location is changed in device tab in mobile app 

@b2b @web
Scenario: B2B_Web_Mobile_05 - Change name of device
	#Add  device with rate, link it to location 
	#Find and open this device in mobile app 
	#Change device name in dashboard 
	#Name of devices is changed in mobile app also 

@b2b @web
Scenario: B2B_Web_Mobile_06 - Add device to location, and sublocation
	#Add device 
	#Create one location, and one sublocation 
	#Link device to location 
	#Go to mobile app, explore, that device is linked to particular location 
	#Link device to sublocation 
	#Go to mobile app, explore, that device is linked to particular sublocation 

@b2b @web
Scenario: B2B_Web_Mobile_07 - Update Location destination
	#Add device, link it tolocation 
	#Open this device settings in mobile app 
	#Go to dashboard and change destination of  location
	#Changes appears on mobile app in device setting tab 

@b2b @web
Scenario: B2B_Web_Mobile_08 - Add location
	#Go to dashboard - locations tab 
	#Create new location 
	#Go to mobile app and check that location is added with "0/0" value in device value 

@b2b @web
Scenario: B2B_Web_Mobile_09 - About us tab
	#Go to About us tab in left menu 
	#Check the right version of app is displayed 
	#Check privacy policy link 
	#Check Terms&co link

@b2b @web
Scenario: B2B_Web_Mobile_10 - Feedback 
	#Go to About Us 
	#Click on Send us feedback 
	#Check that you can choose  feedback  or problem
	#Upload file , fill text form, click send
	#Success message

@b2b @web
Scenario: B2B_Web_Mobile_11 - Check warning that no device are linked to this location
	#Go to dashboard and add a location 
	#Open app, go to Stations tab 
	#Click on location that you recently added 
	#"Chargers coming soon at this location" 

@b2b @web
Scenario: B2B_Web_Mobile_12 - Check updating of device status
	#Go to dashboard, add location, add device, link device to location
	#Open mobile app go to location 
	#Go to emulator, and make device status offline 
	#Check that device status in app is updated to offline status
	#Go to emulator, and make device status standby 
	#Check that device status in app is updated to offline standby
	#Log in from anothe account to this reseller, and start charging
	#Explore, that device status is updated to charging in second account 
	#Go to first account, and explore Occupied status of previous device 

@b2b @web
Scenario: B2B_Web_Mobile_13 - Forgot password
	#Create new user
	#Go to mobile app, tap Forgot password, enter email 
	#Go to email, click the link, change password 
	#Password was changed 

@b2b @web
Scenario: B2B_Web_Mobile_14 - Distance switch
	#Start charging device from mobile app 
	#Go to Settings 
	#Click on distance value to change from km to miles 
	#Go to device settings screen, explore, that value was changing to miles 

@b2b @web
Scenario: B2B_Web_Mobile_15 - Charging history
	#Add device link it to location, and assign custom rate(not free) 
	#Start charging the device 
	#Finish charging session 
	#Go to Charging history tab, find yours last session, and compare  those  values with dasboard ones
	#Start time, ending time, location(destination), rate values, distance, device ID, total cost 

@b2b @web
Scenario: B2B_Web_Mobile_16 - Check that deleted user can't start charging\login
	#Create Driver, login to mobile app
	#Go to location - Device that you whant to charge
	#Log in to Dashboard as an Admin
	#Delete Driver, that you've created from system
	#Go back to mobile app, start charging device
	#Can't load device info error, and user can't go to locations tab back again
	#Try to login with deleted credentials to mobile app and dasboard
	#Can't login(user not registered)
