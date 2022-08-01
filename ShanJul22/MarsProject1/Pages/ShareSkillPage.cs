using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using MarsProject1.Utilities;
using NUnit.Framework;


using SeleniumExtras.PageObjects;


namespace MarsProject1.Pages
{
    internal class ShareSkillPage
    {
       
        public void GoToShareASkill(IWebDriver driver)
        {
            try
            {

                
                MScreenPrint.TakePrint(driver,"ProfilePage");

                Wait.FluentWaitForClickableWE(driver, "By.XPath", "//*[@id='account-profile-section']/div/section[1]/div/div[2]/a", 15);

                IWebElement shareSkill = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[2]/a"));
                shareSkill.Click();



            }

            catch (Exception ex)
            {

                Assert.Fail("ShareSkill Link Failed to Open ", ex.Message);


            }
        }

        private void AddTitle(IWebDriver driver, string strTitle, Boolean myError)
        {
            try
            {
                IWebElement title = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
                if (myError) { title.Clear(); }
                title.SendKeys(strTitle);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

            }
        }


        private void AddDescription(IWebDriver driver, string strDesc, Boolean myError)
        {
            try
            {
                IWebElement description = driver.FindElement(By.Name("description"));
                if (myError) { description.Clear(); }
                description.SendKeys(strDesc);

            }

            catch (Exception ex)
            { Assert.Fail(ex.Message); }


        }

        private void AddStrtDate(IWebDriver driver, string strStDate, Boolean myError)
        {
            Console.WriteLine(strStDate);
            try
            {
                IWebElement startDate = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div[1]/div[1]/div[2]/input"));
                if (myError) { startDate.Clear(); }
                startDate.SendKeys(strStDate);


            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        private void SaveListing(IWebDriver driver, string strTitle,string p3,string p4, string p5)
        {
            int cnt = 0;

            void MySave() 
            {
                try
                {
                    cnt++;

                    IWebElement saveMyListing = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]"));
                    saveMyListing.Click();

                    Console.WriteLine("SaveClick");

                    Wait.WaitForVisibleWE(driver, "title", "By.TagName", 15);

                    Console.WriteLine("Wait for Listing Display");
                    MScreenPrint.TakePrint(driver, "AddListingSuccessful");
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }

            }

            void CheckSave() 
            {
                try
                {

                    string strTitle = driver.Title.ToString();

                    if (strTitle == "ListingManagement")
                    {

                        IWebElement myPosting = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
                        if (myPosting.Text == strTitle)
                        {

                            string myText = "Listing Add Has Been Successful";
                            Console.WriteLine(myText);
                        }

                    }
                    else if (strTitle == "ServiceListing")
                    {
                        Console.WriteLine("InCorrect Listing Data");
                        Boolean myTitleEntry = IncorrectTitle(driver, p3, true);
                        if (myTitleEntry) MScreenPrint.TakePrint(driver, "CorrectTitle");

                        Boolean myDescEntry = IncorrectDesc(driver, p4, true);
                        if (myDescEntry) MScreenPrint.TakePrint(driver, "CorrectDescription");

                        Boolean myStartDateEntry = IncorrectStrtDate(driver, p5, true);
                        if (myStartDateEntry) MScreenPrint.TakePrint(driver, "CorrectStartDate");
                        MySave();

                    }

                }
                catch (Exception ex) 
                {
                    Assert.Fail(ex.Message);
                }
            }


            MySave();CheckSave();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }


        public void AddListing(IWebDriver driver, string p0, string p1, string p2, string p3, string p4, string p5)
        {
            string strTitle = p0; string strDesc = p1; string strStDate = p2;

            try
            {
                
                Wait.WaitForClickableWE(driver, "By.XPath", "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input", 10);

                AddTitle(driver, strTitle, false);

                AddDescription(driver, strDesc, false);

                MScreenPrint.TakePrint(driver, "AddListingWithInput");

                IWebElement selectCategory = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[7]"));
                selectCategory.Click();



                IWebElement selectSubCategory = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[5]"));
                selectSubCategory.Click();

                IWebElement tag1 = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
                tag1.SendKeys("C+"); tag1.SendKeys(Keys.Return);



                IWebElement tag1Sub = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
                tag1Sub.SendKeys("Visual Studio");
                tag1Sub.SendKeys(Keys.Return);


                IWebElement serviceType = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));
                serviceType.Click();


                IWebElement locationType = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
                locationType.Click();

                AddStrtDate(driver, strStDate, false);
                MScreenPrint.TakePrint(driver, "AddStartDate");

                IWebElement availableDay1 = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input"));
                availableDay1.Click();

                IWebElement availableDay1St = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input"));
                availableDay1St.SendKeys("10:05AM");

                IWebElement availableDay1Fn = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input"));
                availableDay1St.SendKeys("11:00AM");


                IWebElement skillTrade = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
                skillTrade.Click();


                IWebElement skillCredit = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/input"));
                skillCredit.Click();

                IWebElement activeListing = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));
                activeListing.Click();

                SaveListing(driver, strTitle,p3,p4,p5);
            }
            catch(Exception ex)
            {
                
                    
                Assert.Fail("Exited with Error" + ex.Message);
                

            }

        }

        private Boolean IncorrectTitle(IWebDriver driver, string cTitle, Boolean errorStatus)
        {
            try
            {
                IWebElement Title = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[2]"));
                var errorList = Title.FindElements(By.TagName("div"));
                if (errorList.Count != 0)
                {
                    if (driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[2]/div")).Displayed)
                    {
                        AddTitle(driver, cTitle, true);
                        return true;
                    }
                    else { Console.WriteLine("Cannot Find InValid Title Error"); return false; }

                }
                else {
                       Console.WriteLine("No Error Message Found"); return false; }

            }
            catch(Exception ex)
            {
                Assert.Fail("Incorrect Title " + ex.Message);
                return false;
                
            }
        }

        private Boolean IncorrectDesc(IWebDriver driver, string cDesc, Boolean errorStatus)
        {
            try
            {
                IWebElement Descrip = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[2]"));
                var descripList = Descrip.FindElements(By.TagName("div"));
                if (descripList.Count != 0)
                {
                    if (driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[2]/div")).Displayed)
                    {
                        AddDescription(driver, cDesc, true);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Cannot Find InValid Description Error"); return false;
                    }
                }
                else
                {
                    Console.WriteLine("No Error Message Found"); return false;
                }
            }

            catch(Exception ex)
            {
                Assert.Fail("Incorrect Description " + ex.Message);
                return false;
                
            }
        }


        private Boolean IncorrectStrtDate(IWebDriver driver, string cDate, Boolean errorStatus)
        {
            try
            {
                                                                    
                IWebElement startDt = driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]"));
                var startDtList = startDt.FindElements(By.TagName("div"));
                if (startDtList.Count > 1)
                {
                    if (driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div[2]")).Displayed)
                    {
                        AddStrtDate(driver, cDate, true);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Cannot Find InValid Start Date Error"); return false;
                    }
                }
                else
                {
                    Console.WriteLine("No Error Message Found"); return false;
                }

               
            }

            catch(Exception ex)
            {

                Assert.Fail("Incorrect Date "+ex.Message);
                return false;
            }
        }


    }
}
