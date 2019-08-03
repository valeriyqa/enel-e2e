Feature: B2B Manage Users feature
	In order to verify Manage Users feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_ManageUsers_01 - Add new user(Admin)
	#Go to Users page
	#Manage Users page is opened 
	#Click on Add user button 
	#Add new User tab is opened 
	#Fill First, Last name, email, choose Admin role
	#Click Next button
	#Add new User tab is opened(step2) 
	#Skip assigniment to Group
	#Click Done button
	#User created successfully message appears, View Users, Create another user buttons  
	#Click View Users
	#Redirect back to Users page
	#Check your email, and click on Access your account button
	#Set up password page is opened
	#Fill Pwd and Confirm Pwd fields, click Reset button 
	#Congratulations page is opened
	#Click Log in here to return to Login page

@b2b @web
Scenario: B2B_Web_ManageUsers_02 - Update User's information
	#Go to Users page
	#Manage Users page is opened
	#Click on any Username in name list on Manage Users page 
	#User details page is opened
	#Update First Name and Last Name fields
	#Click on Edit icons, after editing, click Update button
	#Updated First and Last Name should be displayed 

@b2b @web
Scenario: B2B_Web_ManageUsers_03 - Add new user(Incorrect Email)
	Given I login to the system as "Web user" (b2b)
	When I navigate to the "Users" page (b2b)
	#And I click on the "Add User" button (b2b)
	#And I set input "First Name" to the value "Test user" (b2b)
	#And I set input "Last Name" to the value "Test user" (b2b)
	#And I set input "Email" to the value "Incorrect" (b2b)
	#And I select "{value}" on the Assign rate selector (b2b)
	#Fill First, Last name, email (Fill Email filed with incorrect credentials ), choose Admin role
	#Next button stays grey, and you see label tat "Email is invalid"

@b2b @web
Scenario: B2B_Web_ManageUsers_04 - Add existing user
	#Preconditions: You must have at least one user in system
	#Go to Users page
	#Manage Users page is opened 
	#Click on Add user button 
	#Add new User tab is opened  
	#Fill First, Last name, choose Admin role
	#Fill email of already existing user in email field 
	#Click Next button
	#Add new User tab is opened(step2) 
	#Skip assigniment to Group
	#Click Done button 
	#You see a warning "Looks like this user is already exist"
	#Click OK - you'll be redirected to Add new User tab 

@b2b @web
Scenario: B2B_Web_ManageUsers_05 - Assign/Remove user from group
	#Preconditions: You need to create a group
	#Go to Users page 
	#Manage Users page is opened
	#Click on Groups tab
	#Click on Assign to group button 
	#Pop up window with list of groups is shown
	#Click on checkbox to assign user to group
	#Click OK
	#Grop Name with number of Users and Devices is shown
	#Click on Remove icon
	#Warning message is shown, click Remove
	#Group was removed from the group list

@b2b @web 
Scenario: B2B_Web_ManageUsers_06 - Delete User
	#Go to Users page 
	#Manage Users page is opened
	#Click on any Username in name list on Manage Users page  
	#User details page is opened
	#Click on Delete user button in top right corner
	#Click Remove button 
	#Success message is shown
	#Click "View users" 
	#Verify that user is not present in Users list

@b2b @web 
Scenario: B2B_Web_ManageUsers_07 - Charging sessions tab
	#Preconditions: Following user must have at least one finished charging session 
	#Go to Users page 
	#Manage Users page is opened
	#Click on any Username in name list on Manage Users page  
	#User details page is opened
	#Click on Charging session tab
	#List with all sessions is displaying