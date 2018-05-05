//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestAutomationFramework.POM.Pages
//{
//    class LoginPage
//    {
//        private readonly RemoteWebDriver _driver;

//        public LoginPage(RemoteWebDriver driver) => _driver = driver;


//        IWebElement txtUserName => _driver.FindElementByName("UserName");
//        IWebElement txtPassword => _driver.FindElementByName("Password");
//        IWebElement btnLogin => _driver.FindElementByName("Login");




//        public void EnterUserNameAndPassword(string userName, string password)
//        {
//            txtUserName.SendKeys(userName);
//            txtPassword.SendKeys(password);
//        }

//        public void ClickLogin()
//        {
//            btnLogin.Click();
//        }
//    }
//}
