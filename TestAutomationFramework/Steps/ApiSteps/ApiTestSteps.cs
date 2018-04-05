using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TestAutomationFramework.Services;
using Newtonsoft.Json.Linq;

namespace TestAutomationFramework.Steps.API
{
    public class ApiData // the POCO for sharing person data
    {
        public IRestResponse response;
        public string restApi;
        public JObject jObject;
    }

    [Binding]
    class ApiTestSteps
    {
        private readonly ApiData apiData;
        public ApiTestSteps(ApiData apiData) // use it as ctor parameter
        {
            this.apiData = apiData;
        }

        [Given(@"I send ""(.*)"" request")]
        public void ISendRequest(string restApi)
        {
            apiData.restApi = restApi;

            Console.WriteLine("Send RestAPI request: " + restApi);
            apiData.response = new RestApi().GetRestApiResponse(restApi);
            apiData.jObject = new RestApi().responseToJObject(apiData.response);
        }

        [Then(@"response should be valid to schema")]
        public void ResponseShouldBeValidToSchema()
        {
            var schema = new RestApi().GetJSchema(apiData.restApi);

            Console.WriteLine("Response equat to " + apiData.response.Content);

            Assert.That(apiData.jObject.IsValid(schema));
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
    }
}
