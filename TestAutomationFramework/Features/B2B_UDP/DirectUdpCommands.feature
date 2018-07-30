Feature: UdpTestForB2B
	In order to test UDP functionality
	we run next scenarios

@b2b @udp
Scenario: B2B_UDP_ Test UDP and API First authorization
	When I send UDP package with status "Standby" to unit "373705117"
	Then UDP response should contain "A00"
	When I send authorization API request to terminal "0000252525121990"
	Then API response should be successful
	Then I wait till UDP package with status "Connected" returns "A40"
	When I send UDP package with status "Charging" to unit "373705117"
	Then UDP response should contain "A40"
	When I send UDP package with status "Charging" to unit "373705117"
	Then UDP response should contain "A40"
	When I send UDP package with status "Charging" to unit "373705117"
	Then UDP response should contain "A40"
	When I send UDP package with status "Charging" to unit "373705117"
	Then UDP response should contain "A40"
	Then I wait till UDP package with status "Standby" returns "A00"
	When I verify device status via API request
	Then property "status" should be "finished"
	And energy status should be valild

@b2b @udp
Scenario: B2B_UDP_ Test UDP and API First plug
	When I send UDP package with status "Standby" to unit "373705117"
	Then UDP response should contain "A00"
	When I send UDP package with status "Connected" to unit "373705117"
	Then UDP response should contain "A00"
	When I send authorization API request to terminal "0000252525121990"
	Then API response should be successful
	Then I wait till UDP package with status "Charging" returns "A40"
	#When I send UDP package with status "Charging" to unit "373705117"
	#Then UDP response should contain "A40"
	When I send UDP package with status "Charging" to unit "373705117"
	Then UDP response should contain "A40"
	When I send UDP package with status "Charging" to unit "373705117"
	Then UDP response should contain "A40"
	When I send UDP package with status "Charging" to unit "373705117"
	Then UDP response should contain "A40"
	Then I wait till UDP package with status "Standby" returns "A00"
	When I verify device status via API request
	Then property "status" should be "finished"
	And energy status should be valild




##	@b2b @udp
##Scenario: B2B_UDP_ Test UDP and API
##	 Stand-by 
##	When I send UDP package with"<deviceState>" to unit "<unitId>"
##
##	When I send udp package "0817011001020457542118246997:v07,s0467,u63132,V2514,L0000088508,S0,T17,M00,m40,t29,i64,e0000,f5999,X0,Y0!T40:"
##	Then UDP response should contain "A00"
##	When I send "RequestCMD" request with next "<Property>" "<Value>"
##		| Property | Value                        |
##		| unit     | 0817011001020457542118246997 |
##		| token    | 1089774617                   |
##	Then API response should be successful
##
##	When I send udp package "0817011001020457542118246997:v07,s0934,u00596,V2512,L0000088508,S0,T17,M00,m40,t29,i65,e0000,f5998,X0,Y0!MPW:"
##	Then UDP response should contain "A00"
##	When I send udp package "0817011001020457542118246997:v07,s0291,u01296,V2513,L0000088508,S1,T17,M00,m40,t29,i66,e0000,f5998,X0,Y0!MUE"
##	Then UDP response should contain "A40"
##	When I send udp package "0817011001020457542118246997:v07,s0457,u05196,V2513,L0000088510,S2,T17,M40,m40,t09,i68,e0583,f5998,X0,Y0,E000002,A0003,p0025!00V:"
##	Then UDP response should contain "A40" !ERROR!A00
##	When I send udp package "0817011001020457542118246997:v07,s0457,u06096,V2466,L0000088520,S2,T17,M40,m40,t09,i69,e1526,f5999,X0,Y0,E000012,A0288,p0996!SN4:"
##	Then UDP response should contain "A40" !ERROR!A00
##	When I send udp package "0817011001020457542118246997:v07,s0146,u11196,V2467,L0000088615,S2,T17,M40,m40,t09,i74,e0851,f5999,X0,Y0,E000107,A0288,p0996!54G"
##	Then UDP response should contain "A40" !ERROR!Time out
##	When I send udp package "0817011001020457542118246997:v07,s0360,u11696,V2494,L0000088627,S0,T17,M40,m40,t29,i75,e0045,f5999,X0,Y0!5MH:"
##	Then UDP response should contain "A00"
##	When I send udp package "0817011001020457542118246997:v07,s0235,u14896,V2514,L0000088627,S0,T17,M40,m40,t29,i76,e0000,f5998,X0,Y0!TNA:"
##	Then UDP response should contain "A00"