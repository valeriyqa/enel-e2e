Feature: ForTestOnly
	In order to avoid silly mistakes
	As a math idiot
	I want to ...

@api @ignore
Scenario Outline: TestScenario
	Given I wont to send "<API>"
	Examples: 
		| API                     |
		| add_account_unit           |
		| add_car                    |
		| add_unit                   |
		| check_device               |
		| delete_account_unit        |
		| delete_car                 |
		| delete_program_signup_info |
		| get_account_units          |
		| get_car_models             |
		| get_history                |
		| get_info                   |
		| get_notifications          |
		| get_plot                   |
		| get_program_signup_info    |
		| get_reset_pin              |
		| get_schedule               |
		| get_server_info            |
		| get_share_pin              |
		| get_state                  |
		| get_timezones              |
		| get_utilitybill_url        |
		| logout                     |
		| pair_device                |
		| register_pushes            |
		| reset_ownership            |
		| select_car                 |
		| set_charging_time          |
		| set_garage                 |
		| set_info                   |
		| set_limit                  |
		| set_notifications          |
		| set_override               |
		| set_program_signup_info    |
		| set_schedule               |
		| share_device               |
		| update_car                 |

@api
Scenario: OneMoreTest
	Given I want to test fignia
