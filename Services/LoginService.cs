using EntityLayer.DTOs;
using Newtonsoft.Json;
using ShoppingListMobileApp1.Models;
using System.Text;

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


        //Login Service
        public async Task<User> Login(string email, string password)
        {
            //var dto = new LoginDTO { Email = username, Password = password };
            //var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            //var response = await _httpClient.PostAsync(ApiUrl + "Users/login", content);

            var response = await _httpClient.GetAsync($"{ApiUrl}Users/UserLogin?UserEmail={email}&UserPassword={password}");


            //var response = await _httpClient.PostAsync($"{ApiUrl}Users/login?email={username}&password={password}", content);
            //var response = await _httpClient.PostAsync($"{ApiUrl}Users/Login?email={username}&password={password}");
            //TokenDTO model = new();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                //var data = JsonConvert.DeserializeObject<List<User>>(jsonString);
                //var responseData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
                var data = JsonConvert.DeserializeObject<List<User>>(jsonString);

                //return data.FirstOrDefault();
                //if (responseData.ContainsKey("access_token"))
                //{
                //    string token = responseData["accsess_token"];
                // Token'ı kullanmak için yapılacak işlemler
                // Örneğin, Preferences'e kaydedebilir, diğer API çağrıları için kullanabilirsiniz.

                return data.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }


        //Register service
        public async Task<bool> RegisterUser(RegisterDTO user)
        {
            // JSON'a serialize ederek içeriği hazırla
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            try
            {
                // API'ye Post isteği gönder
                var response = await _httpClient.PostAsync(ApiUrl + "Users/register", content);

                // Yanıt başarılı mı kontrol et
                if (response.IsSuccessStatusCode)
                {
                    return true; // Kayıt başarılı
                }
                else
                {
                    return false; // Kayıt başarısız
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda işlemleri burada yönet
                // Örneğin hata mesajını loglamak, kullanıcıya hata mesajı göstermek vb.

                return false;
            }
        }
        }
}
