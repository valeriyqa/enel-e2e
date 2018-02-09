using JuiceBoxQA.UITests.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace JuiceBoxQA.UITests.Pages
{
    public class AddJuiceNetDevicePage : JBLoadableComponent<AddJuiceNetDevicePage>
    {
        private IWebDriver drv;

        private By textlabelErrorMessage = By.XPath("//p[@class='error']");

        public AddJuiceNetDevicePage()
        {
            drv = ScenarioContext.Current.Get<IWebDriver>();
        }

        protected override void ExecuteLoad()
        {
        }

        protected override bool EvaluateLoadedStatus()
        {
            if (!JBElements.WaitForElementOnPageLoad(drv, textlabelErrorMessage))
            {
                UnableToLoadMessage = "Could not load Login error page within the designated timeout period";
                return false;
            }
            return true;
        }

        public string GetErrorMessage()
        {
            return JBElements.GetElementText(drv, textlabelErrorMessage);
        }
    }
}