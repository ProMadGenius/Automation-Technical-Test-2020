using OpenQA.Selenium;
using UITests.Core;

namespace UITests.Pages
{
    public class Cart
    {
        public IWebElement ProceedToCheckoutBtn => IZWebDriver.FindElement(By.CssSelector("p a[title='Proceed to checkout']"));
        public IWebElement EmailAddressCheckoutBtn => IZWebDriver.FindElement(By.CssSelector("#email_create"));
        public IWebElement CreateAnAccountBtn => IZWebDriver.FindElement(By.CssSelector("#SubmitCreate"));
        public IWebElement ProceedToCheckoutAddressBtn => IZWebDriver.FindElementWhenIsVisible(By.CssSelector("button[name='processAddress']"));
        public IWebElement ProceedToCheckoutShippingBtn => IZWebDriver.FindElement(By.CssSelector("button[name='processCarrier']"));
        public IWebElement AgreeTermsOfServiceCheckbox => IZWebDriver.FindElement(By.CssSelector("#cgv"));
        public IWebElement PayByBankWireBtn => IZWebDriver.FindElement(By.CssSelector(".bankwire"));
        public IWebElement ConfirmMyOrdenBtn => IZWebDriver.FindElement(By.CssSelector("div#center_column button"));

        public bool IsMyOrderCompleted()
        {
            var text = IZWebDriver.FindElement(By.CssSelector("p strong"));
            return text.Text.Equals("Your order on My Store is complete.");
        }
    }
}
