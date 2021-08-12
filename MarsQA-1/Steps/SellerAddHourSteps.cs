using MarsQA_1.SpecflowPages.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class SellerAddHoursToProfileSteps
    {
        [Given(@"I click on hours")]
        public void GivenIClickOnHours()
        {
            ProfilePage.AddHours();
        }
        
        [When(@"I click on delete hours icon")]
        public void WhenIClickOnDeleteHoursIcon()
        {
            ProfilePage.CancelHours();
        }
        
        [Then(@"I successfully add hours")]
        public void ThenISuccessfullyAddHours()
        {
           
        }
        
        [Then(@"I successfully delete hours")]
        public void ThenISuccessfullyDeleteHours()
        {
           
        }
    }
}
