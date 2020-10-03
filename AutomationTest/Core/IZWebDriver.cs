using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace UITests.Core
{
    public class IZWebDriver
    {
        private static readonly IZWebDriver _instance = new IZWebDriver();

        private static IWebDriver privateDriver;
        private static string outPutDirectory;
        public EventFiringWebDriver driver;

        private IZWebDriver()
        { }

        public void GoTo(string url)
        {
            privateDriver.Navigate().GoToUrl(url);
        }

        [TestCleanup]
        public void CleanUp()
        {
            privateDriver.Quit();
        }

        public IZWebDriver Instance
        {
            get
            {
                // The first call will create the one and only instance.
                if (privateDriver == null)
                {
                    outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    privateDriver = new ChromeDriver(outPutDirectory);
                    driver = new EventFiringWebDriver(privateDriver);

                    driver.ExceptionThrown += ExceptionThrown;
                    driver.FindingElement += FindingElement;
                    driver.FindElementCompleted += FindElementCompleted;
                    driver.ElementClicking += ElementClicking;
                    driver.ElementClicked += ElementClicked;
                    driver.ElementValueChanging += ElementValueChanging;
                    driver.ElementValueChanged += ElementValueChanged;
                    driver.ScriptExecuting += ScriptExecuting;
                    driver.ScriptExecuted += ScriptExecuted;
                }
                // Every call afterwards will return the single instance created above.
                return _instance;
            }
        }

        /// <summary>
        /// Use ExplicitWait to wait for an element to exist
        /// </summary>
        /// <param name="by">Criteria by which the element will be located.</param>
        /// <param name="timeOut">Maximum amount of time to wait for locate the element (in seconds).</param>
        /// <returns>Return the element if it is located, an exception if it is not.</returns>
        public static IWebElement FindElement(By by, int timeOut = 10)
        {
            try
            {
                var wait = new WebDriverWait(_instance.Instance.driver, TimeSpan.FromSeconds(timeOut));
                //-> To avaid exceptions related to page refreshed
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

                IWebElement result = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                return result;
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        /// <summary>
        /// Finish the test and close the browser
        /// </summary>
        public static void Quit()
        {
            privateDriver.Quit();
        }

        /// <summary>
        /// Use ExplicitWait to wait for an element to be visible
        /// </summary>
        /// <param name="by">Criteria by which the element will be located.</param>
        /// <param name="timeOut">Maximum amount of time to wait for locate the element (in seconds).</param>
        /// <returns>Return the element if it is located, an exception if it is not.</returns>
        public static IWebElement FindElementWhenIsVisible(By by, int timeOut = 10)
        {
            try
            {
                var wait = new WebDriverWait(_instance.Instance.driver, TimeSpan.FromSeconds(timeOut));
                //-> To avoid exceptions related to page refreshed
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                IWebElement result = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return result;
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        /// <summary>
        /// This Method scroll the page to the specific control.
        /// This is the method that will be used henceforth.
        /// </summary>
        /// <param name="by">Criteria by which the element will be located.</param>
        /// <param name="initialWait">Initial wait or delay to start locating the element (in milliseconds).</param>
        /// <param name="timeout">Maximum amount of time to wait for locate the element (in seconds).</param>
        public static void MoveToAnElement(By by, int timeout = 20, bool forceOutOfViewPort = false)
        {
            if (ElementExist(by, timeout))
            {
                if (forceOutOfViewPort)
                {
                    // use javascript scrollIntoView(false) to scroll to element
                    IJavaScriptExecutor je = (IJavaScriptExecutor)privateDriver;
                    je.ExecuteScript("arguments[0].scrollIntoView(false);", FindElement(by));
                }
            }
            else
            {
                throw new ElementNotVisibleException("The page cannot scroll to an element that doesn't exist");
            }
        }

        /// <summary>
        /// This method move the mouse over a control with a user-defined timeout and an initial wait.
        /// </summary>
        /// <param name="by">Criteria by which the element will be located.</param>
        /// <param name="timeout">Maximum amount of time to wait for locate the element (in seconds).</param>
        /// 
        /// <returns>Return true if the element exist, false if it is not exist.</returns>
        public static bool ElementExist(By by, int timeout = 20)
        {
            try
            {
                var element = FindElement(by, timeout);
                return element != null;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        /// <summary>
        /// Navidates to URLs
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static INavigation NGNavigate()
        {
            var result = _instance.Instance.driver.Navigate();
            return result;
        }

        private void ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            Trace.WriteLine(e.ThrownException.Message);
        }

        private void FindingElement(object sender, FindElementEventArgs e)
        {
            string objectFrom = e.Element == null ? "IWebDriver" : "IWebElement";
            Trace.WriteLine($"FindingElement from {objectFrom} {e.FindMethod.ToString()}");
        }

        private void FindElementCompleted(object sender, FindElementEventArgs e)
        {
            string objectFrom = e.Element == null ? "IWebDriver" : "IWebElement";
            Trace.WriteLine($"FindElementCompleted from {objectFrom} {e.FindMethod.ToString()}");
        }

        private void ElementClicking(object sender, WebElementEventArgs e)
        {
            Trace.WriteLine($"Clicking element");
        }

        private void ElementClicked(object sender, WebElementEventArgs e)
        {
            Trace.WriteLine("Element clicked");
        }

        private void ElementValueChanging(object sender, WebElementEventArgs e)
        {
            Trace.WriteLine($"The value of the following element will be changed now: {e.Element}");
        }

        private void ElementValueChanged(object sender, WebElementEventArgs e)
        {
            Trace.WriteLine($"The value of the following element was changed: {e.Element}");
        }

        private void ScriptExecuting(object sender, WebDriverScriptEventArgs e)
        {
            Trace.WriteLine($"The following script will be executed: {e.Script}");
        }

        private void ScriptExecuted(object sender, WebDriverScriptEventArgs e)
        {
            Trace.WriteLine($"The following script was executed: {e.Script}");
        }
    }
}
