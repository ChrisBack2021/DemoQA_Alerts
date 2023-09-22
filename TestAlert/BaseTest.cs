using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAlert
{
    [TestClass]
    public class BaseTest
    {
        string url = "https://demoqa.com";
        public IWebDriver driver;
        [TestInitialize]
        public void StartTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [TestCleanup]
        public void CloseTest()
        {
            driver.Quit();
        }
    }


}