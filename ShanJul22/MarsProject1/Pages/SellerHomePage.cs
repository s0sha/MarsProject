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


       
    }

}