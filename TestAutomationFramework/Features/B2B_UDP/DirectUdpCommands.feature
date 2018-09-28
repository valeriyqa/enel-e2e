Feature: UdpTestForB2B
	In order to test UDP functionality
	we run next scenarios

@b2b @p_term
Scenario: B2B_UDP_ Test UDP and API First authorization
	When I send UDP package with status "Standby" to unit
	Then UDP response should contain "A00"
	When I send authorization API request to terminal
	Then API response should be successful
	Then I wait till UDP package with status "Connected" returns amperage higher than "00"
	When I send UDP package with status "Charging" to unit
	Then UDP response should contain amperage higher than "00"
	When I send UDP package with status "Charging" to unit
	Then UDP response should contain amperage higher than "00"
	When I send UDP package with status "Charging" to unit
	Then UDP response should contain amperage higher than "00"
	When I send UDP package with status "Charging" to unit
	Then UDP response should contain amperage higher than "00"
	Then I wait till UDP package with status "Standby" returns "A00"
	When I verify device status via API request
	Then property "status" should be "finished"
	And energy status should be valild

@b2b @p_term
Scenario: B2B_UDP_ Test UDP and API First plug
	When I send UDP package with status "Standby" to unit
	Then UDP response should contain "A00"
	When I send UDP package with status "Connected" to unit
	Then UDP response should contain "A00"
	When I send authorization API request to terminal
	Then API response should be successful
	Then I wait till UDP package with status "Charging" returns amperage higher than "00"
	When I send UDP package with status "Charging" to unit
	Then UDP response should contain amperage higher than "00"
	When I send UDP package with status "Charging" to unit
	Then UDP response should contain amperage higher than "00"
	When I send UDP package with status "Charging" to unit
	Then UDP response should contain amperage higher than "00"
	Then I wait till UDP package with status "Standby" returns "A00"
	When I verify device status via API request
	Then property "status" should be "finished"
	And energy status should be valild