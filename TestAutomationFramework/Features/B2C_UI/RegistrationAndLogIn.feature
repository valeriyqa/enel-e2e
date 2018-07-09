Feature: B2C Registration And LogIn Operations
	In order to verify Registration And LogIn functionality
	we run next scenarios

@b2c @web
Scenario: B2C_Web_ Registration with email
	Given I navigate to "Account/Login" page
	When I click on "Register new user with email" link
	Then I should be navigated to the "Account/Register" page
	When I set field "<FieldId>" to "<Value>"
		| FieldId         | Value               |
		| Email           | example@example.com |
		| pwdinpuit       | Pa$$w0rd            |
		| ConfirmPassword | Pa$$w0rd            |
	Then field "<FieldId>" should be masked
		| FieldId         |
		| pwdinpuit       |
		| ConfirmPassword |
	When I set field "Fullname" to "Vasia Pupkin"
	#And I click on "buttonSubmit" button by Id
	And I confirm my email address
	##And I click on "Please Click here to Log in" link
	#Then I should be logged into the application

