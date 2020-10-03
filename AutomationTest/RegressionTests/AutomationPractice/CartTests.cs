using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UITests.Pages;

namespace UITests.RegressionTests.AutomationPractice
{
    [TestClass]
    public class CartTests
    {
        
        RegisterUser registerUser = new RegisterUser();
        ProductItem productItem = new ProductItem();
        Cart cart = new Cart();

        /// <summary>
        /// S-12345:: Buy a product E2E
        /// </summary>
        [TestMethod]
        public void BuyAProductE2E()
        {
            //1.Load The Main Page
            Home home = new Home();
            //2.Click the product
            home.ClickProduct("Blouse");
            //3.Click Add to Cart button
            productItem.AddToCartBtn.Click();
            //4.Click Proceed to checkout button
            productItem.ProceedToCheckoutBtn.Click();
            //5.In The Cart Summary Page, click Proceed to checkout once more
            cart.ProceedToCheckoutBtn.Click();
            //6.In Step Two -> Set the Text:contacto@hackeame.org
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(1000);
            cart.EmailAddressCheckoutBtn.SendKeys($"contact{randomInt}@hackme.org");
            //7.Click Create an account
            cart.CreateAnAccountBtn.Click();
            //8.Fill all the information
            registerUser.MrTitleRd.Click();
            registerUser.CustomerFirstNameTb.SendKeys("Isaac");
            registerUser.CustomerLastNameTb.SendKeys("Zarzuri");
            registerUser.PasswordTb.SendKeys("Zarzuri.7");
            registerUser.SetDateOfBirthDropdown(3, 6, 1990);
            registerUser.AddressTb.SendKeys("Las Americas Street, 1574");
            registerUser.CityTb.SendKeys("Santa Cruz");
            registerUser.SetStateDropdown("Delaware");
            registerUser.ZipCodeTb.SendKeys("85123");
            registerUser.MobilePhoneTb.SendKeys("770267477");
            //9.Click Register
            registerUser.RegisterBtn.Click();
            //10.Click Proceed to Checkout in Cart
            cart.ProceedToCheckoutAddressBtn.Click();
            //11.Check the I Agree the terms of service
            cart.AgreeTermsOfServiceCheckbox.Click();
            //12.Click Proceed to Checkout in Shipping
            cart.ProceedToCheckoutShippingBtn.Click();
            //13.Select Pay By Bank Wire
            cart.PayByBankWireBtn.Click();
            //14.Click Confirm My Order
            cart.ConfirmMyOrdenBtn.Click();
            //15.Verify the text message says: Your Order on My Store is complete.
            Assert.IsTrue(cart.IsMyOrderCompleted());
            home.Quit();
        }
    }
}
