using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlert.Pages
{
    public class DemoQa
    {
        private IWebDriver driver;

        public DemoQa(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement BrowserWindow => driver.FindElement(By.XPath("//span[text()='Browser Windows']"));

        public void EnterBrowser()
        {        
            BrowserWindow.Click();
        }
    }
}
