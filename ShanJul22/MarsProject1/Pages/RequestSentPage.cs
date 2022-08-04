using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using NUnit.Framework;
using MarsProject1.Utilities;

namespace MarsProject1.Pages
{
    internal class RequestSentPage
    {

        public void veiwRequestSent(IWebDriver driver) 
        {

            Wait.WaitForClickableWE(driver,"By.XPath", "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button", 15);
        
                //review request
            IWebElement tableRrow1 = driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button"));
            if (tableRrow1.Text == "Review") { 
                tableRrow1.Click();

                Wait.WaitForClickableWE(driver, "By.XPath", "/html/body/div[2]/div/div[2]/div/div[4]/div", 10);
                IWebElement closeRow1 = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div[4]/div"));
                closeRow1.Click();

             }

            IWebElement tableRow3Status = driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[3]/td[5]"));
            if (tableRow3Status.Text == "Pending")
            {
                IWebElement tableRow3 = driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[3]/td[8]/button"));
                if (tableRow3.Text == "Withdraw")
                {
                    tableRow3.Click();
                }
            }

                
        }

    }
}
