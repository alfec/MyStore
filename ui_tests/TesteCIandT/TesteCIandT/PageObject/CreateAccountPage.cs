using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteCIandT.PageObject
{
    public class CreateAccountPage
    {
        private IWebDriver driver;

        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement TextVerification => driver.FindElement(By.Id("center_column"));
        public IWebElement TitleRadioMr => driver.FindElement(By.Id("id_gender1"));
        public IWebElement TitleRadioMrs => driver.FindElement(By.Id("id_gender2"));
        public IWebElement FirstNameField => driver.FindElement(By.Id("customer_firstname"));
        public IWebElement LastNameField => driver.FindElement(By.Id("customer_lastname"));
        public IWebElement EmailField => driver.FindElement(By.Id("email"));
        public IWebElement PasswordField => driver.FindElement(By.Id("passwd"));
        public IWebElement DayBirthSelect => driver.FindElement(By.Id("days"));
        public IWebElement MonthBirthSelect => driver.FindElement(By.Id("months"));
        public IWebElement YearBirthSelect => driver.FindElement(By.Id("years"));
        public IWebElement CompanyField => driver.FindElement(By.Id("company"));
        public IWebElement AddressField => driver.FindElement(By.Id("address1"));
        public IWebElement AddressTwoField => driver.FindElement(By.Id("address2"));
        public IWebElement CityField => driver.FindElement(By.Id("city"));
        public IWebElement StateSelect => driver.FindElement(By.Id("id_state"));
        public IWebElement ZipPostalCodeField => driver.FindElement(By.Id("postcode"));
        public IWebElement CountryField => driver.FindElement(By.Id("id_country"));
        public IWebElement InformationField => driver.FindElement(By.Id("other"));
        public IWebElement MobilePhoneField => driver.FindElement(By.Id("phone_mobile"));
        public IWebElement RegisterBtn => driver.FindElement(By.Id("submitAccount"));

        public void ChooseTitle(string Title)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("id_gender1")));

            if (Title == "Mr")
            {
                TitleRadioMr.Click();
            }
            else
            {
                TitleRadioMrs.Click();
            }
        }

        public void FillFirstName(string FirstName)
        {
            FirstNameField.SendKeys(FirstName);
        }

        public void FillLastName(string LastName)
        {
            LastNameField.SendKeys(LastName);
        }

        public void FillEmail(string Email)
        {
            EmailField.SendKeys(Email);
        }

        public void FillPassword(string Password)
        {
            PasswordField.SendKeys(Password);
        }

        public void ChooseDayOfBirth(string Day)
        {
            DayBirthSelect.Click();
            DayBirthSelect.SendKeys(Day);
        }

        public void ChooseMonthOfBirth(string Month)
        {
            MonthBirthSelect.Click();
            MonthBirthSelect.SendKeys(Month);
        }

        public void ChooseYearOfBirth(string Year)
        {
            YearBirthSelect.Click();
            YearBirthSelect.SendKeys(Year);
        }

        public void FillCompany(string Company)
        {
            CompanyField.SendKeys(Company);
        }

        public void FillAddress(string Address)
        {
            AddressField.SendKeys(Address);
        }

        public void FillAdditionalAddress(string AdditionalAddress)
        {
            AddressTwoField.SendKeys(AdditionalAddress);
        }

        public void FillCity(string City)
        {
            CityField.SendKeys(City);
        }

        public void ChooseState(string State)
        {
            StateSelect.Click();
            StateSelect.SendKeys(State);
        }

        public void FillZipCode(string Zip)
        {
            ZipPostalCodeField.SendKeys(Zip);
        }

        public void ChooseCountry(string Country)
        {
            CountryField.Click();
            CountryField.SendKeys(Country);
        }

        public void FillAditionalInformation(string Information)
        {
            InformationField.SendKeys(Information);
        }

        public void FillPhone(string Phone)
        {
            MobilePhoneField.SendKeys(Phone);
        }

        public MyAccountPage ClickRegisterButton()
        {
            RegisterBtn.Click();
            return new MyAccountPage(driver);
        }


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
