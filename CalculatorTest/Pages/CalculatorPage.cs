using CalculatorTest.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CalculatorTest.Pages
{
    class CalculatorPage
    {
        IWebDriver _driver;
        Helper _helper;

        By _byFrameCanvas = By.Id("fullframe");
        By _byCalculator = By.Id("canvas");
        By _byBody = By.TagName("body");

        public CalculatorPage()
        {
            _driver = Helper.runDriver();
            _helper = new Helper();
        }

        public void NavigateToCalculatorPage()
        {
            _driver.Navigate().GoToUrl("https://www.online-calculator.com/full-screen-calculator/");
            _helper.WaitForElement(_byFrameCanvas);
        }

        public void PressCalculatorValue(string value)
        {
            _helper.SendKeys(_byBody, value);
        }
    }
}
