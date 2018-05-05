Feature: API
	In order to test API functionality we run next scenarios

@api @ignore
Scenario Outline: Basic test for requests without parameters
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

#Should be fixed
@api @ignore
Scenario: Add/delete program signup info
	Given program signup info is not set
	When I send "set_program_signup_info" request
	And I send "get_program_signup_info" request
	Then response should be valid to schema
	And property "<PropertyName>" should be equal to "<Value>"
		| PropertyName              | Value                            |
		| success                   | True                             |
		| first_name                | Oleksii                          |
		| last_name                 | Khabarov                         |
		| bill_first_name           |                                  |
		| bill_last_name            |                                  |
		| name_is_different_in_bill |                                  |
		| email                     | oleksii.khabarov@emotorwerks.com |
		| phone_number              |                                  |
		| address                   | null                             |
		| city                      | null                             |
		| state                     | null                             |
		| post_code                 | 94070                            |
		| service_address           |                                  |
		| service_city              | service_city                     |


#Use table to set multiple properties (example)
@api @ignore
Scenario Outline: Incorrect token test
	When I send "<RestAPI>" request with next "<Property>" "<Value>"
		| Property | Value           |
		| token    | incorrect_token |
	Then response should be valid to schema "error"
	And property "success" should be equal to "False"
	And property "error_code" should be equal to "1007"
	And property "error_message" should be equal to "Invalid session token. Please reenter password."
	Examples: 
		| RestAPI                    |
		| add_account_unit           |
		| add_car                    |
		| delete_account_unit        |
		| delete_car                 |
		| delete_program_signup_info |
		| get_history                |
		| get_info                   |
		| get_notifications          |
		| get_plot                   |
		| get_program_signup_info    |
		| get_schedule               |
		| get_share_pin              |
		| get_state                  |
		| get_utilitybill_url        |
		| select_car                 |
		| set_charging_time          |
		| set_garage                 |
		| set_info                   |
		| set_limit                  |
		| set_notifications          |
		| set_override               |
		| set_program_signup_info    |
		| set_schedule               |
		| update_car                 |

#If you want to set only one property, you can set it directly in variables (example)
@api @ignore
Scenario Outline: Missing token test
	When I send "<RestAPI>" request with next "token" "null"
	Then response should be valid to schema "error"
	And property "success" should be equal to "False"
	And property "error_code" should be equal to "1007"
	And property "error_message" should be equal to "Invalid session token. Please reenter password."
	Examples: 
		| RestAPI                    |
		| add_account_unit           |
		| add_car                    |
		| delete_account_unit        |
		| delete_car                 |
		| delete_program_signup_info |
		| get_history                |
		| get_info                   |
		| get_notifications          |
		| get_plot                   |
		| get_program_signup_info    |
		| get_schedule               |
		| get_share_pin              |
		| get_state                  |
		| get_utilitybill_url        |
		| select_car                 |
		| set_charging_time          |
		| set_garage                 |
		| set_info                   |
		| set_limit                  |
		| set_notifications          |
		| set_override               |
		| set_program_signup_info    |
		| set_schedule               |
		| update_car                 |

@api @ignore
Scenario Outline: Incorrect account token test
	When I send "<RestAPI>" request with next "account_token" "incorrect_token"
	Then response should be valid to schema "error"
	And property "success" should be equal to "False"
	And property "error_code" should be equal to "1009"
	And property "error_message" should be equal to "User have not permissions to unit. Check account token."
	Examples: 
		| RestAPI                    |
		| add_account_unit           |
		#| add_car                    |1001
		| add_unit                   |
		| delete_account_unit        |
		#| delete_car                 |1002
		| delete_program_signup_info |
		| get_account_units          |
		#| get_history                |true
		#| get_info                   |true
		#| get_notifications          |1001
		#| get_plot                   |1002
		| get_program_signup_info    |
		#| get_schedule               |true
		| get_share_pin              |
		#| get_state                  |true
		| get_utilitybill_url        |
		| register_pushes            |
		#| reset_ownership            |1102
		#| select_car                 |1002
		#| set_charging_time          |true
		#| set_garage                 |true
		#| set_info                   |true
		#| set_override               |true
		#| set_schedule               |true
		#| share_device               |1003
		#| update_car                 |1002

@api @ignore
Scenario Outline: Missing account token test
	When I send "<RestAPI>" request with next "account_token" "null"
	Then response should be valid to schema "error"
	And property "success" should be equal to "False"
	And property "error_code" should be equal to "1009"
	And property "error_message" should be equal to "Missing Account token"
	Examples: 
		| RestAPI                    |
		| add_account_unit           |
		#| add_car                    |1001
		#| add_unit                   |User have not permissions to unit. Check account token.
		| delete_account_unit        |
		#| delete_car                 |1002
		#| delete_program_signup_info |User have not permissions to unit. Check account token.
		| get_account_units          |
		#| get_history                |true
		#| get_info                   |true
		#| get_notifications          |1001
		#| get_plot                   |1002
		#| get_program_signup_info    |User have not permissions to unit. Check account token.
		#| get_schedule               |true
		#| get_share_pin              |User have not permissions to unit. Check account token.
		#| get_state                  |true
		#| get_utilitybill_url        |User have not permissions to unit. Check account token.
		| register_pushes            |
		#| reset_ownership            |1102
		#| select_car                 |1002
		#| set_charging_time          |true
		#| set_garage                 |true
		#| set_info                   |true
		#| set_override               |true
		#| set_schedule               |true
		#| share_device               |1003
		#| update_car                 |1002

@ignore
Scenario: Add/delete new unit to the system

@ignore
Scenario: Add/delete car to the system

@ignore
Scenario: Add/delete Utility bill

@ignore
Scenario: Ownership operations

@ignore
Scenario: Share device operations

@ignore
Scenario: Logout from the system









#Not work yet

#@api @ignore
#Scenario: Add/delete new unit to the system
#	When I send "add_unit" request
#	Then unit should be "added"
#	And unit history should be empty
#	And no cars should be associated with unit
#	And response should be valid to schema "<ShemaName>"
#	When I send "delete_account_unit" request
#	Then unit should be "deleted"	
#
#@api @ignore
#Scenario: Add/delete program signup info
#	Given I add unit to account with next preconditions:
#		| System | Account Token                         | Device Id   | Token                            |
#		| alpha  | a0c7b2bc-9492-41a3-8124-99e035816550  | Test device | 3ffbf508342447a788f5380ab382f57f |
#		| beta   | a0c7b2bc-9492-41a3-8124-99e035816550  | Test device | 3ffbf508342447a788f5380ab382f57f |
#		| prod   | a0c7b2bc-9492-41a3-8124-99e035816550  | Test device | 3ffbf508342447a788f5380ab382f57f |
#	And program signup info is not set
#	When I send "set_program_signup_info" request
#	Then program signup info should be "added"
#	When I send "delete_program_signup_info" request
#	Then program signup info should be "deleted"
#	And I delete unit from account
#
#@api @ignore
#Scenario: Add/delete car	
#	#Given I add unit to account	
#	When I send "add_car" request
#	Then car should be "added"
#	When I send "select_car" request
#	Then car should be "selected"
#	When I send "update_car" request
#	Then car should be "updated"
#	When I send "delete_car" request
#	Then car should be "deleted"
#
#@api @ignore
#Scenario: Share device
#	#Given I add unit to account
#	#And I delete unit from account