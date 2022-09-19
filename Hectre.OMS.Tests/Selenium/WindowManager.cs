using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium.Support.Extensions;

namespace Hectre.OMS.Tests.Selenium
{
    public class WindowManager
    {
        public static Size ScreenSize
        {
            get
            {
                var js = "return [window.screen.availWidth, window.screen.availHeight];";
                var dimensions = Webdriver.Driver.ExecuteJavaScript<ReadOnlyCollection<object>>(js, null);
                var x = Convert.ToInt32(dimensions[0]);
                var y = Convert.ToInt32(dimensions[1]);

                return new Size(x, y);
            }
        }

        public static void Maximize()
        {
            Webdriver.Driver.Manage().Window.Position = new Point(0, 0);
            Webdriver.Driver.Manage().Window.Size = ScreenSize;
        }
    }
}
