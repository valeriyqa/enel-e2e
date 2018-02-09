using RestSharp;
using TechTalk.SpecFlow;
using JuiceBoxQA.UITests.Globals;
using JuiceBoxQA.UITests.Helpers;
using AventStack.ExtentReports;

namespace JuiceBoxQA.RestTests.StepDefinitions
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
            restClient = new RestClient(Constants.ApiBaseUrl); //http://emwjuicebox.cloudapp.net

            restRequest = new RestRequest("{season}/circuits.json", Method.GET);

            restRequest.AddUrlSegment("season", season);
        }

        [When(@"I retrieve the circuit list for that season")]
        public void WhenIRetrieveTheCircuitListForThatSeason()
        {
            restResponse = restClient.Execute(restRequest);
        }

        [Then(@"there should be (.*) circuits in the list returned")]
        public void ThenThereShouldBeCircuitsInTheListReturned(string numberOfSeasons)
        {
            //dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(restResponse.Content);

            //Newtonsoft.Json.Linq.JArray circuitsArray = jsonResponse.MRData.CircuitTable.Circuits;

            JBAssert.AssertEquals(null, test, restResponse.Content, numberOfSeasons, "The actual number of circuits in the list is equal to the expected value " + numberOfSeasons.ToString());
        }
    }
}
