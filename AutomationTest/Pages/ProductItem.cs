using OpenQA.Selenium;
using UITests.Core;

namespace UITests.Pages
{
    public class ProductItem
    {
        public IWebElement AddToCartBtn => IZWebDriver.FindElement(By.CssSelector("button[name='Submit']"));
        public IWebElement ProceedToCheckoutBtn => IZWebDriver.FindElementWhenIsVisible(By.CssSelector("a[title='Proceed to checkout']"));
    }
}
