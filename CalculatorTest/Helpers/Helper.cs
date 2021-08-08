using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculatorTest.Helpers
{
    public class Helper
    {

        public static IWebDriver _driver;
        public static string fileName;
        static WebDriverWait _wait;
        static string timeAndDate;
        static int ssCounter = 0;
        static DirectoryInfo reportPath;


        public static IWebDriver runDriver()
        {
            if (_driver == null)
            {
                var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(
                        "--window-size=1440,900",
                        "--start-maximized"
                        );

                _driver = new ChromeDriver(chromeOptions);
                InitializeWait();
                SetReportDirectory();
            }
            return _driver;
        }

        public static void TearDownDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
        }

        public static void InitializeWait()
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20))
            {
                PollingInterval = TimeSpan.FromSeconds(0.40),
            };
            _wait.IgnoreExceptionTypes(typeof(NotFoundException),
                                      typeof(NoSuchElementException),
                                      typeof(StaleElementReferenceException),
                                      typeof(ElementNotInteractableException),
                                      typeof(ElementNotVisibleException)
                                      );
        }

        public void WaitForElement(By by)
        {
            _wait.Until(d =>
            {
                IList<IWebElement> li = d.FindElements(by);
                if (li.Count > 0)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            });
        }

        private static void SetReportDirectory()
        {
            timeAndDate = new StringBuilder(DateTime.Now.ToString()).Replace("/", "").Replace(":", "").ToString();
            reportPath = new DirectoryInfo(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\TestResults\\")) + Regex.Replace(timeAndDate, @"\s", ""));
        }

        public string takeScreenShot(string ssName)
        {
            ssCounter++;
            fileName = null;
            fileName = ssCounter.ToString() + "_" + ssName + "_" + fileName + timeAndDate + ".png";
            var screenshotFile = reportPath + "\\" + fileName;
            if (reportPath.Exists == true)
            {
                ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(screenshotFile);
            }
            else
            {
                reportPath.Create();
                ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(screenshotFile);
            }
            Console.WriteLine("Screenshot saved: - " + fileName);
            return screenshotFile;
        }

        /// <summary>
        /// Convert string value from examples table to keys that will be sent via keyboard
        /// </summary>
        /// <param name="elementLocator">Element locator where to send key</param>
        /// <param name="value">Keyboard value to be converted</param>
        public void SendKeys(By elementLocator, string value)
        {
            switch (value)
            {
                case "1":
                    _driver.FindElement(elementLocator).SendKeys(Keys.NumberPad1);
                    break;
                case "2":
                    _driver.FindElement(elementLocator).SendKeys(Keys.NumberPad2);
                    break;
                case "3":
                    _driver.FindElement(elementLocator).SendKeys(Keys.NumberPad3);
                    break;
                case "4":
                    _driver.FindElement(elementLocator).SendKeys(Keys.NumberPad4);
                    break;
                case "5":
                    _driver.FindElement(elementLocator).SendKeys(Keys.NumberPad5);
                    break;
                case "6":
                    _driver.FindElement(elementLocator).SendKeys(Keys.NumberPad6);
                    break;
                case "7":
                    _driver.FindElement(elementLocator).SendKeys(Keys.NumberPad7);
                    break;
                case "8":
                    _driver.FindElement(elementLocator).SendKeys(Keys.NumberPad8);
                    break;
                case "9":
                    _driver.FindElement(elementLocator).SendKeys(Keys.NumberPad9);
                    break;
                case "0":
                    _driver.FindElement(elementLocator).SendKeys(Keys.NumberPad0);
                    break;
                case "+":
                    _driver.FindElement(elementLocator).SendKeys(Keys.Add);
                    break;
                case "-":
                    _driver.FindElement(elementLocator).SendKeys(Keys.Subtract);
                    break;
                case "/":
                    _driver.FindElement(elementLocator).SendKeys(Keys.Divide);
                    break;
                case "=":
                    _driver.FindElement(elementLocator).SendKeys(Keys.Equal);
                    break;
            }
        }
    }
}
