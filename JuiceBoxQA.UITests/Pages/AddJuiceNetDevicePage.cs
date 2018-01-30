namespace JuiceBoxQA.UITests
{
    using OpenQA.Selenium;

    public class AddJuiceNetDevicePage
    {
        IWebDriver drv;

        string DefaultUrl = "https://dashboard.emotorwerks.com/Portal/AddUnit";

        public IWebElement NewUnitIdForm { get { return drv.FindElement(By.XPath("//form[@action='/Portal/AddUnit']")); } }
        public IWebElement NewUnitIdField { get { return drv.FindElement(By.Id("inputUnitID")); } }
        public IWebElement DangerTextArea { get { return drv.FindElement(By.XPath("//*[@class='validation-summary-errors text-danger']")); } }


        public AddJuiceNetDevicePage(IWebDriver drv)
        {
            this.drv = drv;
        }

        public void Open()
        {
            Open(DefaultUrl);
        }

        public void Open(string url)
        {
            //Navigate to the page
            drv.Navigate().GoToUrl(url);
        }

        public void AddUnit(string unitId)
        {
            NewUnitIdField.SendKeys(unitId);
            NewUnitIdForm.Submit();
        }

        public string GetDangerText()
        {
            return DangerTextArea.Text;
        }
    }
}