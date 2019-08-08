Feature: B2B Load Balancing feature
	In order to verify Load Balancing feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_LoadBalancing_01 - Set load balancing for location
	#Create location 
	#Go to locations settings - Configuration tab 
	#Enable Load balancing 
	#Set value > 2 kWh in Allowed Max Power - Click Update 
	#Go back to Location tab 
	#Explore that location has load balancing icon opposite the location that you've created
	#Go to locations settings - Configuration tab again
	#Explore that the value wich you assigned is peresent in Allowed Max Power field

@b2b @web
Scenario: B2B_Web_LoadBalancing_02 - Check two hints in Load balancing tab (next to “Load Balancing”, and “Allowed max power (kW) for this location”)
	 #Create location 
	 #Add two devices and link them to this location
	 #Go to locations settings - Configuration tab   
	 #Check Hint next to “Load Balancing”
	 #“By enabling Load Balancing, the maximum power will be balanced between all the charging stations under location/sublocation. Regardless of how many charging stations are added at this location and how many cars are charging at the same time, it will never be pushed more power than the total set power limit per location/sublocation.” http://prntscr.com/kl9c34 
	 #Enable Load balancing  
	 #Check hint next to “Allowed max power (kW) for this location”
	 #Hint must contain suggestion calculated based on the amount of charging stations: “The minimum value can be a number of stations * 2kW.” In our case it must be 4 kW (2 devices connected) 

@b2b @web
Scenario: B2B_Web_LoadBalancing_03 - Device with load balancing assigned should be displaying with load balancing icon.
	#Create location 
	#Add two devices and link it to this location
	#Go to locations settings - Configuration tab   
	#Enable Load balancing   
	#Set value > 2 kWh in Allowed Max Power - Click Update  
	#Go to Device tab 
	#Explore that both devices are displayed with load balancing icon http://prntscr.com/kl9ihd

@b2b @web
Scenario: B2B_Web_LoadBalancing_04 - User cannot type anything except digits and dot in “Allowed max power (kW) for this location” field
	#Create location
	#Go to locations settings - Configuration tab 
	#Enable Load balancing
	#Check the Allowed Max Power(kW) filed
	#Check that only digits and dots are acceptable to enter to this field 

@b2b @web
Scenario: B2B_Web_LoadBalancing_05 - Check that error “Required” under “Allowed max power (kW) for this location” is appears
	#Create location 
	#Go to locations settings - Configuration tab 
	#Enable Load balancing 
	#Click on Allower max power field 
	#Explore that you get an error “Required” under “Allowed max power” field if you type less than 1 digit

@b2b @web
Scenario: B2B_Web_LoadBalancing_06 - Check autocorrection if user enter value that less 2 kwh
	#Create location 
	#Add device and link it to this location
	#Go to locations settings - Configuration tab 
	#Enable Load balancing  
	#Type value "1" in Allowe max power filed and click Update button
	#Explore that value 2 is saved ("Min is 2kW for Company/Location with one device. If user types the value less than 2, autocorrect to 2 when save company/location/sublocation.")
	#http://prntscr.com/kl9w2a 

@b2b @web
Scenario: B2B_Web_LoadBalancing_07 - Check warning when user set 2 Kwh in Allowed power tab and more than two devices connected to this location
	#Create location 
	#Add two devices and link them to this location
	#Go to locations settings - Configuration tab  - Enable Load balancing   
	#Set value two in Allowed max power filed 
	#Explore message upon save “This group has more than one device. The value entered is too low to charge multiple devices at the same time. The minimum value can be a number of stations * 2kW.” In our case value - 4 should be displayed 
	#If user setup the kW less than chargers needed to charge at least 1 EV without possibly charging stopped by EV charger because of not reliable power source.
	#http://prntscr.com/kl9xyj

@b2b @web
Scenario: B2B_Web_LoadBalancing_08 - Verify that only 4 digits are acceptable to enter in Allowed power field
	#Create location
	#Go to locations settings - Configuration tab  - Enable Load balancing   
	#Check that only 4 digits are acceptable to enter in Allowed power field (4 digits and one dot)
	#http://prntscr.com/kl9zbx

