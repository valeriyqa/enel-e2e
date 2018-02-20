#region

using AventStack.ExtentReports;
using RestSharp;
using TechTalk.SpecFlow;
using static APITests.Globals.Constants;

#endregion

namespace APITests.StepDefinitions
{
    [Binding]
    public class CircuitsApiSteps
    {
        private static IRestResponse _restResponse;
        private RestClient _restClient;
        private RestRequest _restRequest;
        private ExtentTest _test;

        public CircuitsApiSteps(ExtentTest test)
        {
            _test = test;
        }

        [Given(@"I want to know the number of Formula One races in (.*)")]
        public void IWantToKnowTheNumberOfFormulaOneRacesIn(string season)
        {
            var restClient = new RestClient(ApiBaseUrl); //http://emwjuicebox.cloudapp.net
//            var restRequest = restClient.Execute(restClient, Method.GET);
//            _restRequest.AddUrlSegment(season);
        }

        [When(@"I retrieve the circuit list for that season")]
        public void WhenIRetrieveTheCircuitListForThatSeason()
        {
            _restResponse = _restClient.Execute(_restRequest);
        }

        [Then(@"there should be (.*) circuits in the list returned")]
        public void ThenThereShouldBeCircuitsInTheListReturned(int numberOfSeasons)
        {
//        internal dynamic deserializeObject = JsonConvert(_restResponse.Content);
//        internal static dynamic jsonResponse = deserializeObject;
//        internal JArray circuitsArray = jsonResponse.MRData.CircuitTable.Circuits;
        }
    }
}