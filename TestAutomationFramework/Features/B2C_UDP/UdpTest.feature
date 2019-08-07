Feature: UdpTest
	In order to test UDP functionality
	we run next scenarios

@b2c @udp
Scenario Outline: All_UDP_ Test UDP endpoint
	Given I send udp packages with next "<UdpData>"

	Examples: 
		| UdpData                         |
		| TestUdpEndpoint_State_Standby   |
		| TestUdpEndpoint_State_Connected |
		| TestUdpEndpoint_State_Charging  |
		| TestUdpEndpoint_RawData         |

@b2c @udp
Scenario: All_UDP_ Test UDP response contains S section with unique  value
	Given I send udp package "011111112:v07,s0121,u00000,V2201,L123,S2,T35,M40,m40,t10,i45,e-1,f6000,X0,Y0,E0,A0320,p1000!DPQ:"
	And I save response to list
	And I send udp package "011111112:v07,s0121,u00000,V2201,L123,S2,T35,M40,m40,t10,i45,e-1,f6000,X0,Y0,E0,A0320,p1000!DPQ:"
	And I save response to list
	And I send udp package "011111112:v07,s0121,u00000,V2201,L123,S2,T35,M40,m40,t10,i45,e-1,f6000,X0,Y0,E0,A0320,p1000!DPQ:"
	And I save response to list
	Then at least one value of the "S" section should not be same
	#Then response should contain S section higher "001"

#@udp
#Scenario Outline: Delete me
#	Given I send udp packages with next "<UdpData>"
#
#	Examples: 
#		| UdpData                   |
#		| TestUdpEndpoint_AddUnit   |