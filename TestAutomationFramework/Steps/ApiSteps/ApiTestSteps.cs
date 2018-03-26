using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TestAutomationFramework.Services;

namespace TestAutomationFramework.Steps.API
{
    [Binding]
    class ApiTestSteps
    {
        private IRestResponse _response;
        private string _restApi;

        [Given(@"I send ""(.*)"" request")]
        public void GivenISendRequest(string restApi)
        {
            Console.WriteLine("Start RestAPI test for the request: " + restApi);
            _response = new RestApi().GetRestApiResponse(restApi);
            _restApi = restApi;
         }

        [Then(@"I should receive correct response")]
        public void ThenIShouldReceiveCorrectResponse()
        {
            var _jobject = new RestApi().responseToJObject(_response);
            var _schema = new RestApi().GetJSchema(_restApi);

            Console.WriteLine("_response = " + _response.Content);

            Assert.That(_jobject.IsValid(_schema));
            Assert.AreEqual(_response.IsSuccessful, true);
            Assert.AreEqual(_response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual((bool)_jobject.Property("success"), true);
            Assert.AreEqual(_jobject.Property("error_code"), null);
            Assert.AreEqual(_jobject.Property("error_message"), null);
        }
    }
}
