using Newtonsoft.Json;
using ShoppingListMobileApp1.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListMobileApp1.Services
{
    public class RegisterService
    {
        private const string ApiUrl = "https://192.168.159.1:45455/api/";

        private readonly HttpClient _httpClient;

        public RegisterService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = new Uri(ApiUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(400);
        }

        // Register Service
        public async Task<User> Register(string username, string password, string name, string surname, string email, bool gender,
            DateTime birthdate, DateTime registerdate, int phonenumber)
        {
            var user = new User
            {
                UserName = username,
                Password = password,
                Name = name,
                Surname = surname,
                Email = email,
                Gender = gender ? true:false, // Assuming you use string "Male" or "Female" in your API
                BirthDate = birthdate,
                RegisterDate = registerdate,
                PhoneNumber = phonenumber
            };

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Users/register", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var registeredUser = JsonConvert.DeserializeObject<User>(jsonString);
                return registeredUser;
            }
            else
            {
                return null;
            }
        }
    }
}
