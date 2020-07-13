using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TesteCIandT.PageObject;
using TesteCIandT.Util;

namespace TesteCIandT.Test
{
    [TestClass]
    public class LoginTest
    {
        private static IWebDriver driver;
        private Connection Connect = new Connection(driver);
        private MainPage InitialPage;
        private AuthenticatorPage LoginPage;
        private CreateAccountPage CreateAccount;
        private MyAccountPage MyAccount;

        [TestInitialize]
        [TestCategory("Without Specflow")]
        public void Config()
        {
            driver = Connect.ConnectIWebDriver(driver);
            InitialPage = new MainPage(driver);
        }

        [TestMethod]
        [TestCategory("Without Specflow")]
        public void GoingToAuthenticationPage()
        {
            LoginPage = InitialPage.ClickSignIn();
            Assert.IsTrue(LoginPage.Verification("authentication"));
        }
        
        [TestMethod]
        [TestCategory("Without Specflow")]
        public void CreatingAnAccount()
        {
            LoginPage = InitialPage.ClickSignIn();
            string Email = "test1@teste.com.br";
            LoginPage.FillEmailCreateAccount(Email);
            CreateAccount = new CreateAccountPage(driver);
            CreateAccount = LoginPage.ClickCreateButton();
            Assert.IsTrue(CreateAccount.Verification("CREATE AN ACCOUNT"));
            CreateAccount.ChooseTitle("Mr");
            CreateAccount.FillFirstName("Han");
            CreateAccount.FillLastName("Solo");
            //CreateAccount.FillEmail("HanSolo@Smuggler.com");
            CreateAccount.FillPassword("BenSolo");
            CreateAccount.ChooseDayOfBirth("13");
            CreateAccount.ChooseMonthOfBirth("March");
            CreateAccount.ChooseYearOfBirth("1994");
            CreateAccount.FillCompany("Millennium Falcon");
            CreateAccount.FillAddress("Mos Eisley cantina");
            CreateAccount.FillAdditionalAddress("in a table");
            CreateAccount.FillCity("Mos Eisley");
            CreateAccount.ChooseState("Desert");
            CreateAccount.FillZipCode("12345");
            CreateAccount.ChooseCountry("Tatooine");
            CreateAccount.FillAditionalInformation("Just a Smuggler, Scoundrel, Hero o you can call me The Captain of the Millennium Falcon");
            CreateAccount.FillPhone("99999999999");
            MyAccount = new MyAccountPage(driver);
            MyAccount = CreateAccount.ClickRegisterButton();
            Assert.IsTrue(MyAccount.Verification("MY ACCOUNT"));
        }

        [TestMethod]
        [TestCategory("Without Specflow")]
        public void LoginInMyStore()
        {
            LoginPage = InitialPage.ClickSignIn();
            LoginPage.FillEmailFieldLogin("andreluiz_fc@yahoo.com.br");
            LoginPage.FillPasswordFieldLogin("157395");
            MyAccount = LoginPage.ClickOnSignInButton();
            Assert.IsTrue(MyAccount.Verification("MY ACCOUNT"));
        }

        [TestCleanup]
        public void EndTest()
        {
            driver.Close();
            driver.Quit();
        }
    }

}

