using System;
using System.Collections.Generic;
using System.Net.Http;
using APITests.Core;
using APITests.Models;

namespace APITests.Services
{
    public class UsersAPI : Base
    {
        private List<Users> usersList = new List<Users>();
        Users users = new Users();

        /// <summary>
        /// List of AssessmentPartial objects
        /// </summary>
        /// <param name="numberPage"></param>
        /// <returns>List of the Assessment</returns>
        public Users Get(int numberPage = 1)
        {
            string query = $"users?page={numberPage}";
            HttpResponseMessage response = _client.GetAsync(query).Result;
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    users = Newtonsoft.Json.JsonConvert.DeserializeObject<Users>(result);
                    
                }
                else
                {
                    Console.WriteLine($"The Code Response was not successfully, Code Response: {response.StatusCode}. Reason: {response.Content.ReadAsStringAsync().Result}");
                    throw new ArgumentException($"The Code Response was not successfully, Code Response: {response.StatusCode}. Reason: {response.Content.ReadAsStringAsync().Result}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred, the status code is: {response.StatusCode}. Reason: {response.Content.ReadAsStringAsync().Result}, Stacktrace: {e.StackTrace}");
                throw new ArgumentException($"Error occurred, the status code is: {response.StatusCode}. Reason: {response.Content.ReadAsStringAsync().Result}");
            }
            return users;
        }
    }
}
