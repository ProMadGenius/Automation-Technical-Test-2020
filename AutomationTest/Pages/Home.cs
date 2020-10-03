using OpenQA.Selenium;
using UITests.Core;

namespace UITests.Pages
{
    public class Home
    {
        //Objects in the Page
        //TODO: Create all the objects of the Page Home

        public Home()
        {
            IZWebDriver.NGNavigate().GoToUrl("http://automationpractice.com/index.php");
        }

        //Functions
        public void ClickProduct(string nameProduct)
        {
            var product = IZWebDriver.FindElement(By.CssSelector($"#homefeatured h5 a[title='{nameProduct}']"));
            product.Click();
        }

        public void Quit()
        {
            IZWebDriver.Quit();
        }
    }
}
