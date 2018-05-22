Feature: B2C MyJuiceNet
	In order to verify JuiceNet functionality
	we run next scenarios

@b2c @web 
Scenario: B2C_Web_ Add/Delete JuiceNet Device
	Note! We collect add and delete scenarios together to avoid parallel execution collision,
	when separate scenarios may perform mutually exclusive actions.

	Given JuiceNet device is not added
	And I login to the b2c system as "Oleksii"
	When I click on "Add JuiceNet Device" button
	And I set field "inputUnitID" to "373708002"
	And I click on "Add JuiceNet Device" button
	And I click on "Browse My JuiceNet Devices" link
	Then JuiceNet device with Id "373708002" should exist is "True"
	When I click More Details for device with Id "373708002"
	And I click on "Delete" button
	And I click on "Yes, remove from my account" button
	Then JuiceNet device with Id "373708002" should exist is "False"

