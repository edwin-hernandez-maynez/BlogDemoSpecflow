using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace BlogDemoSpecflow.POM
{
    public class LoginDialog
    {
        #region DEFINITIONS:

        private readonly IWebDriver _webDriver;


        #endregion


        #region ELEMENTS REPOSITORY HERE:
        private IWebElement usernameTxBx => _webDriver.FindElement(By.Id("loginusername"));
        private IWebElement passwordTxBx => _webDriver.FindElement(By.Id("loginpassword"));
        private IWebElement submitLoginBtn => _webDriver.FindElement(By.XPath("//button[text()='Log in']"));
        
        #endregion


        public LoginDialog(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Fill_CredentialsForm(string username, string password)
        {
            Thread.Sleep(1000);
            usernameTxBx.SendKeys(username);
            passwordTxBx.SendKeys(password);
        }

        public void SubmitLogin_Form()
        {
            submitLoginBtn.Click();
        }

        public string GetAlertTextAndDismiss()
        {
            var msg = _webDriver.SwitchTo().Alert().Text;
            _webDriver.SwitchTo().Alert().Dismiss();
            return msg;
        }
    }
}
