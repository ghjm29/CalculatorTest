using CalculatorTest.Helpers;
using CalculatorTest.Pages;
using System;
using TechTalk.SpecFlow;

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
