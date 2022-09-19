using Hectre.OMS.Tests.Selenium;
using NUnit.Framework;
using Hectre.OMS.Tests.Pages;
using System;
using AventStack.ExtentReports;
using System.Collections.Generic;
using Hectre.OMS.Tests.Utilities.Reports;
using NUnit.Framework.Interfaces;

namespace Hectre.OMS.Tests.Setup
{
    public class BaseTest
    {
        [ThreadStatic]
        private static ExtentTest _parentTest;

        private static readonly Dictionary<string, ExtentTest> parentTestList = new Dictionary<string, ExtentTest>();

        [OneTimeSetUp]
        public void BeforeAll()
        {
            _parentTest = Report.CreateParentTest(GetType().Name);
            parentTestList.Add(GetType().Name, _parentTest);
        }

        [SetUp]
        public void BeforeEach()
        {
            Fw.SetLogger();
            Webdriver.InitializeWebDriver();
            Page.Init();
            Report.CreateTest(TestContext.CurrentContext.Test.Name, parentTestList[GetType().Name]);
        }

        [TearDown]
        public void AfterEach()
        {
            var testName = $"{TestContext.CurrentContext.Test.ID}_{TestContext.CurrentContext.Test.Name}";
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            string message = TestContext.CurrentContext.Result.Message;

            if (outcome == TestStatus.Passed)
            {
                Report.FinalizeTest(testName);
            }
            else if (outcome == TestStatus.Failed)
            {
                Webdriver.TakeScreenshot(testName);
                Report.FinalizeTest(testName);
            }

            Webdriver.Quit();
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            ReportSetup.Instance.Flush();
        }
    }
}
