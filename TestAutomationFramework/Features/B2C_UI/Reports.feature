Feature: B2C Reports
	In order to verify Reports functionality
	we run next scenarios

@b2c @web
Scenario: B2C_Web_Reports_01 - Single unit report
#Login as user with 1 or more unints (they must have past charges)
#Navigate to Reports
#Enter User sessions
#Start date is a day week ago, End date is today
#Select one unit from dropdown list
#Change start date to previous month
#Change end date to next month
#Click Build buttom
#Confirm the data in a table with device history tab
#Data in tables is not different (1.01:20:22 = 1 day 1 hour 20 minutes 22 srconds)

@b2c @web
Scenario: B2C_Web_Reports_02 - All unit report
#Login as user with 2 or more unints(they must have past charges)
#Navigate to Reports
#Enter User sessions
#Start date is a day week ago, End date is today
#Select all units from dropdown list
#Change start date to previous month
#Change end date to next month
#Click Build buttom
#Confirm the data in a table with devices history tab
#Data in tables is not different (1.01:20:22 = 1 day 1 hour 20 minutes 22 srconds)
#Search one of the units by unit name(id)
#Confirm the data in a table with device history tab
#Data in tables is not different (1.01:20:22 = 1 day 1 hour 20 minutes 22 srconds)

@b2c @web
Scenario: B2C_Web_Reports_03 - Group by devices report
#Login as user with 2 or more unints (they must have past charges)
#Navigate to Reports
#Enter User sessions
#Start date is a day week ago, End date is today
#Select all units from dropdown list
#Change start date to previous month
#Change end date to next month
#Click Broup by Devices buttom
#Click Build buttom
#Confirm the data in a table with devices history tab
#Total data in tables is not different (1.01:20:22 = 1 day 1 hour 20 minutes 22 srconds)