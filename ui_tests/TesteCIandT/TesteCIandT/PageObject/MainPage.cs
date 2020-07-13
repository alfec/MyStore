using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteCIandT.PageObject
{
    public class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SearchField => driver.FindElement(By.Id("search_query_top"));
        public IWebElement SignInBtn => driver.FindElement(By.CssSelector(".login"));
        public IWebElement Title => driver.FindElement(By.XPath("/html/head/title"));


        public void DoASearch(string Produto)
        {
            SearchField.Click();
            SearchField.SendKeys(Produto);
            SearchField.SendKeys(Keys.Enter);
            //return new ResultPage(driver);
        }

        public AuthenticatorPage ClickSignIn()
        {
            SignInBtn.Click();
            return new AuthenticatorPage(driver);
        }

        public bool VerificationOfMainPage()
        {
            bool Text = false;

            if (Title.Displayed)
            {
                string text = Title.Text.ToLower();

                if (text.Contains(driver.Title))
                {
                    return Text = true;
                }
                else
                {
                    return Text;
                }

            }
            return Text;
        }
    }

}
