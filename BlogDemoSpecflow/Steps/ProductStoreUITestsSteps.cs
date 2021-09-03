using BlogDemoSpecflow.Drivers;
using BlogDemoSpecflow.POM;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace BlogDemoSpecflow.Steps
{
    [Binding]
    public class ProductStoreUITestsSteps
    {        
        public readonly LandingPage landingpage;
        public readonly RegisterDialog registerLoginDialog;
        public readonly LoginDialog loginDialog;
        public string uniqueUser = "";

        public ProductStoreUITestsSteps(BrowserDriver driver)
        {
            driver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                 
            landingpage = new LandingPage(driver.Current);
            registerLoginDialog = new RegisterDialog(driver.Current);
            loginDialog = new LoginDialog(driver.Current);

        }

        [Given(@"I launch Browser and Navigate to ProductStore Landing Page")]
        public void GivenILaunchBrowserAndNavigateToProductStoreLandingPage()
        {   
            landingpage.NavigateTo_LandingPage(); 
        }

        [Given(@"I navigate to SignUp")]
        public void GivenINavigateToTheSignUpPage()
        {
            landingpage.NavigateTo_SignUp();
        }

        [When(@"I fill the register account dialog with (.*), (.*) and submit")]
        public void WhenIFillTheRegisterAccountFormWithAndSubmit(string p0, string p1)
        {
            uniqueUser = registerLoginDialog.Fill_CredentialsForm(p0, p1);
            registerLoginDialog.SubmitRegister_From();
        }
        
                
        [When(@"I Navigate to Login")]
        public void ThenContinueToMyAccountSection()
        {
            landingpage.NavigateTo_Login();
        }

        [When(@"I fill the login dialog with (.*), (.*) and submit")]
        public void ThebIFillTheLoginDialogWIthAndSubmit(string p0, string p1)
        {
            loginDialog.Fill_CredentialsForm(uniqueUser, p1);
            loginDialog.SubmitLogin_Form();
        }

        
        [Then(@"I validate that the account was registered")]
        public void ThenIValidateThatTheAccountWasRegistered()
        {
            string msg = registerLoginDialog.GetAlertTextAndDismiss();
            msg.Should().Be("Sign up successful.", "Because it means account was registered sucessfully");
        }


        [Then(@"I validate that I am able to login sucessfully")]
        public void ThenIValidateThatIAMABleToLoginSucessfully()
        {   
            string msg = landingpage.GetSignedUser();
            msg.Should().Contain(uniqueUser, "Because it means that the user was able to login sucessfully");
        }

    }
}
