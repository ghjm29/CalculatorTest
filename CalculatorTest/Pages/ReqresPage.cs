using CalculatorTest.Helpers;
using CalculatorTest.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CalculatorTest.Pages
{
    class ReqresPage
    {
        IWebDriver _driver;
        Helper _helper;
        OcrSpaceService OcrSpaceService;
        By byListUsersApi = By.XPath("//li/a[.=' Create ']");
        By byApiUrl = By.XPath("//strong/a/span");
        By byStatusCode = By.XPath("//strong/span");
        By byResponse = By.XPath("//div/pre[@data-key='output-response']");
        By byRequest = By.XPath("");

        public ReqresPage()
        {
            _driver = Helper.runDriver();
            _helper = new Helper();
            OcrSpaceService = new OcrSpaceService();
        }

        public void NavigateToReqresPage()
        {
            _driver.Navigate().GoToUrl("https://reqres.in/");
            _helper.WaitForElement(byListUsersApi);
        }

        public void ClickApiAndGetRequestAndResponse()
        {
            _driver.FindElement(byListUsersApi).Click();
            Thread.Sleep(2500);
            var requestUrl = _driver.FindElement(byApiUrl).Text;
            var requestCode = _driver.FindElement(byStatusCode).Text;
            var payload = ProcessThePayload();
            var response = _driver.FindElement(byResponse).Text;
            var actual = OcrSpaceService.CreateUser(JsonConvert.SerializeObject(payload));
            Assert.AreEqual(response, actual.Content);
        }

        JObject ProcessThePayload()
        {
            var jObject = new JObject();
            var key = By.XPath("//pre[@data-key='output-request']/span[@class='key']");
            var value = By.XPath("//pre[@data-key='output-request']/span[@class='string']");
            var keys = _driver.FindElements(key);
            var values = _driver.FindElements(value);
            for (int i = 0; i < keys.Count; i++)
            {
                jObject.Add(keys[i].Text, values[i].Text);
            }
            return jObject;
        }

    }
}
