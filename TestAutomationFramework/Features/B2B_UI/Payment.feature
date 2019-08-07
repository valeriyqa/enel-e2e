Feature: B2B Payment feature
	In order to verify Payment feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_Payment_01 - Add client

@b2b @web
Scenario: B2B_Web_Payment_02 -  Charging cases

@b2b @web
Scenario: B2B_Web_Payment_03 -  Stripe integration (positive cases)

@b2b @web
Scenario: B2B_Web_Payment_04 -  Stripe (negative cases)
	#Correct card number, correct CVC, incorrect expiration date  
	#Correct card number, incorrect CVC, correct expiration date  
	#Correct card number, incorrect CVC, incorrect expiration date  
	#If a CVC number is provided, the cvc_check fails. 4000000000000101  
	#Charge is declined with an incorrect_cvc code. 4000000000000127
	#Charge is declined with an expired_card code. 4000000000000069
	#Charge is declined with a processing_error code. 4000000000000119 
	#Charge is declined with an incorrect_number code as the card number fails the Luhn check. 4242424242424241 

@b2b @web
Scenario: B2B_Web_Payment_05 -  Check stripe warning while device is offline
	#Preconditions: you must have commercial device, and account linked to stripe 
	#Link device to location, set no free rate 
	#Go to emulator set device to offline status 
	#Device goes offline 
	#Try to authorise in stripe for this device(in mobile app or by payment link)
	#Warning that device is Currently Offline 