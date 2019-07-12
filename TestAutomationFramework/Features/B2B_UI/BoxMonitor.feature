Feature: B2B Box Monitor feature
	In order to verify B2B Box Monitor feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_BoxMonitor_01 - Device get offline status if not active for 10 minutes
	#Add new device 
	#If device isn't responding for 5 minutes(not sending packets to listener) it must change to offline satus 

@b2b @web
Scenario: B2B_Web_BoxMonitor_02 - Reservation for charging
	#Add new device 
	#Don't turn Plugger in and Power settings in the emulator 
	#Click Charge button 
	#Charging started(Reserved)
	#Within 5 minutes, click to Charge this device from another account 
	#Warning appears, that device is reserved, or you don't have permissions
	#After 5 minutes, click Charge from another 
	#Charging started(Reserved)
