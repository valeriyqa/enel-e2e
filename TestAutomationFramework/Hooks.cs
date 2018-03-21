using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace TestAutomationFramework
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;

        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void GetVariables()
        {
            string udpAndApiHost = "https://www.google.com.ua";
            string webHost = "www.google.com";

            try
            {
                udpAndApiHost = Environment.GetEnvironmentVariable("udpAndApiHost");
                webHost = Environment.GetEnvironmentVariable("webHost");
            }
            catch (Exception)
            {

                Console.WriteLine("Unable to get enviroment variables");
            }

            Console.WriteLine(udpAndApiHost);
            Console.WriteLine(webHost);
            try
            {
                Uri uri = new Uri(udpAndApiHost);
                Uri uri2 = new Uri(webHost);

                Console.WriteLine("Scheme = " + uri.Scheme);
                Console.WriteLine("Delimiter = " + Uri.SchemeDelimiter);
                Console.WriteLine("Host = " + uri.Host);
                Console.WriteLine("Port = " + uri.Port);
                Console.WriteLine("Path = " + uri.AbsolutePath);

                Console.WriteLine("Scheme = " + uri2.Scheme);
                Console.WriteLine("Delimiter = " + Uri.SchemeDelimiter);
                Console.WriteLine("Host = " + uri2.Host);
                Console.WriteLine("Port = " + uri2.Port);
                Console.WriteLine("Path = " + uri2.AbsolutePath);
            }
            catch (Exception)
            {

                Console.WriteLine("Incorrect URL format");
            }
        }

        [BeforeScenario("web")]
        public void Initialize()
        {
            //_driver = new FirefoxDriver();
            _driver = new ChromeDriver(@"C:\chromedriver");
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario("web")]
        public void CleanUp()
        {
            _driver.Quit();
        }

    }
}
