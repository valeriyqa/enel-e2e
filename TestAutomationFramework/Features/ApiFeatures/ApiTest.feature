Feature: API
	In order to test API functionality we run next scenarios

Background: Before running the tests, we need to make sure that the environment is ready
	#Given I prepare my environment

@api
Scenario Outline: General test for API services without preconditions
	Given I send "<RestAPI>" request
	Then response should be valid to schema
	And property "success" should be equal to "True"
	And property "error_code" should be equal to "null"
	And property "error_message" should be equal to "null"
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