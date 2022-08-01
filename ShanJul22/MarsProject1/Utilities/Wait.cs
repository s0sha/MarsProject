using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

namespace MarsProject1.Utilities
{
    internal static class Wait
    {

        public static void WaitForClickableWE(IWebDriver driver,string locator,string locatorValue,int sec)
        {
            
            WebDriverWait waitElement = new(driver, new TimeSpan(0,0,sec));

            if (locator == "By.XPath")
            {
                waitElement.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }
            else if (locator=="By.Name") 
            {
                waitElement.Until(ExpectedConditions.ElementToBeClickable(By.Name(locatorValue)));
              
            }
        
        }

                
        public static void WaitForVisibleWE(IWebDriver driver, string locator, string locatorValue, int sec)
        {

            WebDriverWait waitElement = new(driver, new TimeSpan(0, 0, sec));

            if (locator == "By.XPath")
            {
                waitElement.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            }
            else if (locator == "By.Name")
            {
                waitElement.Until(ExpectedConditions.ElementIsVisible(By.Name(locatorValue)));
            }
            else if (locator == "By.TagName")
            {
                waitElement.Until(ExpectedConditions.ElementIsVisible(By.TagName(locatorValue)));
            }
        }

       
         public static void WaitForTableWE(IWebDriver driver, string locator, string locatorValue, int sec)
        {

            WebDriverWait waitElement = new(driver, new TimeSpan(0, 0, sec));

            if (locator == "By.XPath")
            {
                waitElement.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(locatorValue)));
            }
            else if (locator == "By.Name")
            {
                waitElement.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Name(locatorValue)));
            }

        }


        public static void FluentWaitForClickableWE(IWebDriver driver, string locator, string locatorValue, int sec)
        {
            
             

            DefaultWait<IWebDriver> fluentWait = new(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message=("Waiting for Element Loading");

            if (locator == "By.XPath") 
            {
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }
            else if (locator == "By.Name")
            {
                fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.Name(locatorValue)));
            }                            


        }



    }
}
