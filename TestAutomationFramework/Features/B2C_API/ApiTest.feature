Feature: API
	In order to test API functionality we run next scenarios

@b2c @api 
Scenario Outline: B2C_API_ Basic test for requests without parameters
	When I send "<RestAPI>" request
	Then response should be valid to schema
	And property "success" should be equal to "True"
	Examples: 
		| RestAPI         |
		| get_car_models  |
		| get_server_info |
		| get_timezones   |

@b2c @api
Scenario: B2C_API_ Add/delete unit to the system
	Given JuiceBox unit is not added
	When I send "add_account_unit" request
	And I send "get_account_units" request
	Then response should be valid to schema
	And response should contain device number is "True"
	When I send "delete_account_unit" request
	And I send "get_account_units" request
	Then response should be valid to schema
	And response should contain device number is "False"

# Unit should be added before test. (Will be nice to create at least three separate devices for each system,
# with unique ID. To have possibility run tests in the parallel mode.)
#@b2c @api 
#Scenario: B2C_API_ Add/delete program signup info
#	Given program signup info is not set
#	When I send "set_program_signup_info" request
#	And I send "get_program_signup_info" request
#	Then response should be valid to schema
#	And property "<PropertyName>" should be equal to "<Value>"
#		| PropertyName                    | Value                |
#		| success                         | 1                    |
#		| step1.first_name                | FirstName            |
#		| step1.last_name                 | LastName             |
#		| step1.bill_first_name           | Billfirstname        |
#		| step1.bill_last_name            | Billlastname         |
#		| step1.email                     | testuser@example.com |
#		| step1.phone_number              | 123-456-78-90        |
#		| step1.address                   | Test home address    |
#		| step1.city                      | TestCity             |
#		| step1.state                     | California           |
#		| step1.service_address           | Test service address |
#		| step1.service_city              | San Carol            |
#	And property "step1.post_code" should be equal to "95128" string
#	When I send "delete_program_signup_info" request
#	And I send "get_program_signup_info" request
#	Then response should be valid to schema
#	And property "<PropertyName>" should be equal to "<Value>"
#		| PropertyName                    | Value                            |
#		| success                         | 1                                |
#		| step1.first_name                | Oleksii                          |
#		| step1.last_name                 | Khabarov                         |
#		| step1.bill_first_name           |                                  |
#		| step1.name_is_different_in_bill |                                  |
#		| step1.email                     | oleksii.khabarov@emotorwerks.com |
#		| step1.phone_number              |                                  |
#		| step1.address                   | null                             |
#		| step1.city                      | null                             |
#		| step1.state                     | null                             |
#		| step1.service_address           |                                  |
#		| step1.service_city              |                                  |
#	And property "step1.post_code" should be equal to "94070" string

@b2c @api 
Scenario Outline: B2C_API_ Incorrect token test
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

@b2c @api 
Scenario Outline: B2C_API_ Missing token test
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

@b2c @api 
Scenario Outline: B2C_API_ Incorrect account token test
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

@b2c @api 
Scenario Outline: B2C_API_ Missing account token test
	When I send "<RestAPI>" request with next "account_token" "null"
	Then response should be valid to schema "error"
	And property "success" should be equal to "False"
	And property "error_code" should be equal to "1009"
	And property "error_message" should be equal to "Missing Account token"
	Examples: 
		| RestAPI                    |
		| add_account_unit           |
		#| add_car                    |1001
		#| add_unit                   |User have not permissions to unit. Check account token. (consistency)
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

@b2c @api 
Scenario: B2C_API_ Add/delete new unit to the system

@b2c @api 
Scenario: B2C_API_ Add/delete car to the system

@b2c @api 
Scenario: B2C_API_ Add/delete Utility bill

@b2c @api 
Scenario: B2C_API_ Ownership operations

@b2c @api 
Scenario: B2C_API_ Share device operations

@b2c @api 
Scenario: B2C_API_ Logout from the system









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