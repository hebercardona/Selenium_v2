using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Hectre.OMS.Tests.Selenium
{
    public static class ElementExtensions
    {
        public static ReadOnlyCollection<IWebElement> FindChildElements(this IWebElement element, By by)
        {
            try
            {
                Webdriver.Wait.Until(driver => element.FindElements(by).Count > 0);
                return element.FindElements(by);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void ScrollIntoView(this IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Webdriver.Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void ScrollIntoView(By by)
        {
            var element = Webdriver.Driver.FindElement(by);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Webdriver.Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
