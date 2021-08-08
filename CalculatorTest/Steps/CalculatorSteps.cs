using CalculatorTest.Helpers;
using CalculatorTest.Pages;
using CalculatorTest.Services;
using Newtonsoft.Json;
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
    }
}
