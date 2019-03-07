Feature: Joomla Checkout
	To test Hikashop checkout
	we run next scenarios

@joomla @web
Scenario: Joomla_Web_Checkout_01 - Checkout, continental delivery, pay by Stripe, Billing address is the same as Shipping								
	Given I open site (joomla)
	Then I Navigate to menu item with "1593" ID (joomla)
	#Given Go to eMotorwerks Home page (joomla)
	#When I Close cookie banner (joomla)
	#Then Cookie banner must hide (joomla)
	#When I hover top menu item with "1567" Itemid (joomla)
	#Then Menu Item "1567" Sub-menu must be visible (joomla)
	#And I Click top menu item with "1569" Itemid (joomla)