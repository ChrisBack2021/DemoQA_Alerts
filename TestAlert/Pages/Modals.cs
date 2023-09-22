using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestAlert.Pages
{
    public class Modals
    {
        private IWebDriver driver;

        public Modals(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Modal => driver.FindElement(By.XPath("//span[text()='Modal Dialogs']"));

        public IWebElement SmallModalBtn => driver.FindElement(By.Id("showSmallModal"));

        public IWebElement LargeModalBtn => driver.FindElement(By.Id("showLargeModal"));

        public void enterModal()
        {
            Modal.Click();
        }

        public bool SmallModal()
        {
            bool flag = false;
            SmallModalBtn.Click();
            driver.SwitchTo().ActiveElement();
            var modalBody = driver.FindElement(By.ClassName("modal-body"));
            if (modalBody.Text.Contains("This is a small modal."))
            {
                flag = true;
            }
            return flag;
        }

        public void CloseModal()
        {
            driver.SwitchTo().ActiveElement();
            Thread.Sleep(2000);
            var closeModal = driver.FindElement(By.Id("closeSmallModal"));
            closeModal.Click();
        }

        public bool LargeModal()
        {
            bool flag = false;
            LargeModalBtn.Click();
            driver.SwitchTo().ActiveElement();
            var largeModalBody = driver.FindElement(By.TagName("p"));

            if (largeModalBody.Text.Contains("Lorem Ipsum"))
                flag = true;
            return flag;
        }

        public void CloseLarge()
        {
            var closeModal = driver.FindElement(By.Id("closeLargeModal"));
            closeModal.Click();
        }
    }
}
