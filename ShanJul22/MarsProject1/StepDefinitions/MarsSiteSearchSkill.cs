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
        protected IWebDriver _driver = new ChromeDriver();

        private HomePage _login = new();
        private SellerHomePage _userHomePage = new();
        private SearchResultsPage _viewResult = new();
        private ShareSkillPage _shareListing = new();
        private RequestSentPage _requestSent = new();

        string _url = "http://localhost:5000";

        [Given(@"\[User is logged into website\.]")]
        public void GivenUserIsLoggedIntoWebsite_()
        {

            _driver.Manage().Window.Maximize();


            _driver.Navigate().GoToUrl(_url);

            string userName = "shankari99@yahoo.com";
            string passWord = "abcdtest";
            _login.LoginAsUser(_driver, userName, passWord);

        }


        [When(@"\[User enters '([^']*)' in search button and press Enter\. ]")]
        public void WhenUserEntersSkillInSearchButtonAndPressEnter_(string p0)
        {

            Assert.True(_userHomePage.SearchSkill(_driver, p0), "Skill " + p0 + "is listed in Search Results.", "Skill " + p0 + "is not listed in Search Results.");

        }



        [Then(@"\[User can verify if user '([^']*)' exists and send a request to provider\.]")]
        public void ThenUserCanVerifyIfUserProviderExists_(string p0)
        {

            SignOutOption searchstatus;


            Boolean searchResult = _viewResult.VerifyResults(_driver, p0);

            //Assert.True(searchResult, "Provider " + p0 + " is found in Search Result.", "Provider " + p0 + " is not found in Search Result.");

            if (searchResult)
            {

                _viewResult.SendRequest(_driver);

                searchstatus = SignOutOption.RequestSent;


            }
            else
            {

                searchstatus = SignOutOption.SearchResults;
            }

            _login.SignOut(_driver, searchstatus);

        }





        [When(@"\[User clicks on ShareSkill, user can navigate to ShareSkill Form]")]
        public void WhenUserClicksOnShareSkillUserCanNavigateToShareSkillForm()
        {

            _userHomePage.GoToShareASkill(_driver);

        }


        [Then(@"\[User can Enter invalid Data, Title, Description, StartDate and Receive Error Messages, Correct Form with correct CTitle,CDescription,CStartDate and Save Listing]")]
        public void ThenUserCanEnterInvalidDataAndReceiveErrorMessagesCorrectFormWithCorrectAndSaveListing()
        {
            //Read from DataFile
            DataFile.openFile();
            String title = DataFile.getData(); String description = DataFile.getData(); String StartDate = DataFile.getData();
            String cTitle = DataFile.getData(); String cDescription = DataFile.getData(); String cStartDate = DataFile.getData();

            _shareListing.AddListing(_driver, title, description, StartDate, cTitle, cDescription, cStartDate);


            _login.SignOut(_driver, SignOutOption.ServiceListing);

        }


        [Then(@"\[User can SignOut of portal\.]")]
        public void ThenUserCanSignOutOfPortal_()
        {

            _driver.Close();
        }


        [Given(@"\[User has launched website]")]
        public void GivenUserHasLaunchedWebsite()
        {
            _driver.Manage().Window.Maximize();


            _driver.Navigate().GoToUrl(_url);

        }

        [Then(@"\[User can enter '([^']*)' and '([^']*)' and login to portal]")]
        public void ThenUserCanEnterAndAndLoginToPortal(string username, string password)
        {
            _login.LoginAsUser(_driver, username, password);



        }

        [When(@"\[User clicks on Manage Requests menu option and goes to Sent Requests option\.]")]
        public void WhenUserClicksOnManageRequestsMenuOptionAndGoesToSentRequestsOption_()
        {
            _userHomePage.GoToSentRequests(_driver);
        }

        [Then(@"\[User can review requests sent and action, provide a review and withdraw request\.]")]
        public void ThenUserCanReviewRequestsSentAndActionProvideAReviewAndWithdrawRequest_()
        {
            _requestSent.veiwRequestSent(_driver);
            _login.SignOut(_driver, SignOutOption.ManageSentRequests);
           

        }


    }
}