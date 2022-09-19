using Hectre.OMS.Tests.Selenium;
using NUnit.Framework;
using System;
using System.IO;
using System.Web;

namespace Hectre.OMS.Tests.Utilities.Logs
{
    public static class ResultsXml
    {
        private static readonly string ReportName = "OMS_RESULTS.xml";

        public static string GetProjectReportsDir()
        {
            var projectDir = Fw.WORKSPACE_DIRECTORY;
            string reportsDir = Path.Combine(projectDir, "TestOutputs", "TestLogs");
            return reportsDir;
        }

        /// <summary>
        /// Creates a log of a test result.
        /// </summary>
        /// <param name="caseId">The case to mark</param>
        /// <param name="errMsg">Error messages</param>
        public static void LogResult(ref string errMsg, string caseId = null)
        {

            string logFilePath = Path.Combine(GetProjectReportsDir(), ReportName);
            var ssFileName = Path.Combine(Fw.WORKSPACE_DIRECTORY, "TestReports", $"{caseId}");

            PrintOutput("Log file: " + logFilePath);

            if (caseId == null)
            {
                Assert.Warn("Trying to log result without a valid caseID");
                return;
            }

            if (errMsg.Equals(string.Empty))
            {
                // log success
                WriteSuccess(caseId, logFilePath);
                PrintOutput(caseId + " was marked successful");
            }
            else
            {
                // log failure + errMsg
                WriteFailure(caseId, errMsg, logFilePath, ssFileName);

                errMsg = string.Empty;
                PrintOutput(caseId + " was marked failed");
            }
        }

        /// <summary>
        /// Uses the XML template to append a success to a file at a given path  
        /// </summary>
        /// <param name="caseId">The case to report</param>
        /// <param name="logFilePath">The log file</param>
        private static void WriteSuccess(string caseId, string logFilePath)
        {
            //lock (Locker)
            //{
            using (StreamWriter file = new StreamWriter(logFilePath, append: true))
            {
                file.WriteLine($"<testcase name=\"{caseId}\" status=\"success\">{Environment.NewLine}</testcase>");
            }
            //}
        }

        /// <summary>
        /// Uses the XML template to append a failure to a file at a given path  
        /// </summary>
        /// <param name="caseId">The case to report</param>
        /// <param name="failureMessage">The message to accompany the failure </param>
        /// <param name="logFilePath">The log file</param>
        private static void WriteFailure(string caseId, string failureMessage, string logFilePath, string ssImage = null)
        {
            string encodedXml = HttpUtility.HtmlEncode(failureMessage);
            string failure = $"<testcase name=\"{caseId}\" status=\"error\">" + Environment.NewLine +
                $"<failure message=\"{encodedXml}\" screenCapturePath=\"{ssImage}\"/>" + Environment.NewLine +
                "</testcase>" + Environment.NewLine;

            //lock (Locker)
            //{
            using (StreamWriter file = new StreamWriter(logFilePath, append: true))
            {
                file.WriteLine(failure);
            }
            //}
        }

        /// <summary>
        /// Outputs the string to the output file
        /// </summary>
        /// <param name="output">The string to output</param>
        public static void PrintOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}
