using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;
using TestAutomationFramework.Services.ApiService;

namespace TestAutomationFramework.Steps.API
{
    [Binding]
    class B2cApiTestSteps
    {
        //The POCO for sharing data
        public class ApiData
        {
            public IRestResponse response;
            public string requestCmd;
            public Object respObject;
        }

        private readonly ApiData apiData;
        public B2cApiTestSteps(ApiData apiData)
        {
            this.apiData = apiData;
        }

        [When(@"I send ""(.*)"" request")] //done
        public void ISendRequest(string requestCmd)
        {
            apiData.requestCmd = requestCmd;
            apiData.response = RestApi.SendApiRequest(RestApi.GetApiRequest(requestCmd));
            if (apiData.response.Content.Contains("\"success\": false"))
            {
                apiData.respObject = RestApi.ResponseToObject("GeneralError", apiData.response);
            }
            else
            {
                apiData.respObject = RestApi.ResponseToObject(requestCmd, apiData.response);
            }
            Console.WriteLine(apiData.response.Content);
        }

        [When(@"I send ""(.*)"" request with next ""(.*)"" ""(.*)""")] //done
        public void ISendRequestWithNext(string requestCmd, string propertyName, string propertyValue)
        {
            var dictionary = new Dictionary<string, Object>
            {
                { propertyName, RestApi.ConvertTypeByName(propertyValue) }
            };

            apiData.requestCmd = requestCmd;
            apiData.response = RestApi.SendApiRequest(RestApi.GetApiRequest(requestCmd, dictionary));
            if (apiData.response.Content.Contains("\"success\": false"))
            {
                apiData.respObject = RestApi.ResponseToObject("GeneralError", apiData.response);
            }
            else
            {
                apiData.respObject = RestApi.ResponseToObject(requestCmd, apiData.response);
            }
        }

