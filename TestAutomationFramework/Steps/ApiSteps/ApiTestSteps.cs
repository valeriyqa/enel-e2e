using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAutomationFramework.Services.ApiService;

namespace TestAutomationFramework.Steps.API
{
    [Binding]
    class ApiTestSteps
    {
        //The POCO for sharing data
        public class ApiData
        {
            public IRestResponse response;
            public string requestCmd;
            public JObject jObject;
        }

        private readonly ApiData apiData;
        public ApiTestSteps(ApiData apiData)
        {
            this.apiData = apiData;
        }

        [When(@"I send ""(.*)"" request")]
        public void ISendRequest(string requestCmd)
        {
            Console.WriteLine("Send RestAPI request: " + requestCmd);
            
            apiData.requestCmd = requestCmd;
            apiData.response = RestApi.SendApiRequest(RestApi.GetApiRequest(requestCmd));
            apiData.jObject = RestApi.ResponseToJObject(apiData.response);
        }

        [When(@"I send ""(.*)"" request with next ""(.*)"" ""(.*)""")]
        public void WhenISendRequestWithNext(string requestCmd, string propertyName, string propertyValue)
        {
            Console.WriteLine("Send RestAPI request: " + requestCmd + " with additional properties (no table)");

            var dictionary = new Dictionary<string, Object>();
            dictionary.Add(propertyName, RestApi.ConvertTypeByName(propertyValue));

            apiData.requestCmd = requestCmd;
            apiData.response = RestApi.SendApiRequest(RestApi.GetApiRequest(requestCmd, dictionary));
            apiData.jObject = RestApi.ResponseToJObject(apiData.response);
        }

        [When(@"I send ""(.*)"" request with next (.*) (.*)")]
        public void WhenISendRequestWithNext(string requestCmd, string propertyName, string propertyValue, Table table)
        {
            Console.WriteLine("Send RestAPI request: " + requestCmd + " with additional properties");

            var dictionary = new Dictionary<string, Object>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], RestApi.ConvertTypeByName(row[1]));
            }

            apiData.requestCmd = requestCmd;
            apiData.response = RestApi.SendApiRequest(RestApi.GetApiRequest(requestCmd, dictionary));
            apiData.jObject = RestApi.ResponseToJObject(apiData.response);

        }

        [Then(@"response should be valid to schema")]
        public void ResponseShouldBeValidToSchema()
        {
            Console.WriteLine("Response: " + apiData.response.Content);

            Assert.AreEqual(apiData.response.IsSuccessful, true);
            Assert.AreEqual(apiData.response.StatusCode, HttpStatusCode.OK);
            Assert.That(apiData.jObject.IsValid(RestApi.GetJSchema(apiData.requestCmd)));
        }

        [Then(@"response should be valid to schema ""(.*)""")]
        public void ResponseShouldBeValidToSchema(string shemaName)
        {
            Console.WriteLine("Response should be valid to schema: " + shemaName);
            Console.WriteLine(apiData.response.Content);

            Assert.AreEqual(apiData.response.IsSuccessful, true);
            Assert.AreEqual(apiData.response.StatusCode, HttpStatusCode.OK);
            Assert.That(apiData.jObject.IsValid(RestApi.GetJSchema(shemaName)));
        }

        //Assert that property equal to expected result.
        //This method will convert data to the corresponding type before assertion.
        [Given(@"property ""(.*)"" should be equal to ""(.*)""")]
        [Then(@"property ""(.*)"" should be equal to ""(.*)""")]
        public void PropertyShouldBeEqualTo(string propertyName, string value)
        {
            if (value.ToLower().Equals("null"))
            {
                Assert.AreEqual(apiData.jObject.Property(propertyName), null);
            }
            else if (bool.TryParse(value, out bool bResult))
            {
                Assert.AreEqual((bool)apiData.jObject.Property(propertyName), bResult);
            }
            else if (Int32.TryParse(value, out int iResult))
            {
                Assert.AreEqual((int)apiData.jObject.Property(propertyName), iResult);
            }
            else if (double.TryParse(value, out double dResult))
            {
                Assert.AreEqual((double)apiData.jObject.Property(propertyName), dResult);
            }
            else if (DateTime.TryParse(value, out DateTime dtResult))
            {
                Assert.AreEqual((DateTime)apiData.jObject.Property(propertyName), dtResult);
            }
            else
            {
                Assert.AreEqual((string)apiData.jObject.Property(propertyName), value);
            }
        }

        [Given(@"property ""(.*)"" should be equal to ""(.*)""")]
        [Then(@"property ""(.*)"" should be equal to ""(.*)""")]
        public void ThenPropertyShouldBeEqualTo(string propertyName, string value, Table table)
        {
            foreach (var row in table.Rows)
            {
                if (row[1].ToLower().Equals("null"))
                {
                    Console.WriteLine("1Property: " + apiData.jObject.Property(row[0]) + " Name: " + row[0] + " Value: " + row[1]);
                    Assert.AreEqual(apiData.jObject.Property(row[0]), null);
                }
                else if (bool.TryParse(row[1], out bool bResult))
                {
                    Console.WriteLine("2Property: " + apiData.jObject.Property(row[0]) + " Name: " + row[0] + " Value: " + row[1]);
                    Assert.AreEqual((bool)apiData.jObject.Property(row[0]), bResult);
                }
                else if (Int32.TryParse(row[1], out int iResult))
                {
                    Console.WriteLine("3Property: " + apiData.jObject.Property(row[0]) + " Name: " + row[0] + " Value: " + row[1]);
                    Assert.AreEqual((int)apiData.jObject.Property(row[0]), iResult);
                }
                else if (double.TryParse(row[1], out double dResult))
                {
                    Console.WriteLine("4Property: " + apiData.jObject.Property(row[0]) + " Name: " + row[0] + " Value: " + row[1]);
                    Assert.AreEqual((double)apiData.jObject.Property(row[0]), dResult);
                }
                else if (DateTime.TryParse(row[1], out DateTime dtResult))
                {
                    Console.WriteLine("5Property: " + apiData.jObject.Property(row[0]) + " Name: " + row[0] + " Value: " + row[1]);
                    Assert.AreEqual((DateTime)apiData.jObject.Property(row[0]), dtResult);
                }
                else
                {
                    Console.WriteLine("6Property: " + apiData.jObject.Property(row[0]) + " Name: " + row[0] + " Value: " + row[1]);
                    Assert.AreEqual((string)apiData.jObject.Property(row[0]), row[1]);
                }
            }
        }

        //Assert that property equal to expected result.
        //This method, will always use string data type.
        [Given(@"property ""(.*)"" should be equal to string ""(.*)""")]
        [Then(@"property ""(.*)"" should be equal to string ""( .*)""")]
        public void PropertyShouldBeEqualToString(string propertyName, string result)
        {
            Assert.AreEqual((string)apiData.jObject.Property(propertyName), result);
        }

        [Given(@"program signup info is not set")]
        public void ProgramSignupInfoIsNotSet()
        {
            Console.WriteLine("program signup info is not set");
            RestApi.SendApiRequest(RestApi.GetApiRequest("delete_program_signup_info"));
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
