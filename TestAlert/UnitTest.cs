using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAlert.Pages;
using OpenQA.Selenium;

namespace TestAlert
{
    [TestClass]
    public class UnitTest:BaseTest
    {
        [TestMethod]
        public void TabTest()
        {
            var home = new HomePage(driver);
            home.EnterAlerts();

            var enterBrowser = new DemoQa(driver);
            enterBrowser.EnterBrowser();

            var newTab = new BrowserWindow(driver);
            var currentWindow = driver.CurrentWindowHandle;

            Assert.AreEqual(driver.WindowHandles.Count, 1);
            newTab.ClickNewTab();
            Assert.AreEqual(driver.WindowHandles.Count, 2);

            var tabText = driver.FindElement(By.Id("sampleHeading")).Text;
            Assert.AreEqual(tabText, "This is a sample page");
            driver.Close();
            driver.SwitchTo().Window(currentWindow);

            newTab.ClickNewWindow();
            Assert.AreEqual(tabText, "This is a sample page", "The text in new window is correct");
            driver.Close();
            driver.SwitchTo().Window(currentWindow);


            newTab.ClickWindowMsg();
            driver.Close();
            driver.SwitchTo().Window(currentWindow);
        }
        [TestMethod]
        public void AlertsTest()
        {
            var home = new HomePage(driver);
            home.EnterAlerts();
            var alert = new Alerts(driver);
            alert.EnterAlert();

            var textAlert = alert.AlertOne();
            Assert.IsTrue(textAlert, "Popup text read");


            alert.AcceptAlert();
            
            alert.DismissAlert();

            alert.promptAlert();

            var promptRes = alert.PromptResult();
            Assert.AreEqual(promptRes, "You entered Chris", "Correct prompt found");
        }

        [TestMethod]
        public void FramesTest()
        {
            var home = new HomePage(driver);
            home.EnterAlerts();

            var frames = new Frames(driver);
            frames.EnterFrames();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            var originalWindow = driver.CurrentWindowHandle;

            bool frame = frames.FirstFrame();
            Assert.IsTrue(frame, "Text inside iframe can be found");

            driver.SwitchTo().Window(originalWindow);

            bool frame2 = frames.SecondFrame();
            Assert.IsTrue(frame2, "Second iframe text found");
        }

        [TestMethod]
        public void ModalTest()
        {
            var home = new HomePage(driver);
            home.EnterAlerts();

            var modals = new Modals(driver);
            modals.enterModal();
            var originalWindow = driver.CurrentWindowHandle;

            var modalSmall = modals.SmallModal();
            Assert.IsTrue(modalSmall, "Correct modal");

            modals.CloseModal();

            driver.SwitchTo().Window(originalWindow);

            var modalLarge = modals.LargeModal();
            Assert.IsTrue(modalLarge, "its right");
            Thread.Sleep(1000);
            modals.CloseLarge();


        }
    }


}
