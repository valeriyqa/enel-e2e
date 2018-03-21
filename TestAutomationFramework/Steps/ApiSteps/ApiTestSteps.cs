﻿using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using static TestAutomationFramework.Services.API.Models;

namespace TestAutomationFramework.Steps.API
{
    [Binding]
    class ApiTestSteps
    {
        private string address = Hooks.apiHost;
        //Example how to pass data between scenarios with POCO
        public readonly GetAccountUnitsStats testResp;

        public ApiTestSteps(GetAccountUnitsStats testRes)
        {
            this.testResp = testRes;
        }

        //

        [Given(@"I have sent correct request to the server")]
        public void GivenIHaveSentCorrectRequestToTheServer()
        {
            Console.WriteLine("Api Start");
            Console.WriteLine(address);

            var client = new RestClient(address + "box_pin");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\r\n  \"cmd\": \"check_device\",\r\n  \"ID\": \"0100000199990047469017016501\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            System.Console.WriteLine("Test status: " + response.StatusCode);
            System.Console.WriteLine(response.Content);

            testResp.success = response.IsSuccessful;
            //
            //Example how to desealize response to the object

            IRestResponse<CheckDeviceStats> response2 = client.Execute<CheckDeviceStats>(request);
            var success = response2.Data.success;
            var ID = response2.Data.ID;
            var Secured = response2.Data.Secured;
            var Time_last_ping = response2.Data.Time_last_ping;

            Console.WriteLine("success = " + success);
            Console.WriteLine("ID = " + ID);
            Console.WriteLine("Secured = " + Secured);
            Console.WriteLine("Time_last_ping = " + Time_last_ping);

            //




            System.Console.WriteLine("Api End");
        }

        [Then(@"I should receive corresponding response")]
        public void ThenIShouldReceiveCorrespondingResponse()
        {
            Assert.That(testResp.success);

            System.Console.WriteLine("End " + testResp.success);
            
        }

    }
}