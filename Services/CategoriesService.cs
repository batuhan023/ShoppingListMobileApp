using EntityLayer.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListMobileApp1.Services
{
    public class CategoriesService
    {
        private const string ApiUrl = "https://192.168.159.1:45455/api/";

        private readonly HttpClient _httpClient;

        public CategoriesService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler);

        }

        public async Task<List<GetCategoryDTO>> GetAllCategories()
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}Categories"); 
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                List<GetCategoryDTO> categories = JsonConvert.DeserializeObject<List<GetCategoryDTO>>(content);
                return categories;
            }
            else
            {
                // API'den veri alınırken hata oluştu
                return null;
            }
        }
    }
}
