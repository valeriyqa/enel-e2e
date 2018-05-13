Feature: UdpTest
	In order to test UDP functionality
	we run next scenarios

@udp
Scenario Outline: Test UDP endpoint
	Given I send udp packages with next "<UdpData>"

	Examples: 
		| UdpData                         |
		| TestUdpEndpoint_State_Standby   |
		| TestUdpEndpoint_State_Connected |
		| TestUdpEndpoint_State_Charging  |
		| TestUdpEndpoint_RawData         |
