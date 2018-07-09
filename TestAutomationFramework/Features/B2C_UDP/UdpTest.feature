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

#@b2c @udp
#Scenario: B2C_UDP_ Test UDP and API
#	#Given I send udp package "373705106:v07,s0467,u63132,V2514,L0000088508,S0,T17,M00,m40,t29,i64,e0000,f5999,X0,Y0!T40:" to server "104.40.78.108" with port "8042"
#	Given I send udp package "011111112:v07,s0121,u00000,V2201,L123,S2,T35,M40,m40,t10,i45,e-1,f6000,X0,Y0,E0,A0320,p1000!DPQ:" to server "juiceboxdev.cloudapp.net" with port "8042"
	