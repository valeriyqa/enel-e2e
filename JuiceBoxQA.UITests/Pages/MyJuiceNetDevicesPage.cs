namespace JuiceBoxQA.UITests
{
    using OpenQA.Selenium;

    public class MyJuiceNetDevicePage
    {
        IWebDriver drv;

        string DefaultUrl = "https://dashboard.emotorwerks.com/Portal";

        public IWebElement UpdateUnitListButton { get { return drv.FindElement(By.Id("update-unit-list-button")); } }
        public IWebElement AddUnitCircleButton { get { return drv.FindElement(By.XPath("(//button[@data-target='#AddUnitModal'])[1]")); } }
        public IWebElement AddUnitSquareButton { get { return drv.FindElement(By.XPath("(//button[@data-target='#AddUnitModal'])[2]")); } }

        public IWebElement NewUnitIdForm { get { return drv.FindElement(By.XPath("//form[@action='/Portal/AddUnit']")); } }
        public IWebElement NewUnitIdField { get { return drv.FindElement(By.Id("inputUnitID")); } }

        public MyJuiceNetDevicePage(IWebDriver drv)
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

        public void UpdateUnitList()
        {
            UpdateUnitListButton.Click();
        }

        public void AddUnitByCircleButton(string unitId)
        {
            AddUnitCircleButton.Click();
            NewUnitIdField.SendKeys(unitId);
            NewUnitIdForm.Submit();
        }

        public void AddUnitBySquareButton(string unitId)
        {
            AddUnitSquareButton.Click();
            NewUnitIdField.SendKeys(unitId);
            NewUnitIdForm.Submit();
        }
    }
}