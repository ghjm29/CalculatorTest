using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace CalculatorTest.Helpers
{
    [Binding]
    class ReportHelper
    {
        static ExtentReports extent;
        static ExtentTest featureName;
        static ExtentTest scenario;
        readonly ScenarioContext _scenarioContext;
        Helper _helper;

        public ReportHelper(ScenarioContext scenarioContex)
        {
            _scenarioContext = scenarioContex;
            _helper = new Helper();
        }

        [BeforeTestRun]
        public static void BeforeTestRunSetupReport()
        {
            Helper.SetReportDirectory();
            extent = new ExtentReports();
            string pathReport = Helper.reportPath + "\\report.html"; 
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(pathReport);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                var path = "";
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    path = _helper.takeScreenShot(TestContext.CurrentContext.Test.MethodName);
                    scenario.CreateNode<Given>("Screenshot - " + path).Fail("", MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build());
                    if (_scenarioContext.TestError.StackTrace != null)
                        scenario.CreateNode<Given>("Stack Trace - ").Fail(_scenarioContext.TestError.StackTrace);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    path = _helper.takeScreenShot(TestContext.CurrentContext.Test.MethodName);
                    scenario.CreateNode<Given>("Screenshot - " + path).Fail("", MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build());
                    if (_scenarioContext.TestError.StackTrace != null)
                        scenario.CreateNode<When>("Stack Trace - ").Fail(_scenarioContext.TestError.StackTrace);

                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    path = _helper.takeScreenShot(TestContext.CurrentContext.Test.MethodName);
                    scenario.CreateNode<Given>("Screenshot - " + path).Fail("", MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build());
                    if (_scenarioContext.TestError.StackTrace != null)
                        scenario.CreateNode<Then>("Stack Trace - ").Fail(_scenarioContext.TestError.StackTrace);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    path = _helper.takeScreenShot(TestContext.CurrentContext.Test.MethodName);
                    scenario.CreateNode<Given>("Screenshot - " + path).Fail("", MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build());
                    if (_scenarioContext.TestError.StackTrace != null)
                        scenario.CreateNode<And>("Stack Trace - ").Fail(_scenarioContext.TestError.StackTrace);
                }
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            if (extent != null)
            {
                extent.Flush();
            }
            Helper.TearDownDriver();
        }
    }
}
