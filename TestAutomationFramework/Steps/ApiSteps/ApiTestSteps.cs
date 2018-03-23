using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using System;
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

            Assert.That(_jobject.IsValid(_schema));
            Assert.AreEqual(_response.IsSuccessful.ToString(), "True");
            Assert.AreEqual(_response.ResponseStatus.ToString(), "Completed");
            Assert.AreEqual(_response.StatusCode.ToString(), "OK");
            Assert.AreEqual(_response.ErrorMessage, null);
        }
    }
}