        [When(@"I send ""(.*)"" request with next (.*) (.*)")] //done
        public void ISendRequestWithNext(string requestCmd, string propertyName, string propertyValue, Table table)
        {
            var dictionary = new Dictionary<string, Object>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], RestApi.ConvertTypeByName(row[1]));
            }

            apiData.requestCmd = requestCmd;
            apiData.response = RestApi.SendApiRequest(RestApi.GetApiRequest(requestCmd, dictionary));
            if (apiData.response.Content.Contains("\"success\": false"))
            {
                apiData.respObject = RestApi.ResponseToObject("GeneralError", apiData.response);
            }
            else
            {
                apiData.respObject = RestApi.ResponseToObject(requestCmd, apiData.response);
            }
        }

        [Then(@"response should be valid to schema")] //done
        public void ResponseShouldBeValidToSchema()
        {
            Assert.AreEqual(apiData.response.IsSuccessful, true);
            Assert.AreEqual(apiData.response.StatusCode, HttpStatusCode.OK);
            Assert.That(JsonConvert.DeserializeObject<JObject>(apiData.response.Content).IsValid(RestApi.GetJSchema(apiData.requestCmd)));
        }

        [Then(@"response should be valid to schema ""(.*)""")] //done
        public void ResponseShouldBeValidToSchema(string shemaName)
        {
            Assert.AreEqual(apiData.response.IsSuccessful, true);
            Assert.AreEqual(apiData.response.StatusCode, HttpStatusCode.OK);
            Assert.That(JsonConvert.DeserializeObject<JObject>(apiData.response.Content).IsValid(RestApi.GetJSchema(shemaName)));
        }

        //Assert that property equal to expected result.
        //This method will convert data to the corresponding type before assertion.
        [Given(@"property ""(.*)"" should be equal to ""(.*)""")] //done
        [Then(@"property ""(.*)"" should be equal to ""(.*)""")]
        public void PropertyShouldBeEqualTo(string propertyName, string value)
        {
            if (value.ToLower().Equals("null"))
            {
                Assert.AreEqual(RestApi.GetPropertyValue(apiData.respObject, propertyName), null);
            }
            else if (bool.TryParse(value, out bool bResult))
            {
                Assert.AreEqual((bool)RestApi.GetPropertyValue(apiData.respObject, propertyName), bResult);
            }
            else if (Int32.TryParse(value, out int iResult))
            {
                Assert.AreEqual((int)RestApi.GetPropertyValue(apiData.respObject, propertyName), iResult);
            }
            else if (double.TryParse(value, out double dResult))
            {
                Assert.AreEqual((double)RestApi.GetPropertyValue(apiData.respObject, propertyName), dResult);
            }
            else if (DateTime.TryParse(value, out DateTime dtResult))
            {
                Assert.AreEqual((DateTime)RestApi.GetPropertyValue(apiData.respObject, propertyName), dtResult);
            }
            else
            {
                Assert.AreEqual((string)RestApi.GetPropertyValue(apiData.respObject, propertyName), value);
            }
        }

        [Given(@"property ""(.*)"" should be equal to ""(.*)""")]
        [Then(@"property ""(.*)"" should be equal to ""(.*)""")]
        public void PropertyShouldBeEqualTo(string propertyName, string value, Table table)
        {
            foreach (var row in table.Rows)
            {
                if (row[1].ToLower().Equals("null"))
                {
                    Assert.AreEqual(RestApi.GetPropertyValue(apiData.respObject, row[0]), null);
                }
                else if (bool.TryParse(row[1], out bool bResult))
                {
                    Assert.AreEqual((bool)RestApi.GetPropertyValue(apiData.respObject, row[0]), bResult);
                }
                else if (Int32.TryParse(row[1], out Int32 iResult))
                {
                    Assert.AreEqual((Int32)RestApi.GetPropertyValue(apiData.respObject, row[0]), iResult);
                }
                else if (double.TryParse(row[1], out double dResult))
                {
                    Assert.AreEqual((double)RestApi.GetPropertyValue(apiData.respObject, row[0]), dResult);
                }
                else if (DateTime.TryParse(row[1], out DateTime dtResult))
                {
                    Assert.AreEqual((DateTime)RestApi.GetPropertyValue(apiData.respObject, row[0]), dtResult);
                }
                else
                {
                    Assert.AreEqual((string)RestApi.GetPropertyValue(apiData.respObject, row[0]), row[1]);
                }
            }
        }

        //Assert that property equal to expected result.
        //This method, will always use string data type.
        [Given(@"property ""(.*)"" should be equal to ""(.*)"" string")]
        [Then(@"property ""(.*)"" should be equal to ""(.*)"" string")]
        public void PropertyShouldBeEqualToString(string propertyName, string result)
        {
            Assert.AreEqual((string)RestApi.GetPropertyValue(apiData.respObject, propertyName), result);
        }


        [Given(@"program signup info is not set")] //done
        public void ProgramSignupInfoIsNotSet()
        {
            RestApi.SendApiRequest(RestApi.GetApiRequest("delete_program_signup_info"));
        }

        [Given(@"JuiceBox unit is not added")]
        public void JuiceBoxUnitIsNotAdded()
        {
            RestApi.SendApiRequest(RestApi.GetApiRequest("delete_account_unit"));
        }

        [Then(@"response should contain device number is ""(.*)""")]
        public void ThenResponseShouldContainDeviceNumberIs(string shouldExist)
        {
            Assert.AreEqual(apiData.response.Content.Contains("\"unit_id\": \"373708002\""), bool.Parse(shouldExist));
        }

        [Then(@"response should contain device with ""(.*)"" is ""(.*)""")]
        public void ThenResponseShouldContainDeviceWithIs(string deviceNumber, string shouldExist)
        {
            Assert.AreEqual(apiData.response.Content.Contains("\"unit_id\": \"" + deviceNumber + "\""), bool.Parse(shouldExist));
        }


        /////////////////////////////////////////////////////////////////////////////////////
        [Given(@"I add unit to account with next preconditions:")]
        public void GivenIAddUnitToAccountWithNextPreconditions(Table dataTable)
        {
            //var requestsForAlltSystem = dataTable.CreateSet<Models.AddAccountUnit>();
            //foreach (var row in requestsForAlltSystem)
            //{

            //}

            //public static IDictionary LoadVariablesFromFile(string fileName, string sheetName, string useColumnAsKey)
            //{
            //    string workEnvironment = GetEnvironment("environment");
            //    string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resource\", fileName);
            //    return GetDictionary(LoadDataTable(pathFile, sheetName), useColumnAsKey, workEnvironment);
            //}



            //[Given(@"I add unit to account")]
            //public void GivenIAddUnitToAccount()
            //{
            //    apiData.response = new RestApi().GetRestApiResponse("add_account_unit");
            //    if (apiData.response.Content.)
            //    {

            //    }
            //    apiData.jObject = new RestApi().responseToJObject(apiData.response);

        }

        //Not implemented yet!
        [Then(@"I delete unit from account")]
        public void IDeleteUnitFromAccount()
        {
            Console.WriteLine("I delete unit from account");
        }

        //Not implemented yet!
        [Then(@"unit history should be empty")]
        public void UnitHistoryShouldBeEmpty()
        {
            Console.WriteLine("unit history should be empty");
        }

        //Not implemented yet!
        [Then(@"no cars should be associated with unit")]
        public void NoCarsShouldBeAssociatedWithUnit()
        {
            Console.WriteLine("no cars should be associated with unit");
        }

        //Not implemented yet!
        [Then(@"unit should be ""(.*)""")]
        public void UnitShouldBeProcessed(string action)
        {
            switch (action.ToLower())
            {
                case "added":
                    Console.WriteLine("unit should be added");
                    break;
                case "deleted":
                    Console.WriteLine("unit should be deleted");
                    break;
                default:
                    throw new Exception("Illegal value of variable " + action);
            }
        }

        //Not implemented yet!
        [Then(@"program signup info should be ""(.*)""")]
        public void ProgramSignupInfoShouldBeProcessed(string action)
        {
            switch (action.ToLower())
            {
                case "added":
                    Console.WriteLine("program signup info should be added");
                    break;
                case "deleted":
                    Console.WriteLine("program signup info should be deleted");
                    break;
                default:
                    throw new Exception("Illegal value of variable " + action);
            }
        }

        //Not implemented yet!
        [Then(@"car should be ""(.*)""")]
        public void CarShouldBeProcessed(string action)
        {
            switch (action.ToLower())
            {
                case "added":
                    Console.WriteLine("car should be added");
                    break;
                case "selected":
                    Console.WriteLine("car should be selected");
                    break;
                case "updated":
                    Console.WriteLine("car should be updated");
                    break;
                case "deleted":
                    Console.WriteLine("car should be deleted");
                    break;
                default:
                    throw new Exception("Illegal value of variable " + action);
            }
        }

    }
}
