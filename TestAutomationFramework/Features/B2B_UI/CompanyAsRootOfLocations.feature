Feature: B2B Company As Root Of Locations feature
	In order to verify Company As Root Of Locations feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_CompanyAsRootOfLocations_01 - Check company as root functionality
	#Create new reseller 
	#Login as reseller and create new client
	#Login as client, go to Locations tab 
	#Explore that you have your company in the list 
	#Create new location, inherit all values from parent(you company) 
	#Go to newly created location, check that all values are inherited correctly 

@b2b @web
Scenario: B2B_Web_CompanyAsRootOfLocations_02 - Company as root UI check
	#Create new reseller  
	#Login as reseller and create new client 
	#Login as client, go to Locations tab 
	#Explore that you have your company in the list, click on it
	#The company root screen should look like this - http://prntscr.com/kmhpsc 
	#Top line -> Company: Ryder  (no JBoxes can be added, no need to show buttons (add/delete)
	#Details/Drivers/Permissions  -> all same, should not have <same as parent> as no parent above 

@b2b @web
Scenario: B2B_Web_CompanyAsRootOfLocations_03 - Check that company is correctly displayed in Locations tab
	#Create new reseller
	#Login as reseller and create new client 
	#Login as client, go to Locations tab 
	#Explore that company is present
	#Create location, add device, link it to Location
	#Go back to Locations tab 
	#Check that company, location, and device are displaying correctly  
	#http://prntscr.com/kmhqtf