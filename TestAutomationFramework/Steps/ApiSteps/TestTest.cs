using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TestAutomationFramework.Services.ApiService;
using TestAutomationFramework.Steps.API;
//using TestAutomationFramework.Configuration;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace TestAutomationFramework.Steps.ApiSteps
{
    [Binding]
    class TestTest
    {
        //private readonly RestApi.ApiData apiData;
        //private Settings settings;

        //public TestTest(RestApi.ApiData apiData, Settings settings)
        //{
        //    this.apiData = apiData;
        //    this.settings = settings;
        //}

        [Given(@"I add unit to account")]
        public void GivenIAddUnitToAccount()
        {
            //AddAccountUnitRequest request = new AddAccountUnitRequest();
            //request.cmd = "add_account_unit";
            //request.account_token = "a0c7b2bc-9492-41a3-8124-99e035816550";
            //request.device_id = "Test device";
            //request.token = "3ffbf508342447a788f5380ab382f57f";

            //Console.WriteLine(settings.environment.api_address);
            //var client = new RestClient(settings.environment.api_address + "box_api_secure");
            //var _request = new RestRequest(Method.POST);
            //_request.AddHeader("Cache-Control", "no-cache");
            //_request.AddHeader("Content-Type", "application/json");
            //_request.AddJsonBody(request);
            //apiData.response = client.Execute(_request);



            //Object response = new RestApi(settings).ResponseToObject(apiData.response);

            //Print response
            //var type = response.GetType();
            //PropertyInfo[] propertyInfo = type.GetProperties();
            //foreach (PropertyInfo property in propertyInfo)
            //{
            //    Console.WriteLine("Property: {0}, is equal to: {1}", property.Name, property.GetValue(response));
            //}
        }

        [Given(@"I wont to send ""(.*)""")]
        public void GivenIWontToSend(string requestCommand)
        {
            var zyka = new RestApi();
            //var answer1 = zyka.generateApiRequest(requestCommand);

            //var answer2 = zyka.generateApiRequest(requestCommand, new Dictionary<string, Object> { { "token", "zzz" }, { "ID", "yyy" } });

            //Console.WriteLine(JsonConvert.SerializeObject(answer1));
            //Console.WriteLine(JsonConvert.SerializeObject(answer2));
        }

        [Given(@"I want to test fignia")]
        public void GivenIWantToTestFignia()
        {
            //var jObject = RestApi.getApiRequest("set_info", new Dictionary<string, Object> { { "token", "zzz" }, { "ID", "yyy" } });
            var response = RestApi.SendApiRequest(RestApi.GetApiRequest("get_program_signup_info"));

            //Print response
            //var type = response.GetType();
            //PropertyInfo[] propertyInfo = type.GetProperties();
            //foreach (PropertyInfo property in propertyInfo)
            //{
            //    Console.WriteLine("Property: {0}, is equal to: {1}", property.Name, property.GetValue(response));
            //}
            Dictionary<string, string> myDict = new Dictionary<string, string>
            {
                //{ "success", "True" },
                { "first_name", "Oleksii" },
                { "last_name", "Khabarov" },
                //{ "bill_first_name", "" },
                //{ "bill_last_name", "" },
                //{ "name_is_different_in_bill", "" },
                { "email", "oleksii.khabarov@emotorwerks.com" },
                //{ "phone_number", "" },
                //{ "address", "null" },
                //{ "city", "null" },
                //{ "state", "null" },
                { "post_code", "94070" },
                //{ "service_address", "" },
                { "service_city", "service_city" }
            };

            //foreach (var item in myDict)
            //{
            //    Console.WriteLine(item.Key + "->" + item.Value);
            //}

            var jObject = JsonConvert.DeserializeObject<GetProgramSignupInfoResponse>(response.Content);



            //foreach (var item in myDict)
            //{
            //    //Console.WriteLine(jObject.GetType().GetProperty(item.Key).Name);

            //}

            //foreach (var item in jObject.GetType().GetProperties())
            //{
            //    Console.WriteLine(item.Name);
            //}

            //var jObject = JObject.Parse(response.Content);

            //foreach (var item in jObject.Properties())
            //{
            //    Console.WriteLine(item.Name + "=" + item.Value);
            //}

        }
    }
}
