using CalculatorTest.Helpers;
using CalculatorTest.Pages;
using CalculatorTest.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
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

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {

            _calculatorPage.hhhhhmmm();
            var fileName = _helper.takeScreenShot("Result");
            //wowrking can get value now
            //var a = _ocrSpaceService.ReadImageService(fileName).Content;
            //_ocrResponse = JsonConvert.DeserializeObject<OcrResponse>(a);
            //var w = _ocrResponse.ParsedResults[0].TextOverlay.Lines[0].LineText;
        }


        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {

        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {

        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Helper.TearDownDriver();
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
        public void ThenShouldBeDisplayed(string p0)
        {
            _calculatorPage.PressCalculatorValue("=");
            //Assert.Fail("Failed");
            _helper.takeScreenShot("ActualResult_");
            //AssertHere Enable OCR Space
            //screenshot actual value
            //get value here
            _calculatorPage.PressCalculatorValue("c");
            //click clear
        }

    }
}
