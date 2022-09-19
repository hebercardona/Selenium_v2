using Hectre.OMS.Tests.Selenium;
using OpenQA.Selenium;

namespace Hectre.OMS.Tests.Pages.PageMap
{
    public class HomeMap
    {
        public Element LogOutIcon       => Webdriver.FindElement(By.CssSelector("a[class*='icons logout']"), "LogOut Icon");
        public Element HarvestBtn       => Webdriver.FindElement(By.CssSelector("a[data-w-tab='Harvest']"), "Harvest");
        public Element PayrollBtn       => Webdriver.FindElement(By.CssSelector("a[data-w-tab='Payroll']"), "Payroll");
        public Element TimesheetsBtn    => Webdriver.FindElement(By.CssSelector("a[data-w-tab='Timesheets']"), "Timesheets");
        public Element MapsBtn          => Webdriver.FindElement(By.CssSelector("a[data-w-tab='Maps']"), "Maps");
        public Element InsightsBtn      => Webdriver.FindElement(By.CssSelector("a[data-w-tab='Insights']"), "Insights");
        public Element ScoutBtn         => Webdriver.FindElement(By.CssSelector("a[data-w-tab='Scout']"), "Scout");
        public Element AdminBtn         => Webdriver.FindElement(By.CssSelector("a[data-w-tab='admin']"), "Admin");
        public Element StaffBtn         => Webdriver.FindElement(By.CssSelector("a[data-w-tab='Staff']"), "Staff");
        public Element JobsAndTasksBtn  => Webdriver.FindElement(By.CssSelector("a[data-w-tab='Jobs & Tasks']"), "Jobs & Tasks");
        public Element OrchardsBtn      => Webdriver.FindElement(By.CssSelector("a[data-w-tab='Orchards']"), "Orchards");
        public Element VarietiesBtn     => Webdriver.FindElement(By.CssSelector("a[data-w-tab='Varieties']"), "Varieties");
        public Element GeneralBtn       => Webdriver.FindElement(By.CssSelector("a[data-w-tab='General']"), "General");
        public Element AdminPayrollBtn  => Webdriver.FindElement(By.XPath("//a[@data-w-tab='Payroll'][2]"), "Payroll");

    }
}
