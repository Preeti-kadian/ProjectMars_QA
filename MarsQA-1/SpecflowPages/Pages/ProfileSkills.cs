﻿using MarsQA_1.Helpers;
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
    public static class ProfileSkills
    {
        private static IWebElement skills => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        private static IWebElement addNewSkill => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private static IWebElement addSkill => Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));


        private static IWebElement addSkillButton => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        private static IWebElement cancelAddSkill => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[2]"));
        private static IWebElement editSKill => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
        private static IWebElement updateSkillButton => Driver.driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement cancelSkillUpdate => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[2]"));
        private static IWebElement deleteSkill => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
        private static IWebElement skillContent => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[2]/tr/td[1]"));

        //Add new Skill
        public static void AddSkills()
        {
            //Add new skill
            skills.Click();

            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Skills");
            //Read data from excel file
            for (int i = 2; i <= 4; i++)
            {
                Driver.TurnOnWait();
                addNewSkill.Click();
                Driver.TurnOnWait();
                addSkill.SendKeys(ExcelLibHelper.ReadData(i, "Skillls"));
                Driver.TurnOnWait();
                //Select option from drop down list
                SelectElement skillsdropdown = new SelectElement(Driver.driver.FindElement(By.Name("level")));
                Driver.TurnOnWait();
                //Generating random value to select option from dropdown list
                Random rnd = new Random();
                int count = rnd.Next(1, i);
                skillsdropdown.SelectByIndex(count);

                //Thread.Sleep(500);
                addSkillButton.Click();
                Thread.Sleep(1500);
            }
        }

        //Validate added skill
        public static void ValidateAddSkills()
        {
            //Validate the skills are added sucessfully
            try
            {
                //Start Reports
                test = extent.CreateTest("Add skills");
                test.Log(Status.Info, "Adding skills");
                String expectedValue = ExcelLibHelper.ReadData(2, "Skills");
                //List table data       
                IList<IWebElement> rows = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Read the row count in table
                for (var i = 1; i < rows.Count; i++)
                {
                    Thread.Sleep(4000);
                    string actualValue = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    //Verify if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        test.Log(Status.Pass, "Skills added Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillsAdd");
                        Assert.IsTrue(true);
                    }
                    else
                        test.Log(Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(1500);

        }
        //Update added skills

    public static void UpdateSkills()
        {
            skills.Click();
      
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Skills");
   
            //Update and read Skills from Excel data
            for (int i = 1; i <= 3; i++)
            {
            
                IWebElement editIcon = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                Thread.Sleep(2000);
                //Click on Edit skills icon
                editIcon.Click();
                //Clear content for skills input 
                addSkill.Clear();
                Thread.Sleep(500);
                //Read updated skills from Excel file
                addSkill.SendKeys(ExcelLibHelper.ReadData(i + 1, "Updated_Skills"));
                
                // Select and input value from Skills level dropdown list
                SelectElement skillsdropdown = new SelectElement(Driver.driver.FindElement(By.Name("level")));
                //Generating random value to select option from dropdown list
                Random rnd = new Random();
                int count = rnd.Next(1, i);
                skillsdropdown.SelectByIndex(count);
                Thread.Sleep(1500);
                //Save updated Skills
                updateSkillButton.Click();
                Thread.Sleep(3000);
            }

        }

        public static void ValidateUpdateSkills()
        {
            //Validate the skills are updated sucessfully
            try
            {
                //Start Reports
                test = extent.CreateTest("Update Skills");
                test.Log(Status.Info, "Updating Skills");
                String expectedValue = ExcelLibHelper.ReadData(2, "Updated_Skills");
                //List table data       
                IList<IWebElement> rows = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Read the row count in table
                for (var i = 1; i < rows.Count; i++)
                {
                    Thread.Sleep(4000);
                    string actualValue = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    //Verify if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        test.Log(Status.Pass, " Skills Update Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "skillsUpdate");
                        Assert.IsTrue(true);
                    }
                    else
                        test.Log(Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(1500);

        }


        //Delete skills
        public static void DeleteSkills()
        { 
            skills.Click();
            Driver.TurnOnWait();
            IList<IWebElement> rows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr"));
            //Read the row count in table
            for (var i = 1; i <= rows.Count; i++)
            {

                deleteSkill.Click();
                Thread.Sleep(2000);
            }
        }

        //Validate if skill is deleted successfully
        public static void ValidateDeleteSkills()
        {
            try
            {
                //Start Reports
                test = extent.CreateTest("Delete Skills");
                test.Log(Status.Info, "Deleting skills");

                //List table data       
                IList<IWebElement> rows = Driver.driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Read the row count in table
                for (var i = 1; i < rows.Count; i++)
                {
                    Thread.Sleep(4000);
                    string actualValue = Driver.driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    //Verify if actual value is equal to null
                    if (actualValue == null)
                    {
                        test.Log(Status.Pass, " Skills delete Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "DeleteSkills");
                        Assert.IsTrue(true);
                    }
                    else
                        test.Log(Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(1500);
        }
    }
}

