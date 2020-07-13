using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteCIandT.PageObject
{
    public class AuthenticatorPage
    {
        private IWebDriver driver;

        public AuthenticatorPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement EmailCreateAccField => driver.FindElement(By.Id("email_create"));
        public IWebElement CreateBtn => driver.FindElement(By.Id("SubmitCreate"));
        public IWebElement EmailFieldLogin => driver.FindElement(By.Id("email"));
        public IWebElement PasswordFieldLogin => driver.FindElement(By.Id("passwd"));
        public IWebElement SignInBtn => driver.FindElement(By.Id("SubmitLogin"));
        public IWebElement PageName => driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/h1"));


        public void FillEmailCreateAccount(string Email)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email_create")));

            EmailCreateAccField.SendKeys(Email);
        }

        public CreateAccountPage ClickCreateButton()
        {
            CreateBtn.Click();
            return new CreateAccountPage(driver);
        }

        public void FillEmailFieldLogin(string Email)
        {
            EmailFieldLogin.SendKeys(Email);
        }

        public void FillPasswordFieldLogin(string Password)
        {
            PasswordFieldLogin.SendKeys(Password);
        }

        public MyAccountPage ClickOnSignInButton()
        {
            SignInBtn.Click();
            return new MyAccountPage(driver);
        }

        public bool Verification(string TextToVerify)
        {
            bool TextVisible = false;

            if (PageName.Displayed)
            {
                string text = PageName.Text.ToLower();

                if (text.Contains(TextToVerify))
                {
                    return TextVisible = true;
                }
                else
                {
                    return TextVisible;
                }
            }
            return TextVisible;
        }

    }

}
