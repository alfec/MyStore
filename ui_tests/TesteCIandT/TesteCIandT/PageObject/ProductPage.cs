using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteCIandT.PageObject
{
    public class ProductPage
    {
        private IWebDriver driver;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement BtnComprar => driver.FindElement(By.Id("btn-buy"));

        public void ComprarProdutoEscolhido()
        {
            BtnComprar.Click();
        }
    }

}
