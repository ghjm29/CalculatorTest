using CalculatorTest.Helpers;
using CalculatorTest.Pages;
using System;
using TechTalk.SpecFlow;
using Tesseract;

namespace CalculatorTest.Steps
{
    [Binding]
    public class CalculatorSteps
    {
        CalculatorPage _calculatorPage;
        Helper _helper;

        public CalculatorSteps()
        {
            _calculatorPage = new CalculatorPage();
            _helper = new Helper();
        }

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            _calculatorPage.hhhhhmmm();
            _helper.takeScreenShot("Result");
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {
            //var ocrengine = new TesseractEngine(@".\tessdata", "eng", EngineMode.Default);
            //var ocrengine = new TesseractEngine(@"C:\Users\78434\source\repos\CalculatorTest\CalculatorTest\bin\Debug\tessdata", "eng", EngineMode.Default);
            var ocrengine = new TesseractEngine(@"C:\Users\78434\source\repos\CalculatorTest\CalculatorTest\bin\Debug\tessdata", "eng");
            //var img = Pix.LoadFromFile(@"C:\Users\78434\source\repos\CalculatorTest\TestResults\87202123821PM\9.png");
            var img = Pix.LoadFromFile(@"C:\Users\78434\Downloads\tesseract-samples-master\src\Tesseract.ConsoleDemo\phototest.tif");
        
             var res = ocrengine.Process(img);
            var a = res.GetText();
            ocrengine.Dispose();
            //Console.WriteLine(res.GetText());
            //Console.ReadKey();
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
