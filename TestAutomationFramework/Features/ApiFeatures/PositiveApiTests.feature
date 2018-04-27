Feature: PositiveApiTests
	In order to verify positiv API functionality
	we run next scenarios

@api @ignore
Scenario Outline: General test for requests without parameters
	When I send "<RestAPI>" request
	Then response should be valid to schema
	And property "success" should be equal to "True"
	And property "error_code" should be equal to "null"
	And property "error_message" should be equal to "null"
	Examples: 
		| RestAPI         |
		| get_car_models  |
		| get_server_info |
		| get_timezones   |

@api @ignore
Scenario: Add/delete new unit to the system
	When I send "add_unit" request
	Then unit should be "added"
	And unit history should be empty
	And no cars should be associated with unit
	And response should be valid to schema "<ShemaName>"
	When I send "delete_account_unit" request
	Then unit should be "deleted"	

@api @ignore
Scenario: Add/delete program signup info
	Given I add unit to account with next preconditions:
		| System | Account Token                         | Device Id   | Token                            |
		| alpha  | a0c7b2bc-9492-41a3-8124-99e035816550  | Test device | 3ffbf508342447a788f5380ab382f57f |
		| beta   | a0c7b2bc-9492-41a3-8124-99e035816550  | Test device | 3ffbf508342447a788f5380ab382f57f |
		| prod   | a0c7b2bc-9492-41a3-8124-99e035816550  | Test device | 3ffbf508342447a788f5380ab382f57f |
	And program signup info is not set
	When I send "set_program_signup_info" request
	Then program signup info should be "added"
	When I send "delete_program_signup_info" request
	Then program signup info should be "deleted"
	And I delete unit from account

@api @ignore
Scenario: Add/delete car	
	#Given I add unit to account	
	When I send "add_car" request
	Then car should be "added"
	When I send "select_car" request
	Then car should be "selected"
	When I send "update_car" request
	Then car should be "updated"
	When I send "delete_car" request
	Then car should be "deleted"

@api @ignore
Scenario: Share device
	#Given I add unit to account
	#And I delete unit from account
