﻿#region

using AventStack.ExtentReports;
using RestSharp;
using TechTalk.SpecFlow;
using UITests.Globals;

#endregion

namespace RestSharpUITests.StepDefinitions
{
    [Binding]
    public class CircuitsSteps
    {
        private RestClient restClient;
        private RestRequest restRequest;
        private IRestResponse restResponse;

        private ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();

        [Given(@"I want to know the number of Formula One races in (.*)")]
        public void GivenIWantToKnowTheNumberOfFormulaOneRacesIn(string season)
        {
            restClient = new RestClient(Constants.ApiBaseUrl); //http://ergast.com/api/f1

            restRequest = new RestRequest("{season}/circuits.json", Method.GET);

            restRequest.AddUrlSegment("season", season);
        }

        [When(@"I retrieve the circuit list for that season")]
        public void WhenIRetrieveTheCircuitListForThatSeason()
        {
            restResponse = restClient.Execute(restRequest);
        }

        [Then(@"there should be (.*) circuits in the list returned")]
        public void ThenThereShouldBeCircuitsInTheListReturned(int numberOfSeasons)
        {
//            dynamic jsonResponse = JsonConvert.DeserializeObject(restResponse.Content);
//
//            JArray circuitsArray = jsonResponse.MRData.CircuitTable.Circuits;
//
//            OTAAssert.AssertEquals(null, test, circuitsArray.Count, numberOfSeasons, "The actual number of circuits in the list is equal to the expected value " + numberOfSeasons.ToString());
        }
    }
}