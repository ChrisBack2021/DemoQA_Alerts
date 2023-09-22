using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestAlert.Pages
{
    public class Frames
    {
        private IWebDriver driver;

        public Frames(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement EnterFrame => driver.FindElement(By.XPath("//span[text()='Frames']"));
        public IWebElement FrameOne => driver.FindElement(By.Id("frame1"));
        public IWebElement FrameTwo => driver.FindElement(By.Id("frame2"));



        public void EnterFrames()
        {
            EnterFrame.Click();
        }

        public bool FirstFrame()
        {
            bool flag = false;
            driver.SwitchTo().Frame(FrameOne);
            var text = driver.FindElement(By.Id("sampleHeading"));
            if (text.Text.Contains("This is a sample page"))
                flag = true;
            return flag;
        }

        public bool SecondFrame()
        {
            bool flag = false;
            driver.SwitchTo().Frame(FrameTwo);
            var insideText = driver.FindElement(By.Id("sampleHeading"));
            if (insideText.Text.Contains("This is a sample"))
                flag = true;
            return flag;
        }
    }
}
