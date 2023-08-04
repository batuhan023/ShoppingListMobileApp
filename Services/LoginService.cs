using Azure;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Org.Apache.Http.Protocol;
using ShoppingListMobileApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListMobileApp1.Services
{
    public class LoginService

      
    {
        private const string ApiUrl = "https://192.168.159.1:45455/api/";

        private readonly HttpClient _httpClient;

        public LoginService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler);
            _httpClient.Timeout = TimeSpan.FromSeconds(400);
        }

        //public async Task<User> Login(string email, string password)
        //{
        //    var dto = new LoginDTO { Email = email, Password = password }; 
        //    var response = await _httpClient.PostAsync(ApiUrl + "Users/login", new StringContent(""));

        //    if (response.IsSuccessStatusCode)
        //    {
        //        //Application.Current.MainPage.Navigation.PushAsync(new HomePage());

        //        //return Response.("YeniSayfa.aspx");
        //        var user = await response.Content.ReadAsAsync<User>();
        //        return user;

        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public async Task<User> Login(string username, string password)
        {
            var dto = new LoginDTO { Email = username, Password = password };
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ApiUrl + "Users/login", content);
            //var response = await _httpClient.PostAsync($"{ApiUrl}Users/login?email={username}&password={password}", content);
            //var response = await _httpClient.PostAsync($"{ApiUrl}Users/Login?email={username}&password={password}");
            TokenDTO model = new();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                //var data = JsonConvert.DeserializeObject<List<User>>(jsonString);
                //var responseData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
                var user = JsonConvert.DeserializeObject<User>(jsonString);
                //return data.FirstOrDefault();
                //if (responseData.ContainsKey("access_token"))
                //{
                //    string token = responseData["accsess_token"];
                // Token'ı kullanmak için yapılacak işlemler
                // Örneğin, Preferences'e kaydedebilir, diğer API çağrıları için kullanabilirsiniz.

                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
