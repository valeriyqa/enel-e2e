Feature: API
	In order to test API functionality
	we run next scenarios

@api
Scenario Outline: Test API services
	Given I send "<RestAPI>" request
	Then I should receive correct response

	Examples: 
		| RestAPI                 |
		| get_account_units       |
		| get_state               |
		| check_device            |
		| get_timezones           |
		| get_server_info         |
		| get_car_models          |
		| get_history             |
		| get_schedule            |
		| get_info                |
		| get_notifications       |
		| get_utilitybill_url     |
		| get_program_signup_info |