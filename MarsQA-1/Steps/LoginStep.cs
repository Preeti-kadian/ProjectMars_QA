using MarsQA_1.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Steps
{
    [Binding]
    public class LoginSteps 
    {
        [Given(@"I click on signin button on Login page")]
        public void GivenIClickOnSigninButtonOnLoginPage()
        {
            MarsQA_1.Pages.SignIn.SigninStep();
        }
        
        [When(@"Click on login button")]
        public void WhenClickOnLoginButton()
        {
            
        }
        
       [Then(@"I login to my profile successfully\.")]
        public void ThenILoginToMyProfileSuccessfully_()
        {
            
        }
        
        [Then(@"I should not be logged in\.")]
        public void ThenIShouldNotBeLoggedIn_()
        {
            SignIn.Login();
            Assert.Pass("Login Unsuccessful, Enter Valid Username and Password");
        }

   
    
            [When(@"I enter valid username and valid password credentials")]
            public void WhenIEnterValidUsernameAndValidPasswordCredentials()
        {
            
        }

        [Given(@"I click on login button")]
        public void GivenIClickOnLoginButton()
        {
            
        }

        [When(@"I enter invalid username and valid password")]
        public void WhenIEnterInvalidUsernameAndValidPassword()
        {
            
        }






    }
}
