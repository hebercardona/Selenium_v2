using Hectre.OMS.Tests.Selenium;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hectre.OMS.Tests.Pages.PageMap
{
    public class JobAndTasksMap
    {
        public Element JobTypesBtn                  => Webdriver.FindElement(By.XPath("//div[contains(@class,'horizontal-nav-title') and contains(., 'JOB TYPES')]"), "Job Types");
        public Element TaskTypesBtn                 => Webdriver.FindElement(By.XPath("//div[contains(@class,'horizontal-nav-title') and contains(., 'TASK TYPES')]"), "Task Types");
        public Element AddNewJobBtn                 => Webdriver.FindElement(By.XPath("//div[contains(@class,'action-cta') and contains(., 'ADD NEW JOB')]"), "Add Job Type");
        public Element JobNameInput                 => Webdriver.FindElement(By.Id("name"), "Job Name");
        public Element PieceRateRadioBtn            => Webdriver.FindElement(By.XPath("//div[@id='jobType']//span[contains(., 'Piece Rate')]"), "Piece Rate Radio Btn");
        public Element WagesRadioBtn                => Webdriver.FindElement(By.XPath("//div[@id='jobType']//span[contains(., 'Wages')]"), "Wages Radio Btn");
        public Element BothRadioBtn                 => Webdriver.FindElement(By.XPath("//div[@id='jobType']//span[contains(., 'Both')]"), "Both Radio Btn");
        public Element CategoryDropdown             => Webdriver.FindElement(By.XPath("//select[contains(@class,'dropdown-selection') and contains(@id, 'type')]"), "Category Dropdown");
        public Element RateUnitDropdown             => Webdriver.FindElement(By.XPath("//select[contains(@class,'dropdown-selection') and contains(@id, 'rateUnit')]"), "Rate Unit Dropdown");
        public Element AgriculturalLaborCategory    => Webdriver.FindElement(By.XPath("//div[@id='laborCategory']//input[@value='agricultural']"), "Agricultural Labor Category");
        public Element CostCodeInput                => Webdriver.FindElement(By.Id("costCode"), "Cost Code");
        public Element SaveBtn                      => Webdriver.FindElement(By.CssSelector("a[class='button w-button']"), "Save Btn");
        public IList<IWebElement> CategoryOptions   => CategoryDropdown.FindElements(By.XPath(".//option"));
        public Element JobTypeFromList(string name) => Webdriver.FindElement(By.XPath($"//div[@class='list-of-people']//button[contains(., '{name}')]"), "Job List Name");
    }
}
