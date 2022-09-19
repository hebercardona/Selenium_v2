using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Hectre.OMS.Tests.Selenium
{
    public class Wait
    {
        private readonly WebDriverWait _wait;
        private readonly int _waitSeconds;

        public Wait(int waitSeconds)
        {
            _waitSeconds = waitSeconds;
            _wait = new WebDriverWait(Webdriver.Driver, TimeSpan.FromSeconds(waitSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };

            _wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException)
                );
        }

        public void WaitForPageLoad(int seconds)
        {
            _wait.Until(driver => ((IJavaScriptExecutor)Webdriver.Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public IWebElement AndGetElement(By locator, int additionalTimeout = 10)
        {
            try
            {
                IWebElement element = _wait.Until(ExpectedConditions.ElementExists(locator));
                return element;
            }
            catch(ElementNotVisibleException)
            {
                ElementExtensions.ScrollIntoView(locator);
                return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void AndClickElement(By locator, int additionalTimeout = 10)
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
            }
            catch (WebDriverTimeoutException)
            {
            }
            catch (StaleElementReferenceException)
            {
            }
            catch (Exception e)
            {
            }
        }

        public void AndClickElement(IWebElement element, int additionalTimeout = 10)
        {
            try
            {
                if(!element.Displayed)
                {
                    element.ScrollIntoView();
                }
                _wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
            }
            catch (WebDriverTimeoutException)
            {
            }
            catch (StaleElementReferenceException)
            {
            }
            catch (ElementNotVisibleException)
            {
                element.ScrollIntoView();
            }
            catch (Exception e)
            {
            }
        }

        public bool Until(Func<IWebDriver, bool> condition)
        {
            return _wait.Until(condition);
        }

        public IWebElement Until(Func<IWebDriver, IWebElement> condition)
        {
            return _wait.Until(condition);
        }
    }
}
