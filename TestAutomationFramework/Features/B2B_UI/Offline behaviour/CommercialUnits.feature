Feature: CommercialUnits
	In order to verify Сommercial Units feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_СommercialUnits_01 From Charging to Offline

@b2b @web
Scenario: B2B_Web_СommercialUnits_02 From Offline(with existed session) to Charging 

@b2b @web
Scenario: B2B_Web_СommercialUnits_03 From Offline(without existed session) to Charging 

@b2b @web
Scenario: B2B_Web_СommercialUnits_04 From StandBy to Offline

@b2b @web
Scenario: B2B_Web_СommercialUnits_05 From Pluggedin to Offline

@b2b @web
Scenario: B2B_Web_СommercialUnits_06 From Offline to Standby

@b2b @web
Scenario: B2B_Web_СommercialUnits_07 From Offline to Pluggedin

@b2b @web
Scenario: B2B_Web_СommercialUnits_08 Check correct session finish after device stays offline more than 1h

@b2b @web
Scenario: B2B_Web_СommercialUnits_09 Check correct energy value after stopping charging session few times

@b2b @web
Scenario: B2B_Web_СommercialUnits_10 Check correct energy value after stopping charging session few times and stay offline more than one hour(hard offline time)