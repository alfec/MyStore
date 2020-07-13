using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TesteCIandT.Util
{
    public class Connection
    {
        private IWebDriver browser;

        public Connection(IWebDriver driver)
        {
            this.browser = driver;
        }

        public IWebDriver ConnectIWebDriver(IWebDriver driver)
        {
            browser = new ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("http://automationpractice.com/index.php");
            return browser;
        }
    }
}
