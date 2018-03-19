using RestSharp;

namespace TestAutomationFramework.Services
{
    public class RestApi
    {
        public RestApi()
        {
            System.Console.WriteLine("Api Start");
            string data = "{\r\n  \"cmd\": \"check_device\",\r\n  \"ID\": \"0100000199990047469017016501\"\r\n}";
            var exitdata = restResponse(data);
            System.Console.WriteLine(exitdata);
            System.Console.WriteLine("Api End");

        }

        public IRestResponse restResponse(string requestData)
        {
            var client = new RestClient("http://emwjuicebox.cloudapp.net/box_pin");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\r\n  \"cmd\": \"check_device\",\r\n  \"ID\": \"0100000199990047469017016501\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);






            return client.Execute(request);
        }
    }
}