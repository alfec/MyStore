using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteCIandT.PageObject
{
    public class MyAccountPage
    {
        private IWebDriver driver;

        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement TextVerification => driver.FindElement(By.Id("center_column"));

        public bool Verification(string TextToVerify)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div[2]")));

            bool TextVisible = false;

            if (TextVerification.Displayed)
            {
                string text = TextVerification.Text.ToUpper();

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
