using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace BlogDemoSpecflow.POM
{
    public class RegisterDialog
    {
        #region DEFINITIONS:

        private readonly IWebDriver _webDriver;


        #endregion


        #region ELEMENTS REPOSITORY HERE:
        private IWebElement usernameTxBx => _webDriver.FindElement(By.Id("sign-username"));
        private IWebElement passwordTxBx => _webDriver.FindElement(By.Id("sign-password"));
        private IWebElement submitRegisterBtn => _webDriver.FindElement(By.XPath("//button[text()='Sign up']"));
        
        #endregion


        public RegisterDialog(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string Fill_CredentialsForm(string username, string password)
        {
            Thread.Sleep(1000);

            Random ran = new Random();
            int UniqueID = ran.Next(0, 10000);
            var uniqueUser = UniqueID + username;
            usernameTxBx.SendKeys(uniqueUser);
            passwordTxBx.SendKeys(password);

            return uniqueUser;
        }

        public void SubmitRegister_From()
        {
            submitRegisterBtn.Click();
        }

        public string GetAlertTextAndDismiss()
        {
            Thread.Sleep(1000);
            var msg = _webDriver.SwitchTo().Alert().Text;
            _webDriver.SwitchTo().Alert().Dismiss();
            return msg;
        }
    }
}
