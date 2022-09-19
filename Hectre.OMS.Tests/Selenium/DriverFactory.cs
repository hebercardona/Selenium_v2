using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Reflection;

namespace Hectre.OMS.Tests.Selenium
{
    public static class DriverFactory
    {
        public static IWebDriver Launch(string browser, int pageLoad = 60)
        {
            switch (browser)
            {
                case "Chrome":
                    return BuildChrome(pageLoad);

                case "Firefox":
                    return BuildFirefox(pageLoad);

                default:
                    throw new System.ArgumentException("Cannot Buil unsupported browser " + browser);
            }
        }

        public static ChromeDriver BuildChrome(int pageLoad)
        {
            ChromeDriver driver;
            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-blink-features");
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddArgument("--disable-extensions");
            if (Fw.Config.Headless == true) { options.AddArgument("--headless"); }
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoad);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(120);
            driver.ExecuteScript("Object.defineProperty(navigator, 'webdriver', {get: () => undefined})");
            return driver;
        }

        public static FirefoxDriver BuildFirefox(int pageLoad)
        {
            FirefoxDriver driver;
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("no-sandox");
            var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new FirefoxDriver(location);
            return driver;
        }
    }
}
