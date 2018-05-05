using System.Collections.Generic;

namespace TestAutomationFramework.Services.ApiService

{
    /// <summary>
    /// This class contains models for Rest API requests and responses
    /// </summary>
    /// <remarks>
    /// Begin of the requests section
    /// </remarks>

    /// add_account_unit request
    public class AddAccountUnit
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string device_id { get; set; }
        public string token { get; set; }
    }

    /// add_car request
    public class AddCarInfo
    {
        public int battery_range_m { get; set; }
        public int battery_size_wh { get; set; }
        public int charging_rate_w { get; set; }
        public string description { get; set; }
        public string model_id { get; set; }
    }

    public class AddCar
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
        public AddCarInfo info { get; set; }
    }

    /// add_unit request
    public class AddUnit
    {
        public string cmd { get; set; }
        public string device_id { get; set; }
        public string device_name { get; set; }
        public string account_token { get; set; }
        public string ID { get; set; }
    }

    /// check_device request
    public class CheckDevice
    {
        public string cmd { get; set; }
        public string ID { get; set; }
    }

    /// delete_account_unit request
    public class DeleteAccountUnit
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string device_id { get; set; }
        public string token { get; set; }
    }

    /// delete_car request
    public class DeleteCarInfo
    {
        public int car_id { get; set; }
    }

    public class DeleteCar
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
        public DeleteCarInfo info { get; set; }
    }

    /// delete_program_signup_info request
    public class DeleteProgramSignupInfo
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string device_id { get; set; }
        public string token { get; set; }
        public string ID { get; set; }
    }

    /// get_account_units request
    public class GetAccountUnits
    {
        public string cmd { get; set; }
        public string device_id { get; set; }
        public string account_token { get; set; }
    }

    /// get_car_models request
    public class GetCarModels
    {
        public string cmd { get; set; }
    }

    /// get_history request
    public class GetHistory
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
    }

    /// get_info request
    public class GetInfo
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
    }

    /// get_notifications request
    public class GetNotifications
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
    }

    /// get_plot request
    public class GetPlot
    {
        public string cmd { get; set; }
        public string device_id { get; set; }
        public string token { get; set; }
        public string account_token { get; set; }
        public string attribute { get; set; }
        public int intervals { get; set; }
        public int session_id { get; set; }
    }

    /// get_program_signup_info request
    public class GetProgramSignupInfo
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
    }

    /// get_reset_pin request
    public class GetResetPin
    {
        public string cmd { get; set; }
        public string ID { get; set; }
        public string device_id { get; set; }
        public string pin { get; set; }
        public int step { get; set; }
        public string session { get; set; }
    }

    /// get_schedule request
    public class GetSchedule
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
    }

    /// get_server_info request
    public class GetServerInfo
    {
        public string cmd { get; set; }
    }

    /// get_share_pin request
    public class GetSharePin
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string device_id { get; set; }
        public string token { get; set; }
    }

    /// get_state request
    public class GetState
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
    }

    /// get_timezones request
    public class GetTimezones
    {
        public string cmd { get; set; }
    }

    /// get_utilitybill_url request
    public class GetUtilitybillUrl
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
    }

    /// logout request
    public class Logout
    {
        public string cmd { get; set; }
        public string device_id { get; set; }
        public string account_token { get; set; }
    }

    /// pair_device request
    public class PairDevice
    {
        public string cmd { get; set; }
        public string device_id { get; set; }
        public string ID { get; set; }
        public string pin { get; set; }
    }

    /// register_pushes request
    public class RegisterPushes
    {
        public string cmd { get; set; }
        public string device_id { get; set; }
        public string account_token { get; set; }
        public string push_token { get; set; }
    }

    /// reset_ownership request
    public class ResetOwnership
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string ID { get; set; }
        public string device_id { get; set; }
        public int step { get; set; }
        public string session { get; set; }
    }

    /// select_car request
    public class SelectCarInfo
    {
        public int car_id { get; set; }
    }

    public class SelectCar
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
        public SelectCarInfo info { get; set; }
    }

    /// set_charging_time request
    public class SetChargingTime
    {
        public string cmd { get; set; }
        public string device_id { get; set; }
        public string token { get; set; }
        public string account_token { get; set; }
        public int charging_time { get; set; }
    }

    /// set_garage request
    public class SetGarage
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
        public string garage_id { get; set; }
    }

    /// set_info request
    public class SetInfoImages
    {
        public string charging { get; set; }
        public string @default { get; set; }
        public string plugged { get; set; }
    }

    public class SetInfoModelInfo
    {
        public string model_id { get; set; }
        public string description { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public int range_m { get; set; }
        public int range_city_m { get; set; }
        public int range_highway_m { get; set; }
        public int battery_size_wh { get; set; }
        public int charging_rate_w { get; set; }
        public SetInfoImages images { get; set; }
    }

    public class SetInfoCars
    {
        public int car_id { get; set; }
        public string description { get; set; }
        public int battery_size_wh { get; set; }
        public int battery_range_m { get; set; }
        public int charging_rate_w { get; set; }
        public string model_id { get; set; }
        public SetInfoModelInfo model_info { get; set; }
    }

    public class SetInfoPolicy
    {
        public string name { get; set; }
        public bool user_control_allowed { get; set; }
        public string charge_control_type { get; set; }
    }

    public class SetInfo
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
        public string name { get; set; }
        public string zip { get; set; }
        public string country_code { get; set; }
        public string load_group_id { get; set; }
        public int unit_type_id { get; set; }
        public string IP { get; set; }
        public int gascost { get; set; }
        public int mpg { get; set; }
        public int ecost { get; set; }
        public int whpermile { get; set; }
        public string timeZoneId { get; set; }
        public int amps_wire_rating { get; set; }
        public int amps_unit_rating { get; set; }
        public int info_timestamp { get; set; }
        public string garage_id { get; set; }
        public List<SetInfoCars> cars { get; set; }
        public SetInfoPolicy policy { get; set; }
    }

    /// set_limit request
    public class SetLimit
    {
        public string cmd { get; set; }
        public string device_id { get; set; }
        public string token { get; set; }
        public int amperage { get; set; }
    }

    /// set_notifications request
    public class SetNotificationsChargingDelayedDueToToU
    {
        public bool email { get; set; }
        public bool push { get; set; }
    }

    public class SetNotificationsStartCharging
    {
        public bool email { get; set; }
        public bool push { get; set; }
    }

    public class SetNotificationsStopCharging
    {
        public bool email { get; set; }
        public bool push { get; set; }
    }

    public class SetNotificationsIsOffline
    {
        public bool email { get; set; }
        public bool push { get; set; }
    }

    public class SetNotificationsIsBackOnline
    {
        public bool email { get; set; }
        public bool push { get; set; }
    }

    public class SetNotificationsIsNotPluggedInBy
    {
        public bool email { get; set; }
        public bool push { get; set; }
        public int time { get; set; }
    }

    public class SetNotifications
    {
        public string cmd { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
        public SetNotificationsChargingDelayedDueToToU charging_delayed_due_to_ToU { get; set; }
        public SetNotificationsStartCharging start_charging { get; set; }
        public SetNotificationsStopCharging stop_charging { get; set; }
        public SetNotificationsIsOffline is_offline { get; set; }
        public SetNotificationsIsBackOnline is_back_online { get; set; }
        public SetNotificationsIsNotPluggedInBy is_not_plugged_in_by { get; set; }
    }

    /// set_override request
    public class SetOverride
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
        public int energy_at_plugin { get; set; }
        public int override_time { get; set; }
        public int energy_to_add { get; set; }
    }

    /// set_program_signup_info request
    public class SetProgramSignupInfoUserinfo
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string name_is_different_in_bill { get; set; }
        public string bill_first_name { get; set; }
        public string bill_last_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string service_address { get; set; }
        public string service_city { get; set; }
        public string state { get; set; }
        public string post_code { get; set; }
        public List<string> images { get; set; }
    }

    public class SetProgramSignupInfo
    {
        public string cmd { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
        public SetProgramSignupInfoUserinfo userinfo { get; set; }
    }

    /// set_schedule request
    public class SetScheduleWeekday
    {
        public int start { get; set; }
        public int end { get; set; }
        public int car_ready_by { get; set; }
    }

    public class SetScheduleWeekend
    {
        public int start { get; set; }
        public int end { get; set; }
        public int car_ready_by { get; set; }
    }

    public class SetSchedule
    {
        public string cmd { get; set; }
        public string device_id { get; set; }
        public string token { get; set; }
        public string type { get; set; }
        public string account_token { get; set; }
        public SetScheduleWeekday weekday { get; set; }
        public SetScheduleWeekend weekend { get; set; }
    }

    /// share_device request
    public class ShareDevice
    {
        public string cmd { get; set; }
        public string device_id { get; set; }
        public string device_name { get; set; }
        public string account_token { get; set; }
        public string ID { get; set; }
        public string pin { get; set; }
    }

    /// update_car request
    public class UpdateCarInfo
    {
        public int battery_range_m { get; set; }
        public int car_id { get; set; }
        public int battery_size_wh { get; set; }
        public int charging_rate_w { get; set; }
        public string description { get; set; }
        public int model_id { get; set; }
    }

    public class UpdateCar
    {
        public string cmd { get; set; }
        public string account_token { get; set; }
        public string token { get; set; }
        public string device_id { get; set; }
        public UpdateCarInfo info { get; set; }
    }

    /// <remarks>
    /// Begin of the responses section
    /// </remarks>

    /// general response
    public class GeneralResponse
    {
        public bool success { get; set; }
    }

    /// general error response
    public class GeneralErrorResponse
    {
        public string error_message { get; set; }
        public int error_code { get; set; }
        public bool success { get; set; }
    }

    /// add_account_unit response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //AddAccountUnitResponse

    /// add_car response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //AddCarResponse

    /// add_unit response
    public class AddUnitResponse
    {
        public bool success { get; set; }
        public string unit_id { get; set; }
        public string name { get; set; } //Probably optional
        public string token { get; set; }
    }

    /// check_device response
    public class CheckDeviceResponse
    {
        public bool success { get; set; }
        public string ID { get; set; }
        public bool secured { get; set; }
        public int time_last_ping { get; set; }
    }

    /// delete_account_unit response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //DeleteAccountUnitResponse

    /// delete_car response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //DeleteCarResponse

    /// delete_program_signup_info response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //DeleteProgramSignupInfoResponse

    /// get_account_units response
    public class GetAccountUnitsUnit
    {
        public string name { get; set; }
        public string token { get; set; }
        public string unit_id { get; set; }
    }

    public class GetAccountUnitsResponse
    {
        public bool success { get; set; }
        public List<GetAccountUnitsUnit> units { get; set; }
    }

    /// get_car_models response
    public class GetCarModelsImages
    {
        public string @default { get; set; }
        public string charging { get; set; }
    }

    public class GetCarModelsModel
    {
        public string model_id { get; set; }
        public string description { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public int range_m { get; set; }
        public int range_city_m { get; set; }
        public int range_highway_m { get; set; }
        public int battery_size_wh { get; set; }
        public int charging_rate_w { get; set; }
        public GetCarModelsImages images { get; set; }
    }

    public class GetCarModelsResponse
    {
        public bool success { get; set; }
        public string version { get; set; }
        public List<GetCarModelsModel> models { get; set; }
    }

    /// get_history response
    public class GetHistorySession
    {
        public int id { get; set; }
        public int time_start { get; set; }
        public int time_end { get; set; }
        public int duration { get; set; }
        public int wh_energy { get; set; }
    }

    public class GetHistoryResponse
    {
        public bool success { get; set; }
        public int continuity_token { get; set; }
        public List<GetHistorySession> sessions { get; set; }
    }

    /// get_info response
    public class GetInfoImages
    {
        public string charging { get; set; }
        public string @default { get; set; }
    }

    public class GetInfoModelInfo
    {
        public string model_id { get; set; }
        public string description { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public int range_m { get; set; }
        public int range_city_m { get; set; }
        public int range_highway_m { get; set; }
        public int battery_size_wh { get; set; }
        public int charging_rate_w { get; set; }
        public GetInfoImages images { get; set; }
    }

    public class GetInfoCars
    {
        public int car_id { get; set; }
        public string description { get; set; }
        public int battery_range_m { get; set; }
        public int battery_size_wh { get; set; }
        public int charging_rate_w { get; set; }
        public string model_id { get; set; }
        public GetInfoModelInfo model_info { get; set; }
    }

    public class GetInfoPolicy
    {
        public string name { get; set; }
        public bool user_control_allowed { get; set; }
        public string charge_control_type { get; set; }
    }

    public class GetInfoResponse
    {
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string country_code { get; set; }
        public string IP { get; set; }
        public int gascost { get; set; }
        public int mpg { get; set; }
        public int ecost { get; set; }
        public int whpermile { get; set; }
        public string timeZoneId { get; set; }
        public int amps_wire_rating { get; set; }
        public int amps_unit_rating { get; set; }
        public int info_timestamp { get; set; }
        public string garage_id { get; set; }
        public List<GetInfoCars> cars { get; set; }
        public int minimal_charge { get; set; }
        public double efficiency { get; set; }
        public GetInfoPolicy policy { get; set; }
        public int load_group_id { get; set; }
        public int unit_type_id { get; set; }
        public bool success { get; set; }
        public string ID { get; set; }
    }

    /// get_notifications response
    public class GetNotificationsSettings
    {
    }

    public class GetNotificationsStartCharging
    {
        public bool email { get; set; }
        public bool push { get; set; }
        public GetNotificationsSettings settings { get; set; }
    }

    public class GetNotificationsStopCharging
    {
        public bool email { get; set; }
        public bool push { get; set; }
        public GetNotificationsSettings settings { get; set; }
    }

    public class GetNotificationsChargingDelayedDueToToU
    {
        public bool email { get; set; }
        public bool push { get; set; }
        public GetNotificationsSettings settings { get; set; }
    }

    public class GetNotificationsIsBackOnline
    {
        public bool email { get; set; }
        public bool push { get; set; }
        public GetNotificationsSettings settings { get; set; }
    }

    public class GetNotificationsIsOffline
    {
        public bool email { get; set; }
        public bool push { get; set; }
        public GetNotificationsSettings settings { get; set; }
    }

    public class GetNotificationsIsNotPluggedInBy
    {
        public bool email { get; set; }
        public bool push { get; set; }
        public GetNotificationsSettings settings { get; set; }
    }

    public class GetNotificationsPluggedIn
    {
        public bool email { get; set; }
        public bool push { get; set; }
        public GetNotificationsSettings settings { get; set; }
    }

    public class GetNotificationsPluggedOut
    {
        public bool email { get; set; }
        public bool push { get; set; }
        public GetNotificationsSettings settings { get; set; }
    }

    public class GetNotificationsNotifications
    {
        public GetNotificationsStartCharging start_charging { get; set; }
        public GetNotificationsStopCharging stop_charging { get; set; }
        public GetNotificationsChargingDelayedDueToToU charging_delayed_due_to_ToU { get; set; }
        public GetNotificationsIsBackOnline is_back_online { get; set; }
        public GetNotificationsIsOffline is_offline { get; set; }
        public GetNotificationsIsNotPluggedInBy is_not_plugged_in_by { get; set; }
        public GetNotificationsPluggedIn plugged_in { get; set; }
        public GetNotificationsPluggedOut plugged_out { get; set; }
    }

    public class GetNotificationsResponse
    {
        public bool success { get; set; }
        public GetNotificationsNotifications notifications { get; set; }
    }

    /// get_plot response
    public class GetPlotPoint
    {
        public int t { get; set; }
        public int v { get; set; }
    }

    public class GetPlotResponse
    {
        public bool success { get; set; }
        public List<GetPlotPoint> points { get; set; }
    }

    /// get_program_signup_info response
    public class GetProgramSignupInfoStep1
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string bill_first_name { get; set; }
        public string bill_last_name { get; set; }
        public string name_is_different_in_bill { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public object state { get; set; }
        public string post_code { get; set; }
        public string service_address { get; set; }
        public string service_city { get; set; }
    }

    //public class GetProgramSignupInfoStep2
    //{
    //    public string field_id { get; set; }
    //    public string title { get; set; }
    //    public string placeholder { get; set; }
    //    public string helpUrl { get; set; }
    //}

    public class GetProgramSignupInfoResponse
    {
        public int success { get; set; }
        public GetProgramSignupInfoStep1 step1 { get; set; }
    }

    /// get_reset_pin response
    public class GetResetPinResponse
    {
        public bool success { get; set; }
        public string ID { get; set; }
        public string device_id { get; set; }
        public string user_message { get; set; }
        public string session { get; set; }
        public int next_step { get; set; }
    }

    /// get_schedule response
    public class GetScheduleWeekday
    {
        public int start { get; set; }
        public int end { get; set; }
        public int car_ready_by { get; set; }
    }

    public class GetScheduleWeekend
    {
        public int start { get; set; }
        public int end { get; set; }
        public int car_ready_by { get; set; }
    }

    public class GetScheduleResponse
    {
        public string type { get; set; }
        public GetScheduleWeekday weekday { get; set; }
        public GetScheduleWeekend weekend { get; set; }
        public int info_timestamp { get; set; }
        public bool success { get; set; }
        public string ID { get; set; }
    }

    /// get_server_info response
    public class GetServerInfoVersionApi
    {
        public int _Major { get; set; }
        public int _Minor { get; set; }
        public int _Build { get; set; }
        public int _Revision { get; set; }
    }

    public class GetServerInfoImages
    {
        public string charging { get; set; }
        public string standby { get; set; }
        public string plugged { get; set; }
        public string error { get; set; }
        public string disconnect { get; set; }
    }

    public class GetServerInfoDefaultCarModel
    {
        public string model_id { get; set; }
        public string description { get; set; }
        public int year { get; set; }
        public int range_m { get; set; }
        public int range_city_m { get; set; }
        public int range_highway_m { get; set; }
        public int battery_size_wh { get; set; }
        public int charging_rate_w { get; set; }
        public GetServerInfoImages images { get; set; }
    }

    public class GetServerInfoResponse
    {
        public bool success { get; set; }
        public string caller_ip { get; set; }
        public GetServerInfoVersionApi version_api { get; set; }
        public string version_car_model_db { get; set; }
        public GetServerInfoDefaultCarModel default_car_model { get; set; }
    }

    /// get_share_pin response
    public class GetSharePinResponse
    {
        public bool success { get; set; }
        public string pin { get; set; }
    }

    /// get_state response
    public class GetStateCo2
    {
        public int nonstop { get; set; }
        public int actual { get; set; }
    }

    public class GetStateCharging
    {
        public int amps_limit { get; set; }
        public int amps_current { get; set; }
        public int voltage { get; set; }
        public int wh_energy { get; set; }
        public int savings { get; set; }
        public int watt_power { get; set; }
        public int seconds_charging { get; set; }
        public int wh_energy_at_plugin { get; set; }
        public int wh_energy_to_add { get; set; }
        public int flags { get; set; }
        public GetStateCo2 co2 { get; set; }
    }

    public class GetStateLifetime
    {
        public int wh_energy { get; set; }
        public int savings { get; set; }
        public GetStateCo2 co2 { get; set; }
    }

    public class GetStateResponse
    {
        public string ID { get; set; }
        public int info_timestamp { get; set; }
        public bool show_override { get; set; }
        public string state { get; set; }
        public GetStateCharging charging { get; set; }
        public GetStateLifetime lifetime { get; set; }
        public int charging_time_left { get; set; }
        public int plug_unplug_time { get; set; }
        public int target_time { get; set; }
        public int override_time { get; set; }
        public int default_target_time { get; set; }
        public int time_last_ping { get; set; }
        public int utc_time { get; set; }
        public int unit_time { get; set; }
        public int update_interval { get; set; }
        public int temperature { get; set; }
        public int frequency { get; set; }
        public int triggers_all { get; set; }
        public int triggers_blocking { get; set; }
        public bool success { get; set; }
    }

    /// get_timezones response
    public class GetTimezonesTimezone
    {
        public string id { get; set; }
        public string display_name { get; set; }
        public int base_utc_offset { get; set; }
        public int now_utc_offset { get; set; }
        public string standard_name { get; set; }
        public string daylight_name { get; set; }
        public bool supports_daylight { get; set; }
    }

    public class GetTimezonesResponse
    {
        public List<GetTimezonesTimezone> timezones { get; set; }
        public bool success { get; set; }
    }

    /// get_utilitybill_url response
    public class GetUtilitybillUrlResponse
    {
        public int success { get; set; }
        public string uploadTo { get; set; }
        public string downloadFrom { get; set; }
    }

    /// logout response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //LogoutResponse

    /// pair_device response
    public class PairDeviceResponse
    {
        public bool success { get; set; }
        public string ID { get; set; }
        public bool secured { get; set; }
        public int time_last_ping { get; set; }
    }

    /// register_pushes response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //RegisterPushesResponse

    /// reset_ownership response
    public class ResetOwnershipResponse
    {
        public bool success { get; set; }
        public string ID { get; set; }
        public string device_id { get; set; }
        public string user_message { get; set; }
        public string session { get; set; }
        public int next_step { get; set; }
    }

    /// select_car response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //SelectCarResponse

    /// set_charging_time response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //SetChargingTimeResponse

    /// set_garage response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //SetGarageResponse

    /// set_info response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //SetInfoResponse

    /// set_limit response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //SetLimitResponse

    /// set_notifications response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //SetNotificationsResponse

    /// set_override response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //SetOverrideResponse

    /// set_program_signup_info response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //SetProgramSignupInfoResponse

    /// set_schedule response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //SetScheduleResponse

    /// share_device response
    public class ShareDeviceResponse
    {
        public bool success { get; set; }
        public string unit_id { get; set; }
        public string name { get; set; }
        public string token { get; set; }
    }

    /// update_car response
    /// <remarks>
    /// Use "GeneralResponse" class as response model
    /// </remarks>
    //UpdateCarResponse
}
