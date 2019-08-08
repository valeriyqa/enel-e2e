Feature: B2B Admin Of Reseller feature
	In order to verify Admin Of Reseller feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_AdminOfReseller_01 - Checking the dashboard elements
	#Checking Left Menu
	#Dashboard, Manage Devices, Manage Users, Locations, Groups, Reports, Help http://prntscr.com/ie7cbj
	#Checking dashboard elements 
	#Company name, Go back to reseller link, "Plus" button, Search field, User icon, Filter section, Devices, Locations, Total Consumption, Active JuiceNet Devices, Users, Locations(map) http://prntscr.com/ie9ex2

@b2b @web
Scenario: B2B_Web_AdminOfReseller_02 - Manage Groups - Add User Group
	#Go to Groups page
	#http://prntscr.com/ifhtly
	#Click Add User Group 
	#Group Name field is appears http://prntscr.com/ifhufm
	#Fill the Group Name form, and click Create button
	#You'll be redirected to Groups Page, check that your Group is created 

@b2b @web
Scenario: B2B_Web_AdminOfReseller_03 - Manage Groups - Delete User Group
	#Preconditions: at least one Group need to be created
	#Go to Groups page
	#http://prntscr.com/ifhtly
	#Click on icon to Delete group
	#Pop up window is shown http://prntscr.com/ifi4f9
	#Click on Remove button
	#Check that group is removed
