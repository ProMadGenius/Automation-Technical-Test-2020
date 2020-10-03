using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using APITests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APITests.RegressionTests
{
    [TestClass]
    public class UserApiTests
    {
        /// <summary>
        /// S-00002 - Find Email In Get User Page 2
        /// </summary>
        [TestMethod]
        public void FindEmailInGetUser()
        {
            //1.Init vars
            UsersAPI usersApi = new UsersAPI();
            string email = "michael.lawson@reqres.in";
            //2.Verify email is not in Page 1
            var userPage = usersApi.Get(1);
            Assert.IsFalse(userPage.Data.Any(user => user.Email.Equals(email)), "The email was found in page 1, when should be in page 2");
            //3.Verify email is in Page 2
            userPage = usersApi.Get(2);
            Assert.IsTrue(userPage.Data.Any(user => user.Email.Equals(email)), "The email was not found in page 2");
        }
    }
}
