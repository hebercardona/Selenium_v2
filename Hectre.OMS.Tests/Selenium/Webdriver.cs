using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hectre.OMS.Tests.Selenium
{
    public static partial class Webdriver
    {
        public enum Browser
        {
            Chrome,
            Firefox,
            Edge
        }

        private static Dictionary<string, DriverInstance> webDrivers = new Dictionary<string, DriverInstance>();

        public static Wait Wait => new Wait(Fw.Config.Wait_Seconds);

        private struct DriverInstance
        {
            public IWebDriver Driver;
            public bool IsLoggedIn;
        }

        public static IWebDriver Driver
        {
            get
            {
                string testID = TestContext.CurrentContext.Test.ID;
                if (!webDrivers.ContainsKey(testID))
                {
                    InitializeWebDriver();
                }
                return webDrivers[testID].Driver;
            }
            set
            {
                string testID = TestContext.CurrentContext.Test.ID;
                webDrivers[testID] = new DriverInstance
                {
                    Driver = value,
                    IsLoggedIn = false
                };
            }
        }

        public static void InitializeWebDriver()
        {
            Fw.SetConfig();
            var starting_url = Fw.Config.StartingUrl;

            if (Fw.Config.IsLocal == true)
            {
                Driver = DriverFactory.Launch(Fw.Config.Browser);
                Wait.WaitForPageLoad(Fw.Config.Page_Load);
                WindowManager.Maximize();
                Driver.Navigate().GoToUrl(starting_url);
                Fw.Log.Info($"Navigating to url: {starting_url}");
            }
        }

        public static Element FindElement(By locator, string name)
        {
            return new Element(locator, name);
        }

        public static IList<IWebElement> FindChildElements(Element parentElement, By by)
        {
            var elements = parentElement.FindElements(by);
            return elements;
        }

        public static void TakeScreenshot(string imageName)
        {
            ITakesScreenshot ss = (ITakesScreenshot)Driver;
            Screenshot screenshot = ss.GetScreenshot();
            var ssFileName = Path.Combine(Fw.WORKSPACE_DIRECTORY, "TestOutputs", "Screenshots", imageName);
            screenshot.SaveAsFile($"{ssFileName}.png", ScreenshotImageFormat.Png);
        }

        public static void LoseFocus()
        {
            Actions action = new Actions(Driver);
            action.MoveByOffset(0, 0).Click().Build().Perform();
        }

        public static void SwitchToDefaultContent()
        {
            Driver.SwitchTo().DefaultContent();
        }

        public static void ScrollPageDown()
        {
            Actions actions = new Actions(Driver);
            actions.SendKeys(Keys.PageDown).Build().Perform();
        }

        public static void Quit()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
