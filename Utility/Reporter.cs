using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AventStack.ExtentReports.Reporter;

namespace DemoSelenium.Utility
{
    public class Reporter
    {
        private IWebDriver driver;
        private ExtentReports extent;
        private ExtentTest testlog;
        private string reportPath;

        public Reporter(IWebDriver driver, string reportName)
        {
            this.driver = driver;

            // Setup Reporter Path
            string path = Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            reportPath = projectPath + "Reports\\";
            System.IO.Directory.CreateDirectory(reportPath);

            // Setup Reporter
            extent = new ExtentReports();
            ExtentSparkReporter spark = new ExtentSparkReporter(reportPath + $"Report_{reportName}.html");
            extent.AttachReporter(spark);

            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Tester", Environment.UserName);
            extent.AddSystemInfo("MachineName", Environment.MachineName);
        }

        /// <summary>
        /// Start Logging
        /// </summary>
        /// <param name="testsToStart"></param>
        public void StartExtentTest(string testsToStart)
        {
            testlog = extent.CreateTest(testsToStart);
        }

        /// <summary>
        /// Log Result
        /// </summary>
        /// <param name="testContext"></param>
        public void LoggingTestStatusExtentReport(TestContext testContext)
        {
            try
            {
                var status = testContext.CurrentTestOutcome;
                Status logstatus;
                switch (status)
                {
                    case UnitTestOutcome.Failed:
                        logstatus = Status.Fail;
                        testlog.Log(Status.Fail, "Test steps NOT Completed for Test case " + testContext.TestName);
                        testlog.Log(Status.Fail, "Test ended with " + Status.Fail);
                        break;
                    case UnitTestOutcome.Aborted:
                        logstatus = Status.Skip;
                        testlog.Log(Status.Skip, "Test ended with " + Status.Skip);
                        break;
                    default:
                        logstatus = Status.Pass;
                        testlog.Log(Status.Pass, "Test steps finished for test case " + testContext.TestName);
                        testlog.Log(Status.Pass, "Test ended with " + Status.Pass);
                        break;
                }
            }
            catch (WebDriverException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// End Logging
        /// </summary>
        public void EndReporter()
        {
            //End Logging
            extent.Flush();
        }
    }
}
