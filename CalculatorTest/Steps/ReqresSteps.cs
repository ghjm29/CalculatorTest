using CalculatorTest.Pages;
using System;
using TechTalk.SpecFlow;

namespace CalculatorTest.Steps
{
    [Binding]
    public class ReqresSteps
    {
        ReqresPage _reqresPage;

        [Given(@"I'm a customer")]
        public void GivenIMACustomer()
        {
            _reqresPage = new ReqresPage();
            _reqresPage.NavigateToReqresPage();
        }
        
        [When(@"I click the api (.*)")]
        public void WhenIClick(string p0)
        {
            _reqresPage.ClickApiAndGetRequestAndResponse();
        }
        
        [When(@"I send a request to the api using the request")]
        public void WhenISendARequestToTheApiUsingTheRequest()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"(.*) request and expected response will be provided")]
        public void ThenRequestAndExpectedResponseWillBeProvided(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"actual response should be as expected")]
        public void ThenIActualResponseShouldBeAsExpected()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
