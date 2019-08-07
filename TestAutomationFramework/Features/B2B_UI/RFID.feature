Feature: B2B RFID feature
	In order to verify RFID feature functionality
	we run next scenarios

@b2b @web
Scenario: B2B_Web_RFID_01 Start and finish charging session by RFID card command

@b2b @web
Scenario: B2B_Web_RFID_02 Check that 2 minutes authorization timer works correct with RFID card

@b2b @web
Scenario: B2B_Web_RFID_03 Check that user can charge multiple devices simultaneously with RFID card

@b2b @web
Scenario: B2B_Web_RFID_04 Check that disabled RFID for user(with "IsDisabled=true" flag in DB) is not working for start\stop charging session

@b2b @web
Scenario: B2B_Web_RFID_05 Check if Driver that has deny permission for charge can’t charge with RFID command(card)

@b2b @web
Scenario: B2B_Web_RFID_06 Check that charging session is finished correctly if user made plug out