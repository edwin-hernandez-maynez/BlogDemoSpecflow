using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BlogDemoSpecflow.POM
{
    public class LandingPage
    {
        #region DEFINITIONS:

        private const string Url = "https://www.demoblaze.com/";

        private readonly IWebDriver _webDriver;


        #endregion


        #region ELEMENTS REPOSITORY HERE:
        private IWebElement TopBanner_SignUpLink => _webDriver.FindElement(By.XPath("//a[text() = 'Sign up']"));
        private IWebElement TopBanner_LogInLink => _webDriver.FindElement(By.XPath("//a[text() = 'Log in']"));
        private IWebElement TopBanner_NameOfUser => _webDriver.FindElement(By.Id("nameofuser"));

        #endregion


        public LandingPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void NavigateTo_SignUp()
        {
            TopBanner_SignUpLink.Click();
        }

        internal void NavigateTo_LandingPage()
        {
            _webDriver.Navigate().GoToUrl(Url);
            _webDriver.Manage().Window.Maximize();
        }

        internal void NavigateTo_Login()
        {
            TopBanner_LogInLink.Click();
        }

        internal string GetSignedUser()
        {
            Thread.Sleep(2000);
            var msg = TopBanner_NameOfUser.Text;
            return msg;
        }
    }
}