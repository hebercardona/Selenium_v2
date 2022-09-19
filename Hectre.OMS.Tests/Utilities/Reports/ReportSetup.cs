using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Hectre.OMS.Tests.Selenium;

namespace Hectre.OMS.Tests.Utilities.Reports
{
    public class ReportSetup
    {
        private static ExtentReports extent;

        public static ExtentHtmlReporter htmlReporter;

        public static void SetExtentReport()
        {
            if (extent == null)
            {
                htmlReporter = new ExtentHtmlReporter($"{Fw.WORKSPACE_DIRECTORY}\\TestOutputs\\index.html");
                htmlReporter.Config.DocumentTitle = "OMS Test Report";
                htmlReporter.Config.ReportName = "OMS Test Report";
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AnalysisStrategy = AnalysisStrategy.Class;
                extent.AddSystemInfo("OS", "Windows");
                extent.AddSystemInfo("Browser", Fw.Config.Browser);
                extent.AddSystemInfo("Environment", Fw.Config.Environment);
            }
        }

        public static ExtentReports Instance
        {
            get
            {
                SetExtentReport();
                return extent;
            }
        }
    }
}
