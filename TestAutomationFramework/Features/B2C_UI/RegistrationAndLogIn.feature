Feature: B2C Registration And LogIn Operations
	In order to verify Registration And LogIn functionality
	we run next scenarios

@b2c @web
Scenario: B2C_Web_Registration_and_Login_01 - Registration with email
	Given I navigate to "Account/Login" page (b2c)
	When I click on "Sign up now!" link (b2c)
	Then I should be navigated to the "Account/Register" page (b2c)
	When I set field "<FieldId>" to "<Value>" (b2c)
		| FieldId         | Value               |
		| Email           | example@example.com |
		| pwdinpuit       | Pa$$w0rd            |
		| ConfirmPassword | Pa$$w0rd            |
	Then field "<FieldId>" should be masked (b2c)
		| FieldId         |
		| pwdinpuit       |
		| ConfirmPassword |
	When I set field "Fullname" to "Vasia Pupkin" (b2c)
	#And I click on "buttonSubmit" button by Id
	And I confirm my email address (b2c)
	##And I click on "Please Click here to Log in" link
	#Then I should be logged into the application

#***Registration and Log In***
#**Registration with email**
#* Navigate to login page
#* Click on "Register new user with email" link
#  - User is navigated to registration page
#* Provide valid email
#* Provide valid password
#  - Password field should be masked
#* Confirm password
#  - Confirmation field should be masked
#* Input "Full name" field
#* Click on Register button
#  - User is navigated to "Confirmation Email Sent" page. "Check your email and confirm your account. Your email must be confirmed before you can log in." alert appears.
#* Click on "Confirm this email address" link from email
#  - User is navigated to "Confirm Email" page. "Thank you for confirming your email. Please Click here to Log in" alert appears with link to login page.
#* Click on "Please Click here to Log in" link
#  - User is navigated to Login page

@b2c @web
Scenario: B2C_Web_Registration_and_Login_02 - Registration via Twitter account**
#* Navigate to login page
#* Click on Twitter icon
#  - User is navigated to "Associate your Twitter account" page. "You've successfully authenticated with Twitter. Please enter a email for this site below and click the Register button to finish logging in."  alert appears.
#* Provide valid email
#* Click on Register button
#  - User is navigated to dashboard with successful login

@b2c @web
Scenario: B2C_Web_Registration_and_Login_03 - Registration via Facebook account**
#* Navigate to login page
#* Click on Facebook icon
#  - User is navigated to "Associate your Facebook account" page. "You've successfully authenticated with Facebook. Please enter a email for this site below and click the Register button to finish logging in."  alert appears.
#* Provide valid email
#* Click on Register button
#  - User is navigated to dashboard with successful login

@b2c @web
Scenario: B2C_Web_Registration_and_Login_04 - Registration via Google account**
#* Navigate to login page
#* Click on Google icon
#  - User is navigated to "Associate your Google account" page. "You've successfully authenticated with Google Please enter a email for this site below and click the Register button to finish logging in."  alert appears.
#* Provide valid email
#* Click on Register button
#  - User is navigated to dashboard with successful login

@b2c @web
Scenario: B2C_Web_Registration_and_Login_05 - Login with valid email and password
	#Given I login to the system as "WebUser" (b2c)
	#And I navigate to "Manage" page (b2c)
	#Then I should be logged into the application as "WebUser" (b2c)

@b2c @web
Scenario: B2C_Web_Registration_and_Login_06 - Login with unregistered email
	#Given I navigate to "Account/Login" page (b2c)
	#When I set field with Id "Email" to "891355577799@mail.ru" (b2c)
	#And I set field with Id "Password" to "0123456789" (b2c)
	#Then field "Password" should be masked (b2c)
	#When I click on button with name "Login" (b2c) 
	#Then Alert message "Oops! Please double-check your email and password." is displayed (b2c)

@b2c @web
Scenario: B2C_Web_Registration_and_Login_07 - Login with invalid password
	#Given I navigate to "Account/Login" page (b2c)
	#When I set field "<FieldId>" to "<Value>" (b2c)
	#	| FieldId         | Value               |
	#	| Email           | oleksii.khabarov@emotorwerks.com |
	#	| Password        | invalidPassword |
	#And I click on button with name "Login" (b2c)
	#Then Alert message "Oops! Please double-check your email and password." is displayed (b2c)

@b2c @web
Scenario: B2C_Web_Registration_and_Login_08 - Login with unconfirmed email**
	#Given I navigate to "Account/Login" page (b2c)
	#When I set field "<FieldId>" to "<Value>" (b2c)
	#	| FieldId         | Value               |
	#	| Email           | ksenia+unconfirmed@emotorwerks.com |
	#	| Password        | eMW2018 |
	#And I click on button with name "Login" (b2c)
	#Then panel with message "You must have a confirmed email to log on. The confirmation token has been resent to your email account." should be displayed (b2c)

@b2c @web
Scenario: B2C_Web_Registration_and_Login_09 - Set password after registration via Social account**
#* Navigate to login page
#* Login with social account
#  - User is navigated to dashboard with successful login
#* Navigate to User Profile
#* Click Create link near "Password"
#  - User is navigated to create password page
#* Provide valid password
#* Click "Set Password" button
#* User is navigated to User Profile

@b2c @web
Scenario: B2C_Web_Registration_and_Login_10 - User profile settings**
#* Login to dashboard from login page
#  - User is navigated to dashboard with successful login
#* Navigate to User Profile
#  - User is navigated to user profile page
#* Change profile name
#* Click "Update" button
#  - New User Profile name display
#* In Logins area connect a social account by clicking "Connect"
#  - Bottom "Remove" becomes active and "Connect" is disabled
#* Click "Re-generate API Token" button
#  - Display warning modal window message “Re-generating your API token will cause your synchronized devices (smartphones, tablets, etc) to lose access to your JuiceNet account. Use this function only if your API key has been compromised.”
#* Click "Cancel" button
#* Logout

@b2c @web
Scenario: B2C_Web_Registration_and_Login_11 - Login with invalid email
	#Given I navigate to "Account/Login" page (b2c)
	#When I set field "<FieldId>" to "<Value>" (b2c)
	#	| FieldId         | Value               |
	#	| Email           | 891355577799 |
	#	| Password        | 0123456789   |
	#Then field "Password" should be masked (b2c)
	#When I click on button with name "Login" (b2c) 
	#Then Error message "The Email field is not a valid e-mail address." is displayed (b2c)

