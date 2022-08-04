using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

using OpenQA.Selenium;
using NUnit.Framework;
using MarsProject1.Utilities;

namespace MarsProject1.Pages
{
    internal class SellerHomePage
    {

        public Boolean SearchSkill(IWebDriver driver,string skill="Learn Programming")
        {
            try

            {

                WebDriverWait waitElement = new(driver, new TimeSpan(0, 0, 20));
                waitElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='account-profile-section']/div/div[1]")));

                IWebElement searchInput = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/input"));

                searchInput.SendKeys(skill);
                MScreenPrint.TakePrint(driver, "SearchText");

                searchInput.SendKeys(Keys.Return);

                return true;
                
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

            }
            return false;
        }



        public void GoToShareASkill(IWebDriver driver)
        {
            try
            {


                MScreenPrint.TakePrint(driver, "ProfilePage");

                Wait.FluentWaitForClickableWE(driver, "By.XPath", "//*[@id='account-profile-section']/div/section[1]/div/div[2]/a", 15);

                IWebElement shareSkill = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[2]/a"));
                shareSkill.Click();



            }

            catch (Exception ex)
            {

                Assert.Fail("ShareSkill Link Failed to Open ", ex.Message);


            }
        }

        public void GoToSentRequests(IWebDriver driver)
        {

            try
            {

                string manageRequests = "//*[@id='account-profile-section']/div/section[1]/div/div[1]";
                //ManageRequests
                Wait.FluentWaitForClickableWE(driver, "By.XPath", manageRequests, 15);

                IWebElement manageRequestsOption = driver.FindElement(By.XPath(manageRequests));
                manageRequestsOption.Click();

                Wait.WaitForClickableWE(driver, "By.XPath", "//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[2]", 10);

                IWebElement sentRequests = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[2]"));
                sentRequests.Click();



            }

            catch (Exception ex)
            {

                Assert.Fail("Cannot Goto Menu Option Sent Requests"+ex.Message);


            }
        }

        public void GoToReceivedRequests(IWebDriver driver)
        {

                try
                {

                    string manageRequests = "//*[@id='account-profile-section']/div/section[1]/div/div[1]";
                    //ManageRequests
                    Wait.FluentWaitForClickableWE(driver, "By.XPath", manageRequests, 15);

                    IWebElement manageRequestsOption = driver.FindElement(By.XPath(manageRequests));
                    manageRequestsOption.Click();

                    IWebElement receivedRequests = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]"));
                    receivedRequests.Click();



                }

                catch (Exception ex)
                {

                    Assert.Fail("Cannot Goto Menu Option Received Requests", ex.Message);


                }


        }

        




    }

}