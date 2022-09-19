using Hectre.OMS.Tests.Utilities.Logs;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Hectre.OMS.Tests.Selenium
{
    internal static class Fw
    {
        //public static string WORKSPACE_DIRECTORY = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;
        public static string WORKSPACE_DIRECTORY = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
        private static FwConfig? _configuration;
        public static FwConfig Config => _configuration ?? throw new NullReferenceException("Config is null. Call Fw.SetConfig() first.");
        public static Logger Log => _logger ?? throw new NullReferenceException("Logger is null. Call FW.SetLogger() first.");
        [ThreadStatic]
        private static Logger _logger;


        private static readonly object _setLoggerLock = new object();
        public static void SetConfig()
        {
            if (_configuration == null)
            {
                var t = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "appconfig.json");
                var jsonStr = File.ReadAllText(t);
                _configuration = JsonConvert.DeserializeObject<FwConfig>(jsonStr);
                _configuration.StartingUrl = StartingUrl(_configuration.Environment);
            }
        }

        public static void SetLogger()
        {
            lock (_setLoggerLock)
            {
                var testResultsDirectory = WORKSPACE_DIRECTORY + "/TestOutputs/TestLogs";
                var testName = TestContext.CurrentContext.Test.Name;
                var testId = TestContext.CurrentContext.Test.ID;
                _logger = new Logger(testName, testResultsDirectory + $"/{testId}_{testName}.txt");
            }
        }

        public static DirectoryInfo CreateXmlResultsFile()
        {
            var testResultsDirectory = WORKSPACE_DIRECTORY + "/TestOutputs/XmlLog";

            if (Directory.Exists(testResultsDirectory))
            {
                DeleteDirRecursively(testResultsDirectory);
            }

            return Directory.CreateDirectory(testResultsDirectory);
        }

        public static void CreateDirectories()
        {
            CreateTestOutputsDir();
            CreateTestLogDirectory();
            CreateScreenshotsDir();
        }

        public static void CreateScreenshotsDir()
        {
            var testOutputsDir = WORKSPACE_DIRECTORY + "/TestOutputs/Screenshots";

            if (Directory.Exists(testOutputsDir))
            {
                DeleteDirRecursively(testOutputsDir);
            }

            Directory.CreateDirectory(testOutputsDir);
        }

        public static DirectoryInfo CreateTestOutputsDir()
        {
            var testOutputsDir = WORKSPACE_DIRECTORY + "/TestOutputs";

            if (Directory.Exists(testOutputsDir))
            {
                DeleteDirRecursively(testOutputsDir);
            }

            return Directory.CreateDirectory(testOutputsDir);
        }

        public static void CreateTestLogDirectory()
        {
            var testLogDirectory = WORKSPACE_DIRECTORY + "/TestOutputs/TestLogs";

            if (Directory.Exists(testLogDirectory))
            {
                DeleteDirRecursively(testLogDirectory);
            }

            Directory.CreateDirectory(testLogDirectory);
        }



        public static void DeleteDirRecursively(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                try
                {
                    Directory.Delete(dirPath, recursive: true);
                }
                catch
                {
                    Thread.Sleep(500);
                    Directory.Delete(dirPath, recursive: true);
                }
            }
        }

        private static string StartingUrl(string environment)
        {
            string startingUrl;
            switch (environment)
            {
                case "develop":
                    startingUrl = _configuration.Environment_Urls.Develop;
                    break;
                case "staging":
                    startingUrl = _configuration.Environment_Urls.Staging;
                    break;
                case "prod":
                    startingUrl = _configuration.Environment_Urls.Prod;
                    break;
                default:
                    startingUrl = _configuration.Environment_Urls.Develop;
                    break;
            }
            return startingUrl;
        }
    }
}
