namespace TestAutomationFramework.Services.API
{
    public class Models
    {
        //get_account_units
        public class GetAccountUnitsStats
        {
            public bool success { get; set; }
            public UnitStats[] units { get; set; }
        }

        public class UnitStats
        {
            public string name { get; set; }
            public string token { get; set; }
            public string unit_id { get; set; }
        }

        //get_state
        public class GetStateStats
        {
            public string ID { get; set; }
            public int Info_timestamp { get; set; }
            public bool show_override { get; set; }
            public string state { get; set; }
            public ChargingStats charging { get; set; }
            public LifetimeStats lifetime { get; set; }
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
            public int car_id { get; set; }
            public bool success { get; set; }
        }

        public class ChargingStats
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
            public Co2Stats co2 { get; set; }
        }

        public class Co2Stats
        {
            public int nonstop { get; set; }
            public int actual { get; set; }
        }

        public class LifetimeStats
        {
            public int wh_energy { get; set; }
            public int savings { get; set; }
            public Co2Stats co2 { get; set; }
        }

        public enum StateStats
        {
            charging,
            standby,
            plugged,
            error,
            disconnect,
        }

        //check_device
        public class CheckDeviceStats
        {
            public bool success { get; set; }
            public string ID { get; set; }
            public bool Secured { get; set; }
            public int Time_last_ping { get; set; }
        }

        //get_timezones
        public class GetTimezonesStats
        {
            public bool success { get; set; }
            public TimezonesStats[] timezones { get; set; }
        }

        public class TimezonesStats
        {
            public string id { get; set; }
            public string display_name { get; set; }
            public int base_utc_offset { get; set; }
            public int now_utc_offste { get; set; }
            public string standard_name { get; set; }
            public string daylight_name { get; set; }
            public bool supports_daylight { get; set; }
        }

        //get_server_info
        public class GetServerInfoStats
        {
            public bool success { get; set; }
            public string caller_ip { get; set; }
            public VersionApStats version_api { get; set; }
            public string version_car_model_db { get; set; }
            public DefaultCarModelStats default_car_model { get; set; }
        }

        public class VersionApStats
        {
            public string _Major { get; set; }
            public int _Minor { get; set; }
            public int _Build { get; set; }
            public string _Revision { get; set; }
        }

        public class DefaultCarModelStats
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
            public int charging_state_w { get; set; }
            public ImagesStats Images { get; set; }
        }

        public class ImagesStats
        {
            public string charging { get; set; }
            public string Default { get; set; }
            public string plugged { get; set; }
        }

        //get_car_models
        public class GetCarModelsStats
        {
            public bool success { get; set; }
            public string version { get; set; }
            public DefaultCarModelStats models { get; set; }
        }

        //get_history
        public class GetHistoryStats
        {
            public bool success { get; set; }
            public SessionsStats[] sessions { get; set; }
        }

        public class SessionsStats
        {
            public int id { get; set; }
            public int time_start { get; set; }
            public int time_end { get; set; }
            public int duration { get; set; }
            public int wh_energy { get; set; }
        }

        //get_schedule
        public class GetScheduleStats
        {
            public string type { get; set; }
            public WeekdayStats weekday { get; set; }
            public WeekendStats weekend { get; set; }
            public int Info_timestamp { get; set; }
            public bool success { get; set; }
            public string ID { get; set; }
        }

        public class WeekdayStats
        {
            public int start { get; set; }
            public int end { get; set; }
            public int car_ready_by { get; set; }
        }

        public class WeekendStats
        {
            public int start { get; set; }
            public int end { get; set; }
            public int car_ready_by { get; set; }
        }

        //get_info
        public class GetInfoStats
        {
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
            public CarsStats[] cars { get; set; }
            public PolicyStats policy { get; set; }
            public HistoryStats restrictions { get; set; }
            public HistoryStats set_notifications { get; set; }
            public HistoryStats set_override { get; set; }
            public HistoryStats history { get; set; }
            public HistoryStats get_share_pin { get; set; }
        }

        public class CarsStats
        {
            public int car_id { get; set; }
            public string description { get; set; }
            public int battery_size_wh { get; set; }
            public int battery_range_m { get; set; }
            public int charging_rate_w { get; set; }
            public string model_id { get; set; }
            public DefaultCarModelStats[] model_info { get; set; }
        }

        public class PolicyStats
        {
            public bool user_control_allowed { get; set; }
            public string charge_control_type { get; set; }
        }

        public class HistoryStats
        {
            public string message { get; set; }
            public string activation_url { get; set; }
        }

        //get_notifications
        public class GetNotificationsStats
        {
            //Can't find description in documentation
        }

        //get_utilitybill_url
        public class GetUtilitybillUrlStats
        {
            public bool success { get; set; }
            public string uploadTo { get; set; }
            public string downloadFrom { get; set; }
        }

        //get_program_signup_info
        public class GetProgramSignupInfoStats
        {
            public bool success { get; set; }
            public Step1Stats step1 { get; set; }
            public Step2Stats step2 { get; set; }
        }

        public class Step1Stats
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
            public string start { get; set; }
            public string state { get; set; }
            public string post_code { get; set; }
        }

        public class Step2Stats
        {
            public string field_id { get; set; }
            public string title { get; set; }
            public string placeholder { get; set; }
            public string helpUrl { get; set; }
        }
    }
}
