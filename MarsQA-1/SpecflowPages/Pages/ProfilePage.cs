using MarsQA_1.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;
using static MarsQA_1.Helpers.CommonMethods;
using AventStack.ExtentReports;

namespace MarsQA_1.SpecflowPages.Pages 
{
    public static class ProfilePage
    {

        private static IWebElement profileTab => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]"));
        private static IWebElement description => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
        private static IWebElement languages => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
  
        private static IWebElement education => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
        private static IWebElement certifications => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
        private static IWebElement earnTarget => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));

        //Description details
        private static IWebElement editDescriptionIcon = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
        private static IWebElement descriptionText => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
        private static IWebElement descriptionSave => Driver.driver.FindElement(By.XPath("//button[@type='button']"));

        //Availability functionality
        private static IWebElement availability => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
        private static IWebElement selectAvailability => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));
        private static IWebElement cancelAvaialbility => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));

        //Hours details
        private static IWebElement hours => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
        private static IWebElement selectAvailabilityHours => Driver.driver.FindElement(By.XPath("//select[@name='availabiltyHour']"));
        private static IWebElement cancelHours => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
        
        // Save Description
        public static void SaveDescription()
        {
            //Click on edit description icon
            editDescriptionIcon.Click();
            //Read description from Excel file
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Description");
            Thread.Sleep(1000);
            descriptionText.SendKeys(ExcelLibHelper.ReadData(2, "Description"));
            Thread.Sleep(2000);
            //Save description added from Excel
            descriptionSave.Click();
        }

        
        //Add Availability
        public static void SelectAvailibilty()
        {
            //Click on edit availablity
            availability.Click();
            //Select options from dropdown list
            SelectElement dropSelectAvailability = new SelectElement(selectAvailability);
            Random rnd = new Random();
            int count = rnd.Next(1, 2);
            dropSelectAvailability.SelectByIndex(count);
 
        }

        public static void CancelAvailability()
        {
            cancelAvaialbility.Click();
        }

        //Add Hours
        public static void AddHours()
        {
            //Click on add hours icon 
            hours.Click();
            //Select available hours option
            Thread.Sleep(1000);
            SelectElement dropAvailabilityHours = new SelectElement(selectAvailabilityHours);
            Random rnd = new Random();
            int count = rnd.Next(1, 3);
            Thread.Sleep(2000);
            dropAvailabilityHours.SelectByIndex(count);

        }

        //Cancel added Hours
        public static void CancelHours()
        {
            cancelHours.Click();
        }














    }
}



