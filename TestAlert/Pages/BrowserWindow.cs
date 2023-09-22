using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestAlert.Pages
{
    public class BrowserWindow
    {
        private IWebDriver driver;
        public BrowserWindow(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement EnterNewTab => driver.FindElement(By.Id("tabButton"));

        public IWebElement EnterNewWindow => driver.FindElement(By.Id("windowButton"));
        public string OriginalWindow => driver.CurrentWindowHandle;

        public IWebElement WindowMsg => driver.FindElement(By.Id("messageWindowButton"));

        public void ClickNewTab()
        {
            EnterNewTab.Click();

            foreach (string window in driver.WindowHandles)
            {
                if (OriginalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
        }

        public void ClickNewWindow()
        {
            EnterNewWindow.Click();

            foreach (string window in driver.WindowHandles)
            {
                if (OriginalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
        }

        public void ClickWindowMsg()
        {
            WindowMsg.Click();
            foreach (var window in driver.WindowHandles)
            {
                if (OriginalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
        }

    }
}
