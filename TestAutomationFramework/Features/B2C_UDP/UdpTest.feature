Feature: UdpTest
	In order to test UDP functionality
	we run next scenarios

@b2c @udp
Scenario Outline: B2C_UDP_ Test UDP endpoint
	Given I send udp packages with next "<UdpData>"

	Examples: 
		| UdpData                         |
		| TestUdpEndpoint_State_Standby   |
		| TestUdpEndpoint_State_Connected |
		| TestUdpEndpoint_State_Charging  |
		| TestUdpEndpoint_RawData         |

#@b2с @udp
#Scenario: B2C_UDP_ Test session energy
#	When I send UDP package with status "Standby" to unit "373701135"
#	Then I wait till UDP package with status "Connected" returns "A40"
#	Then I send udp Charging packages to unit "373701135" with energy "1000"
#	Then I send udp Charging packages to unit "373701135" with energy "1015"
#	Then I send udp Charging packages to unit "373701135" with energy "1025"
#	Then I send udp Charging packages to unit "373701135" with energy "1035"
#	Then I send udp Charging packages to unit "373701135" with energy "1045"
#	Then I send udp Charging packages to unit "373701135" with energy "1055"
#	Then I send udp Charging packages to unit "373701135" with energy "1065"
#	Then I send udp Charging packages to unit "373701135" with energy "1075"
#	Then I send udp Charging packages to unit "373701135" with energy "1085"
#	Then I send udp Charging packages to unit "373701135" with energy "1095"
#	Then I send udp Charging packages to unit "373701135" with energy "2000"
#	Then I send udp Charging packages to unit "373701135" with energy "5"
#	Then I send udp Charging packages to unit "373701135" with energy "10"
#	Then I send udp Charging packages to unit "373701135" with energy "15"
#	Then I send udp Charging packages to unit "373701135" with energy "20"
#	Then I send udp Charging packages to unit "373701135" with energy "25"
#	Then I send udp Charging packages to unit "373701135" with energy "30"
#	Then I send udp Charging packages to unit "373701135" with energy "35"
#	Then I send udp Charging packages to unit "373701135" with energy "40"
#	Then I send udp Charging packages to unit "373701135" with energy "45"
#	Then I send udp Charging packages to unit "373701135" with energy "50"
#	When I send UDP package with status "Standby" to unit "373701135"
