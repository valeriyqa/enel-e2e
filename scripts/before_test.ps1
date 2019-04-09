function Send2Udp {
    Param(
        [Parameter(
            Mandatory = $True,
            Position = 0,
            ParameterSetName = '',
            ValueFromPipeline = $True)]
            [string]$udp_host,
        [Parameter(
            Position = 1,
            Mandatory = $False,
            ParameterSetName = '')]
            [int]$udp_port = 8042,
        [Parameter(
            Mandatory = $False,
            ParameterSetName = '')]
            [string]$udp_string = "011111112:v07,s0121,u00000,V2201,L123,S2,T35,M40,m40,t10,i45,e-1,f6000,X0,Y0,E0,A0320,p1000!DPQ:",
        [Parameter(
            Mandatory = $False,
            ParameterSetName = '')]
            [int]$udp_timeout = 3000
    )

    $udpobject = new-Object system.Net.Sockets.Udpclient
    $udpobject.client.ReceiveTimeout = $udp_timeout
    $udpobject.Connect($udp_host, $udp_port)
    $message = new-object system.text.asciiencoding
    $byte = $message.GetBytes($udp_string)
    [void]$udpobject.Send($byte,$byte.length)
    $remoteendpoint = New-Object system.net.ipendpoint([system.net.ipaddress]::Any,0)
    Try {
        $receivebytes = $udpobject.Receive([ref]$remoteendpoint)
        [string]$returndata = $message.GetString($receivebytes)
        $udpobject.close()
        return $returndata
    }
    Catch {
        return $null
    }
}

function Send2Api {
    Param(
        [Parameter(
            Position = 0,
            ParameterSetName = '',
            ValueFromPipeline = $True)]
            [string]$api_host = "http://emwjuicebox.cloudapp.net/",
        [Parameter(
            Position = 1,
            Mandatory = $False,
            ParameterSetName = '')]
            [string]$api_json = '{ "cmd": "get_server_info" }'
        )

    $objectFromJson = $api_json | ConvertFrom-Json
    $path = GetUrlPath4ApiB2C $objectFromJson.cmd
    $url = $api_host + $path
    $method = GetMethodType4Api $objectFromJson.cmd
    return Invoke-WebRequest $url -Method $method -Body $api_json -ContentType 'application/json'
}

function GetUrlPath4ApiB2C {
    Param(
        [Parameter(
            Mandatory = $True,
            Position = 0,
            ParameterSetName = '',
            ValueFromPipeline = $True)]
            [string]$request_cmd
    )
    switch -Exact ($request_cmd) {
        { @( "add_unit", "check_device", "get_account_units", "get_car_models", "get_reset_pin",`
        "get_server_info", "get_timezones", "logout", "pair_device", "register_pushes",`
        "reset_ownership" ) -contains $_ } { return "box_pin" }

        { @( "add_account_unit", "add_car", "delete_account_unit", "delete_car", "delete_program_signup_info",`
        "get_history", "get_info", "get_notifications", "get_plot", "get_program_signup_info", "get_schedule",`
        "get_share_pin", "get_state", "get_utilitybill_url", "select_car", "set_charging_time", "set_garage",`
        "set_info", "set_limit", "set_notifications", "set_override", "set_program_signup_info", "set_schedule",`
        "share_device", "update_car" ) -contains $_ } { return "box_api_secure" }

        default { return $null }
    }
}

function GetMethodType4Api {
    Param(
        [Parameter(
            Position = 0,
            ParameterSetName = '',
            ValueFromPipeline = $True)]
            [string]$request_cmd = '{ "cmd": "get_server_info" }'
    )
    return "Post"
}



Write-Host "Start"
Write-Host $Env:BUILD_SOURCESDIRECTORY
Write-Host $Env:BUILD_BUILDNUMBER
Write-Host "Finish"

$zzz = GetMethodType4Api '{ "cmd": "get_server_info" }'

Write-Host $zzz
