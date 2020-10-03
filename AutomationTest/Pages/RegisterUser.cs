using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UITests.Core;

namespace UITests.Pages
{
    public class RegisterUser
    {
        public IWebElement MrTitleRd => IZWebDriver.FindElement(By.CssSelector("#id_gender1"));
        public IWebElement MrsTitleRd => IZWebDriver.FindElement(By.CssSelector("#id_gender2"));
        public IWebElement CustomerFirstNameTb => IZWebDriver.FindElement(By.CssSelector("#customer_firstname"));
        public IWebElement CustomerLastNameTb => IZWebDriver.FindElement(By.CssSelector("#customer_lastname"));
        public IWebElement PasswordTb => IZWebDriver.FindElement(By.CssSelector("#passwd"));
        public IWebElement FirstNameTb => IZWebDriver.FindElement(By.CssSelector("#firstname"));
        private IWebElement DaysDoBDropdown => IZWebDriver.FindElement(By.CssSelector("#days"));
        private IWebElement MonthsDoBDropdown => IZWebDriver.FindElement(By.CssSelector("#months"));
        private IWebElement YearsDoBDropdown => IZWebDriver.FindElement(By.CssSelector("#years"));
        private IWebElement StateDropdown => IZWebDriver.FindElement(By.CssSelector("#id_state"));

        public IWebElement AddressTb => IZWebDriver.FindElement(By.CssSelector("#address1"));
        public IWebElement CityTb => IZWebDriver.FindElement(By.CssSelector("#city"));
        public IWebElement ZipCodeTb => IZWebDriver.FindElement(By.CssSelector("#postcode"));
        public IWebElement MobilePhoneTb => IZWebDriver.FindElement(By.CssSelector("#phone_mobile"));
        public IWebElement RegisterBtn => IZWebDriver.FindElement(By.CssSelector("#submitAccount"));

        public void SetDateOfBirthDropdown(int day, int month, int year)
        {
            var selectElement = new SelectElement(DaysDoBDropdown);
            selectElement.SelectByValue(day.ToString());

            var selectElement2 = new SelectElement(MonthsDoBDropdown);
            selectElement2.SelectByValue(month.ToString());
            
            var selectElement3 = new SelectElement(YearsDoBDropdown);
            selectElement3.SelectByValue(year.ToString());
        }

        public void SetStateDropdown(string state)
        {
            IZWebDriver.MoveToAnElement(By.CssSelector("#id_state"), 20);
            var selectElement4 = new SelectElement(StateDropdown);
            selectElement4.SelectByText(state);
        }


    }
}
