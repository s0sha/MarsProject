using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using MarsProject1.Utilities;

namespace MarsProject1.Pages
{
    enum SignOutOption { SearchResults, ServiceListing,RequestSent,ManageSentRequests };
    internal class HomePage
    {
       
       

        public void LoginAsUser(IWebDriver driver,string userName,string passWord)
        {
           
            try
            {
                IWebElement signInLink = driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
                
                signInLink.Click();

                IWebElement emailText = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
                
                emailText.SendKeys(userName);

                IWebElement passwordText = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
                passwordText.SendKeys(passWord);

                //MScreenPrint.TakePrint(driver,"login");
                IWebElement loginLink = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
                loginLink.Click();

                driver.Manage().Timeouts().ImplicitWait = new TimeSpan(5);
               
                WebDriverWait waitE = new(driver, new TimeSpan(0, 0, 5));
               

                if (checkVerifyEmailForm(driver))
                {
                    waitE.Until(ExpectedConditions.ElementToBeClickable(By.Id("submit-btn")));
                    IWebElement verifyEmail = driver.FindElement(By.Id("submit-btn"));

                    verifyEmail.Click();
                }
                else if (checkInCorrectEmailLogin(driver))
                {
                    emailText.Clear();
                    emailText.SendKeys("shankari99@yahoo.com");
                    loginLink.Click();

                }
                else if (checkInCorrectPasswordLogin(driver))
                {
                    passwordText.Clear();
                    passwordText.SendKeys("abcdtest");
                    loginLink.Click();
                    

                }
                else
                {
                    String nextPage = driver.Title.ToString();
                    Assert.IsTrue(nextPage == "Home","Successful Login.","Login was not Successful.");
                    

                }
                


            }

            catch (Exception ex)
            {
                Assert.Fail("User cannot login to WebSite."+ ex.Message);
                throw;
            }

            

        }

       
        public Boolean checkVerifyEmailForm(IWebDriver driver) 
        {
            try
            {
                IWebElement verifyEmailForm = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div"));
                var noElements = verifyEmailForm.FindElements(By.TagName("div"));
                if (noElements.Count == 4) { return false; }
                else if (noElements.Count == 2) { return true; }
                else { return false; }
            }
            catch (Exception ex)
            {
                Assert.Fail(" Verify Email "+ ex.Message);
                return false;
            }
                
        }

        public Boolean checkInCorrectEmailLogin(IWebDriver driver) 
        {

            IWebElement receiveNoEmail = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]"));
            var eMesgExist = receiveNoEmail.FindElements(By.TagName("div"));

            if (eMesgExist.Count > 0) { return true; }
            else return false;

        }

        public Boolean checkInCorrectPasswordLogin(IWebDriver driver) 
        {
            
            IWebElement receiveNoPassword = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]"));
            var pMesgExist = receiveNoPassword.FindElements(By.TagName("div"));
            
            if (pMesgExist.Count > 0) return true;
            else return false;
                        
                        
        }


        public string GetProfileName(IWebDriver driver)
        {

            IWebElement logIn = driver.FindElement(By.XPath("//*[@id='notification-section']/div[1]/div[2]/div/span"));

            return logIn.Text;


        }
        
        public string SignOut(IWebDriver driver,SignOutOption FromPage)
        {
            try
            {
                if (FromPage == SignOutOption.SearchResults)
                {
                    Wait.WaitForClickableWE(driver,"By.XPath", "//*[@id='service-search-section']/section[1]/div/a[2]", 10);
                    IWebElement profileButton = driver.FindElement(By.XPath("//*[@id='service-search-section']/section[1]/div/a[2]"));
                    profileButton.Click();
                }
                else if (FromPage == SignOutOption.ServiceListing)
                {
                    Wait.WaitForClickableWE(driver, "By.XPath", "//*[@id='listing-management-section']/section[1]/div/a[2]", 10);
                    IWebElement profileButton = driver.FindElement(By.XPath("//*[@id='listing-management-section']/section[1]/div/a[2]"));
                    profileButton.Click();


                }
                else if (FromPage == SignOutOption.RequestSent)
                {
                    Wait.WaitForClickableWE(driver, "By.XPath", "//*[@id='service-detail-section']/section[1]/div/a[2]", 10);
                    IWebElement profileButton = driver.FindElement(By.XPath("//*[@id='service-detail-section']/section[1]/div/a[2]"));
                    profileButton.Click();

                }
                else if (FromPage==SignOutOption.ManageSentRequests) 
                {
                    Wait.WaitForClickableWE(driver, "By.XPath", "//*[@id='sent-request-section']/section[1]/div/a[2]", 10);
                    IWebElement profileButton = driver.FindElement(By.XPath("//*[@id='sent-request-section']/section[1]/div/a[2]"));
                    profileButton.Click();
                }


                Wait.WaitForClickableWE(driver, "By.XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button", 10);
                IWebElement signOutButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/a[2]/button"));
                signOutButton.Click();
                return "SignOut Successfull.";
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            return "User not Signed Out";

        }

    }
}
