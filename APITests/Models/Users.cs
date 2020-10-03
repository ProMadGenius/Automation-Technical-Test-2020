using System;
using System.Collections.Generic;

namespace APITests.Models
{
    public partial class Users
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public List<User> Data { get; set; }
        public Ad Ad { get; set; }
    }

    public class Ad
    {
        public string Company { get; set; }
        public Uri Url { get; set; }
        public string Text { get; set; }
    }

    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Uri Avatar { get; set; }
    }
}
