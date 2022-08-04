using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using MarsProject1.Utilities;


namespace MarsProject1.Pages
{
    internal class SearchResultsPage
    {
       
        public Boolean VerifyResults(IWebDriver driver,string profile) 
        {
            
            try
            {

               
                //Wait.WaitForClickableWE(driver,"//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span[text()]","By.XPath",15);

               
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);


                IWebElement resultNo = driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span"));
                
               

                if (resultNo.Text != "0")
                {
                    IWebElement result1 = driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[1]"));


                    if (result1.Text == profile)
                    {

                        IWebElement result1Link = driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]/p"));

                        result1Link.Click();
                        return true;

                    }
                    else
                    {
                        MScreenPrint.TakePrint(driver, "No Matching Profile");

                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                
                Assert.Fail(ex.Message);
                
            }

            return false;
        }

        
        public int SendRequest(IWebDriver driver) 
        {
            try
            {
                
                driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(10);
              
                String RequestMsg = driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[1]/h3")).Text;
                
                try   {

                    if (RequestMsg == "Requested")
                    {
                        MScreenPrint.TakePrint(driver, "Request Sent Already");
                        return 5;

                    }
                    else
                    {
                        IWebElement requestMesg = driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/textarea"));
                        requestMesg.SendKeys("Hi, Requesting Services for Delivery. From Sender");

                        MScreenPrint.TakePrint(driver, "Request Services");

                        IWebElement requestButton = driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[3]"));
                        requestButton.Click();

                        IWebElement AcceptAlert = driver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/button[1]"));
                        AcceptAlert.Click();

                        MScreenPrint.TakePrint(driver, "Request Sent");
                        return 1;
                    }
                      }
                catch {

                    MScreenPrint.TakePrint(driver, "Request Sent Already");
                    return 2;
                }


            }
            catch (Exception ex)
            {
                
                Assert.Fail(ex.Message);
                return 4; 

            }


           
        }
    }
}
