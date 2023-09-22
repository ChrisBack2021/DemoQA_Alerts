using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAlert.Pages
{
    public class Alerts
    {
        private IWebDriver driver;

        public Alerts(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FirstAlert => driver.FindElement(By.Id("alertButton"));
        public IWebElement AlertsTab => driver.FindElement(By.XPath("//span[text()='Alerts']"));

        public IWebElement SecondAlert => driver.FindElement(By.Id("timerAlertButton"));

        public IWebElement ThirdAlert => driver.FindElement(By.Id("confirmButton"));

        public IWebElement FourthAlert => driver.FindElement(By.Id("promtButton"));

        public string CurrentWindow => driver.CurrentWindowHandle;

        public IWebElement PromptRes => driver.FindElement(By.CssSelector("button.promptResult"));


        public string PromptResult()
        {
            string result = String.Empty;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(e =>
                {
                    var prompt = e.FindElement(By.CssSelector("#promptResult"));
                    result = prompt.Text.ToString();
                    Console.WriteLine(result);
                    return result;
                });
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }


        public void EnterAlert()
        {
            AlertsTab.Click();
        }

        public bool AlertOne()
        {
            bool flag = false;
            FirstAlert.Click();
            var alertWindow = driver.SwitchTo().Alert();
            var alertText = alertWindow.Text;
            alertWindow.Accept();

            if (alertText == "You clicked a button")
                flag = true;
            return flag;
        }

        public bool AlertTwo()
        {
            bool flag = false;
            SecondAlert.Click();
            Thread.Sleep(6000);
            IAlert secondAlertWindow = driver.SwitchTo().Alert();
            var secondText = secondAlertWindow.Text;

            if (secondText == "This alert appeared after 5 seconds")
                flag = true;
            return flag;
        }

        public void AcceptAlert()
        {
            ThirdAlert.Click();
            var tAW = driver.SwitchTo().Alert();
            tAW.Accept();
        }

        public void DismissAlert()
        {
            ThirdAlert.Click();
            var tAW = driver.SwitchTo().Alert();
            tAW.Dismiss();
        }

        public void promptAlert()
        {
            FourthAlert.Click();
            var prompt = driver.SwitchTo().Alert();
            prompt.SendKeys("Chris");
            prompt.Accept();
        }

    }
}
