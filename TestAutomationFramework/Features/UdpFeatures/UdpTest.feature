Feature: UdpTest
	In order to test UDP functionality
	we run next scenario

@udp
Scenario: Test UDP endpoint
	Given I send udp packages with next UdpData
		| UdpData                         |
		| TestUdpEndpoint_State_Standby   |
		| TestUdpEndpoint_State_Connected |
		| TestUdpEndpoint_State_Charging  |
		| TestUdpEndpoint_RawData         |
