using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

using MarsProject1.Pages;
using MarsProject1.Utilities;



namespace MarsProject1.StepDefinitions
{
    [Binding]
    public class MarsSiteSearchSkill
    {
        protected IWebDriver driver = new ChromeDriver();
        
        private HomePage login = new();
        private SellerHomePage searchText = new();
        private SearchResultsPage viewResult = new();
        private ShareSkillPage shareListing = new();

        string url = "http://localhost:5000";

        [Given(@"\[User is logged into website\.]")]
        public void GivenUserIsLoggedIntoWebsite_()
        {
           
            driver.Manage().Window.Maximize();


            driver.Navigate().GoToUrl(url);

            string userName = "shankari99@yahoo.com";
            string passWord = "abcdtest";
            login.LoginAsUser(driver,userName,passWord);

        }


        [When(@"\[User enters '([^']*)' in search button and press Enter\. ]")]
        public void WhenUserEntersSkillInSearchButtonAndPressEnter_(string p0)
        {
            
                Assert.True(searchText.SearchSkill(driver, p0),"User Can Search For " + p0);
            /*    
            else
            { Console.WriteLine(p0 + " does not exist");
                String searchResult = login.SignOut(driver, SignOutOption.SearchResults);
                Console.WriteLine(searchResult);
            
            }
            */
        }



        [Then(@"\[User can verify if user '([^']*)' exists and send a request to provider\.]")]
        public void ThenUserCanVerifyIfUserProviderExists_(string p0)
        {
            SignOutOption searchstatus;

            Boolean searchResult = viewResult.VerifyResults(driver, p0);
            Assert.True(searchResult,"Provider "+p0+" does not exists in Search Result.");

            if (searchResult)
            {
                //Console.WriteLine(p0 + " Provider exists in Search Result");
                int SuccessEvent = viewResult.SendRequest(driver);
                string SuccessMsg;

                if (SuccessEvent == 1)  SuccessMsg = "Message Successfully Sent to Skill Provider."; 
                else if ((SuccessEvent == 2) || (SuccessEvent == 5)) SuccessMsg = "Request already sent to Provider";
                else if (SuccessEvent == 4) SuccessMsg = "Exception Thrown No such Element";
                else SuccessMsg = "No Return Message";

                searchstatus = SignOutOption.RequestSent;
                Console.WriteLine(SuccessMsg);
                
                

            }
            else 
            {
               // Console.WriteLine( p0 + " not found. "); 
                searchstatus = SignOutOption.SearchResults;
            }
            
            string signOutStatus = login.SignOut(driver,searchstatus);
            Console.WriteLine(signOutStatus);

        }


       


        [When(@"\[User clicks on ShareSkill, user can navigate to ShareSkill Form]")]
        public void WhenUserClicksOnShareSkillUserCanNavigateToShareSkillForm()
        {
            
            shareListing.GoToShareASkill(driver);
            
        }


        [Then(@"\[User can Enter invalid Data, Title, Description, StartDate and Receive Error Messages, Correct Form with correct CTitle,CDescription,CStartDate and Save Listing]")]
        public void ThenUserCanEnterInvalidDataAndReceiveErrorMessagesCorrectFormWithCorrectAndSaveListing()
        {
            //Read from DataFile
            DataFile.openFile();
            String title=DataFile.getData();String description = DataFile.getData(); String StartDate=DataFile.getData();
            String cTitle=DataFile.getData();String cDescription=DataFile.getData(); String cStartDate=DataFile.getData();

            shareListing.AddListing(driver,title,description,StartDate,cTitle,cDescription,cStartDate);
            

            string signOutStatus = login.SignOut(driver, SignOutOption.ServiceListing);
            Console.WriteLine(signOutStatus);

        }


        [Then(@"\[User can SignOut of portal\.]")]
        public void ThenUserCanSignOutOfPortal_()
        {
            
            driver.Close();
        }


        [Given(@"\[User has launched website]")]
        public void GivenUserHasLaunchedWebsite()
        {
            driver.Manage().Window.Maximize();


            driver.Navigate().GoToUrl(url);
            
        }

        [Then(@"\[User can enter '([^']*)' and '([^']*)' and login to portal]")]
        public void ThenUserCanEnterAndAndLoginToPortal(string username, string password)
        {
            login.LoginAsUser(driver,username,password);
            
        }



    }


}