@b2b @web
Scenario: B2B_Web_LoadBalancing_09 - User must see that device is in load group in device settings
	#Create location 
	#Add device and link it this location
	#Go to device settings 
	#Explore that this device contains load balancing icon near the device number/name(http://prntscr.com/kqy5yy)

@b2b @web
Scenario: B2B_Web_LoadBalancing_10 - Check notification when energy hits the maximum load balancing value - Not developed yet
	#Create location 
	#Add device link it to location 
	#Go to locations settings - Configuration tab  - Enable Load balancing    
	#Set value 3 (as example) in Allowed max power field 
	#Go to device, made plug-in, start charging session 
	#Wait until Current energy has more kWh that you setted (3 kWh) 
	#Explore that admin receive notification "Location <Name> hits the max value of Watts usage [Value]” 

@b2b @web
Scenario: B2B_Web_LoadBalancing_11 - Test LB with two devices (free and not free rate)
	#Create location, go to Settigs - Configuration tab, enable LB and set kW value to 4 kW
	#Add two devices with free rate link it to location 
	#Start charging sessions on both devices 
	#Go to Reports - Load balancing 
	#Explore that Load balance usage value in range of 70-90%
	#Stop charging session
	#Go to Rates, add not free rate, link it to both devices 
	#Start charging sessions on both devices  
	#Go to Reports - Load balancing  
	#Explore that Load balance usage value in range of 70-90% 
	#Stop charging session 

@b2b @web
Scenario: B2B_Web_LoadBalancing_12 - Test LB with Sublocation
	#Create location, set LB 6 kW for it 
	#Create Sublocation for this Location 
	#Add two devices, one link to Location another to Sublocation 
	#Start charging both devices 
	#Go to Reports - Load balancing 
	#Explore that power is devided correctly between those devices. This means that device in location and device in sublocation must run with approximately with 3kW (6 kW/2 devices) 

@b2b @web
Scenario: B2B_Web_LoadBalancing_13 - Case when device is can't start charging because of load balancing restrictions
	#Create location, go to settings, set LB value 5 kW 
	#Add 3 devices, link them to location 
	#Start charging sessions on both devices 
	#Go to Reports - LB , explore that both devices are charging, and power is devided correctly
	#Start charging third device 
	#Explore that your devices isn't charging, because there is not enough power to charge third device

@b2b @web
Scenario: B2B_Web_LoadBalancing_14 - Link device from one LB group to another
	#Create location, enable LB, set 5 kW value 
	#Add two devices, link them to location
	#Start charging session on both devices 
	#Go to Reports - LB, explore that power is devided correctly 
	#Finish charging sessions 
	#Create secon location, enable LB, set 5 kW value 
	#Unlink two devices from first location, and link them to second one 
	#Start charging session on both devices  
	#Go to Reports - LB, explore that power is devided correctly  
	#Create location, without LB value 
	#Link those devices to it 
	#Both must consume max power value 

@b2b @web
Scenario: B2B_Web_LoadBalancing_15 - Plugged in device must reserve 8A of Allowed Power
	#Create location, two devices, link both to location 
	#Set Lb value of location to 5 kW(as example)
	#Turn Public Access off for first device 
	#Plug in first device
	#Charging session isn't start 
	#Start charging session on second device 
	#Charging on second device is started 
	#Go to LB reports 
	#8A is reserved(~60% of max power kW LB value)
	#Turn Public Access back on for first device 
	#Plug in first device 
	#Charging start
	#Uncheck Power Draw checkbox in emulator for first device 
	#Charging stopped, first device is in Plug in status 
	#Go to LB reports 
	#8A is reserved(~60% of max power kW LB value) 

@b2b @web
Scenario: B2B_Web_LoadBalancing_16 - Set LB fo sublocation
	#Create two Sublocations
	#Go to first sublocation set Load balancing value first, after add two devices and start charging them
	#Explore that power is devided correctly between those devices. ) 
	#Go to second sublocation add two devices then set Load balancing value, after start charging them
	#Explore that power is devided correctly between those devices. ) 