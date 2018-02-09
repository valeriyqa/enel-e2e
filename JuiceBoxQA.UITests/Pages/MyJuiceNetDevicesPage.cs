using System;
using JuiceBoxQA.UITests.Globals;
using JuiceBoxQA.UITests.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace JuiceBoxQA.UITests.Pages
{
    public class MyJuiceNetDevicesPage : JBLoadableComponent<MyJuiceNetDevicesPage>
    {
        private IWebDriver drv;

        private By updateUnitListButton = By.Id("update-unit-list-button");
        private By addUnitCircleButton = By.XPath("(//button[@data-target='#AddUnitModal'])[1]");
        private By addUnitSquareButton = By.XPath("(//button[@data-target='#AddUnitModal'])[2]");
        private By newUnitIdForm = By.XPath("//form[@action='/Portal/AddUnit']");
        private By newUnitIdField = By.Id("inputUnitID");

        public MyJuiceNetDevicesPage()
        {
            drv = ScenarioContext.Current.Get<IWebDriver>();
        }

        protected override void ExecuteLoad()
        {
        }

        protected override bool EvaluateLoadedStatus()
        {
            if (!JBElements.WaitForElementOnPageLoad(drv, updateUnitListButton))
            {
                UnableToLoadMessage = "Could not load My JuiceNet Devices Page page within the designated timeout period";
                return false;
            }
            return true;
        }

        public MyJuiceNetDevicesPage UpdateUnitList()
        {
            JBElements.Click(drv, updateUnitListButton);
            return this;
        }

        public void AddUnitByCircleButton(string unitId)
        {
            JBElements.Click(drv, addUnitCircleButton);
            JBElements.SendKeys(drv, newUnitIdField, unitId);
            JBElements.Submit(drv, newUnitIdForm);
        }

        public void AddUnitBySquareButton(string unitId)
        {
            JBElements.Click(drv, addUnitSquareButton);
            JBElements.SendKeys(drv, newUnitIdField, unitId);
            JBElements.Submit(drv, newUnitIdForm);
        }

        internal bool IsAt()
        {
            throw new NotImplementedException();
        }
    }
}