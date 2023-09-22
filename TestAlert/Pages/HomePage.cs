using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestAlert.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Alert => driver.FindElement(By.XPath("//h5[text()='Alerts, Frame & Windows']"));

        public void EnterAlerts()
        {
            Alert.Click();
        }
    }
}
