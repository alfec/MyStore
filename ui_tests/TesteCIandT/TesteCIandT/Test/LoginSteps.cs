using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TesteCIandT.PageObject;
using TesteCIandT.Util;

namespace TesteCIandT.Test
{
    [Binding]
    public class LoginSteps
    {
        private static IWebDriver driver;

        private Connection Connect = new Connection(driver);

        private MainPage InitialPage;
        private AuthenticatorPage LoginPage;
        private CreateAccountPage CreateAccount;
        private MyAccountPage MyAccount;

        [Before]
        public void Config()
        {
            driver = Connect.ConnectIWebDriver(driver);
            InitialPage = new MainPage(driver);
        }

        /// <summary>
        /// Going to the Authentication page
        /// </summary>
        [Given(@"that i'm on the main page of My Store")]
        public void GivenThatIMOnTheMainPageOfMyStore()
        {
            Assert.IsTrue(InitialPage.VerificationOfMainPage());
        }

        [When(@"i click in Sign in functionality")]
        public void WhenIClickInFunctionality()
        {
            LoginPage = new AuthenticatorPage(driver);
            LoginPage = InitialPage.ClickSignIn();
        }

        [Then(@"the authentication page should be displayed")]
        public void ThenTheAuthenticationPageShouldBeDisplayed()
        {
            Assert.IsTrue(LoginPage.Verification("authentication"));
        }

        ///<summary>
        ///Creating an Account
        /// </summary>
        [Given(@"i'm on authenticator page")]
        public void GivenIMOnAuthenticatorPage()
        {
            Assert.IsTrue(LoginPage.Verification("authentication"));
        }

        [Given(@"i want to create a Account")]
        public void GivenIWantToCreateAAccount()
        {
            Assert.IsTrue(LoginPage.Verification("authentication"));
        }

        [When(@"i type my e-mail on Email address field")]
        public void WhenITypeMyE_MailOnField()
        {
            string Email = "test@teste.com.br";
            LoginPage.FillEmailCreateAccount(Email);
        }

        [When(@"click on Create an account button")]
        public void WhenClickOnButton()
        {
            CreateAccount = new CreateAccountPage(driver);
            CreateAccount = LoginPage.ClickCreateButton();
        }

        [Then(@"the CREATE AN ACCOUNT page should be displayed")]
        public void ThenThePageShouldBeDisplayed()
        {
            Assert.IsTrue(CreateAccount.Verification("CREATE AN ACCOUNT"));
        }


        ///<summary>
        ///Filling all the fields and creating an account
        /// </summary>
        [Given(@"i'm at CREATE AN ACCOUNT page")]
        public void GivenIMAtCREATEANACCOUNTPage()
        {
            Assert.IsTrue(CreateAccount.Verification("CREATE AN ACCOUNT"));
        }

        [When(@"i fill all the fields with my information")]
        public void WhenIFillAllTheFieldsWithMyInformation()
        {
            CreateAccount.ChooseTitle("Mr");
            CreateAccount.FillFirstName("Han");
            CreateAccount.FillLastName("Solo");
            CreateAccount.FillEmail("HanSolo@Smuggler.com");
            CreateAccount.FillPassword("BenSolo");
            CreateAccount.ChooseDayOfBirth("13");
            CreateAccount.ChooseMonthOfBirth("March");
            CreateAccount.ChooseMonthOfBirth("1994");
            CreateAccount.FillCompany("Millennium Falcon");
            CreateAccount.FillAddress("Mos Eisley cantina");
            CreateAccount.FillAdditionalAddress("in a table");
            CreateAccount.FillCity("Mos Eisley");
            CreateAccount.ChooseState("Desert");
            CreateAccount.FillZipCode("12345");
            CreateAccount.ChooseCountry("Tatooine");
            CreateAccount.FillAditionalInformation("Just a Smuggler, Scoundrel, Hero o you can call me The Captain of the Millennium Falcon");
            CreateAccount.FillPhone("99999999999");
        }

        [When(@"click on Register button")]
        public void WhenClickOnRegisterButton()
        {
            MyAccount = new MyAccountPage(driver);
            MyAccount = CreateAccount.ClickRegisterButton();
        }

        [Then(@"will be redirected to My Accounte page")]
        public void ThenWillBeRedirectedToMyAccountePage()
        {
            Assert.IsTrue(MyAccount.Verification("MY ACCOUNT"));
        }


        //TODO
        [When(@"i fill my e-mail on Email address field")]
        public void WhenIFillMyE_MailOnEmailAddressField()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"i fill my password on Password field")]
        public void WhenIFillMyPasswordOnPasswordField()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"click on ""(.*)"" button")]
        public void WhenClickOnButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the login should be made")]
        public void ThenTheLoginShouldBeMade()
        {
            ScenarioContext.Current.Pending();
        }


        [After]
        public void EndTest()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
