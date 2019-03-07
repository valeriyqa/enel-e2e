Feature: Joomla General
	To test Joomla site functional
	we run next scenarios

@joomla @web
Scenario: Joomla_Web_General_01 - Check all Menu Item
	Given I open site (joomla)
	Then I click all menu item in rotation (joomla)
