using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using System;
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
            apiData.requestCmd = requestCmd;

            Console.WriteLine("Send RestAPI request: " + requestCmd);
            //apiData.response = new RestApi().GetRestApiResponse(requestCmd);
            //apiData.jObject = new RestApi().responseToJObject(apiData.response);
        }

        [Then(@"response should be valid to schema")]
        public void ResponseShouldBeValidToSchema()
        {
            //var schema = new RestApi().GetJSchema(apiData.restApi);

            Console.WriteLine("Response equat to " + apiData.response.Content);

            //Assert.That(apiData.jObject.IsValid(schema));
            Assert.AreEqual(apiData.response.IsSuccessful, true);
            Assert.AreEqual(apiData.response.StatusCode, HttpStatusCode.OK);
        }

        [Given(@"property ""(.*)"" should be equal to ""(.*)""")]
        [Then(@"property ""(.*)"" should be equal to ""(.*)""")]
        public void PropertyShouldBeEqualTo(string propertyName, string result)
        {
            if (result.ToLower().Equals("null"))
            {
                Assert.AreEqual(apiData.jObject.Property(propertyName), null);
            }
            else if (bool.TryParse(result, out bool bResult))
            {
                Assert.AreEqual((bool)apiData.jObject.Property(propertyName), bResult);
            }
            else if (Int32.TryParse(result, out int iResult))
            {
                Assert.AreEqual((int)apiData.jObject.Property(propertyName), iResult);
            }
            else if (double.TryParse(result, out double dResult))
            {
                Assert.AreEqual((double)apiData.jObject.Property(propertyName), dResult);
            }
            else if (DateTime.TryParse(result, out DateTime dtResult))
            {
                Assert.AreEqual((DateTime)apiData.jObject.Property(propertyName), dtResult);
            }
            else
            {
                Assert.AreEqual(apiData.jObject.Property(propertyName), result);
            }
        }

        [Given(@"property ""(.*)"" should be equal to string ""(.*)""")]
        public void PropertyShouldBeEqualToString(string propertyName, string result)
        {
            Assert.AreEqual(apiData.jObject.Property(propertyName), result);
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

        [Then(@"I delete unit from account")]
        public void IDeleteUnitFromAccount()
        {
            Console.WriteLine("I delete unit from account");
        }


        [Given(@"program signup info is not set")]
        public void ProgramSignupInfoIsNotSet()
        {
            Console.WriteLine("program signup info is not set");
        }

        [Then(@"unit history should be empty")]
        public void UnitHistoryShouldBeEmpty()
        {
            Console.WriteLine("unit history should be empty");
        }

        [Then(@"no cars should be associated with unit")]
        public void NoCarsShouldBeAssociatedWithUnit()
        {
            Console.WriteLine("no cars should be associated with unit");
        }

        [Then(@"response should be valid to schema ""(.*)""")]
        public void ResponseShouldBeValidToSchema(string shemaName)
        {
            Console.WriteLine("response should be valid to schema");
        }

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
