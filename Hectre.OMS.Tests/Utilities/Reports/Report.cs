using AventStack.ExtentReports;
using Hectre.OMS.Tests.Selenium;
using Hectre.OMS.Tests.Utilities.Logs;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Hectre.OMS.Tests.Utilities.Reports
{
    public class Report
    {
        private static readonly Dictionary<string, ExtentTest> testList = new Dictionary<string, ExtentTest>();

        private static readonly List<string> testCount = new List<string>();

        [ThreadStatic]
        private static ExtentTest _parentTest;

        [ThreadStatic]
        private static ExtentTest _childTest;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateParentTest(string testName, string description = null)
        {
            _parentTest = ReportSetup.Instance.CreateTest(testName, description);
            return _parentTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string testName, string description = null)
        {
            _childTest = _parentTest.CreateNode(testName, description);
            return _childTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string testName, ExtentTest parentTest)
        {
            testCount.Add(testName);

            if (!testList.ContainsKey(testName))
            {
                _childTest = parentTest.CreateNode(testName);
                testList.Add(testName, _childTest);
            }
            else
                _childTest = testList[testName];
            return _childTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        {
            return _childTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest(string testName)
        {
            return testList[testName];
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void FinalizeTest(string testRailIdOrName = null)
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var message = string.Empty;
            var stacktrace = string.Empty;
            var errorMsg = string.Empty;


            if (!string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace))
            {
                message = TestContext.CurrentContext.Result.Message.Replace(Environment.NewLine, "<br>");
                stacktrace = TestContext.CurrentContext.Result.StackTrace;
                errorMsg = $"Test Failed at url: {Webdriver.Driver.Url}<br>{message}<br>{stacktrace}";
            }


            Status logStatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logStatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logStatus = Status.Skip;
                    break;
                case TestStatus.Warning:
                    logStatus = Status.Warning;
                    break;
                default:
                    logStatus = Status.Pass;
                    break;
            }

            switch (logStatus)
            {
                case Status.Pass:
                    GetTest().Log(logStatus, $"Test ended with: {logStatus}");
                    LogXmlResult(testRailIdOrName, errorMsg);
                    Fw.Log.Info("Passed");
                    break;
                case Status.Fail:
                case Status.Fatal:
                case Status.Error:
                case Status.Warning:
                case Status.Info:
                case Status.Skip:
                case Status.Debug:
                    Fw.Log.Error("Failed");
                    if (GetCount(testCount, testName) == Fw.Config.Retry)
                    {
                        var loggedSteps = String.Join(Environment.NewLine, Fw.Log.LoggedSteps()).Replace(Environment.NewLine, "<br>");
                        errorMsg = $"Test Failed at url: {Webdriver.Driver.Url}<br>{message}<br>{loggedSteps}<br>{stacktrace}";
                        var errorMsgTestRail = errorMsg.Replace("<br>", Environment.NewLine);
                        GetTest().Log(logStatus, errorMsg).AddScreenCaptureFromPath($"Screenshots\\{testRailIdOrName}.png");
                        LogXmlResult(testRailIdOrName, errorMsg);
                    }
                    break;
                default:
                    break;
            }

        }

        private static int GetCount(List<string> tests, string value)
        {
            int testCount = 0;
            foreach (var item in tests)
            {
                if (item.Equals(value))
                    testCount++;
            }

            return testCount;
        }

        private static void LogXmlResult(string testIdOrName, string errorMsg)
        {
            ResultsXml.LogResult(ref errorMsg, testIdOrName);
        }
    }
}
