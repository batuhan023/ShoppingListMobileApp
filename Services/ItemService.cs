using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListMobileApp1.Services
{
    public class ItemService
    {
        private const string ApiUrl = "https://192.168.159.1:45455/api/";

        private readonly HttpClient _httpClient;

        public ItemService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler);

        }
        public async Task<List<GetItemDTO>> GetAllItems()
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}Items");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                List<GetItemDTO> categories = JsonConvert.DeserializeObject<List<GetItemDTO>>(content);
                return categories;
            }
            else
            {
                // API'den veri alınırken hata oluştu
                return null;
            }
        }

        public async Task<List<Item>> GetItemsByCategory(int categoryId)
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}Items/getItemsByCategoryId?categoryId={categoryId}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Item>>(content);
               
            }
            else
            {
                // API'den veri alınırken hata oluştu
                return null;
            }
        }

        public async Task<Item> GetItemsById(int itemId) 
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}Items/getById?id={itemId}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Item>(content);

            }
            else
            {
                // API'den veri alınırken hata oluştu
                return null;
            }
        }
    }
}
