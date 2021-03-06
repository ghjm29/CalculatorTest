using CalculatorTest.Helpers;
using CalculatorTest.Pages;
using CalculatorTest.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CalculatorTest.Steps
{
    [Binding]
    public class CalculatorSteps
    {
        CalculatorPage _calculatorPage;
        Helper _helper;
        OcrSpaceService _ocrSpaceService;
        OcrResponse _ocrResponse;

        public CalculatorSteps()
        {
            _calculatorPage = new CalculatorPage();
            _helper = new Helper();
            _ocrSpaceService = new OcrSpaceService();
            _ocrResponse = new OcrResponse();
        }

        [Given(@"Open chrome browser and start application")]
        public void GivenOpenChromeBrowserAndStartApplication()
        {
            _calculatorPage.NavigateToCalculatorPage();
            _calculatorPage.PressCalculatorValue("c");
        }

        [When(@"I (.*) (.*) and (.*)")]
        public void WhenIAnd(string operatorValue, string value1, string value2)
        {
            _calculatorPage.PressCalculatorValue(value1);
            _helper.takeScreenShot("FirstValuePressed_" + value1);
            _calculatorPage.PressCalculatorValue(operatorValue);
            _helper.takeScreenShot("OperatorPressed_" + operatorValue);
            _calculatorPage.PressCalculatorValue(value2);
            _helper.takeScreenShot("SecondValuePressed_" + value2);
        }

        [Then(@"(.*) should be displayed")]
        public void ThenShouldBeDisplayed(string expectedValue)
        {
            _calculatorPage.PressCalculatorValue("=");
            Thread.Sleep(200);
            var fileName = _helper.takeScreenShot("ActualResult_");
            _ocrResponse = JsonConvert.DeserializeObject<OcrResponse>(_ocrSpaceService.ReadImageService(fileName).Content);
            var actualValue = _ocrResponse.ParsedResults[0].TextOverlay.Lines[0].LineText;
            Assert.AreEqual(expectedValue, actualValue, "Error expected value is - " + expectedValue + ", but actual is - " + actualValue + ".");
            _calculatorPage.PressCalculatorValue("c");
        }

    }
}
