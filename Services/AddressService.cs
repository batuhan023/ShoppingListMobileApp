
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListMobileApp1.Services
{
    public class AddressService
    {
        private const string ApiUrl = "https://192.168.159.1:45455/api/";

        private readonly HttpClient _httpClient;

        public AddressService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = new Uri(ApiUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(400);
        }

        // Address Service
        public async Task<Address> Address(User user, int userId, string addressname, string countryname, string cityname, 
            string townname, string districtname, int postcode, string addresstext)
        {
            var address = new Address
            {
                UserId = userId,
                User = user,
                AddressName = addressname,
                CountryName = countryname,
                CityName = cityname,
                TownName = townname,
                DistrictName = districtname,
                PostCode = postcode,
                AddressText = addresstext 
            };

            var json = JsonConvert.SerializeObject(address);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Addresses/addaddress", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Address>(jsonString);
                return data;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<GetAddressDTO>> GetAddress(int id)
        {
            var response = await _httpClient.GetAsync(ApiUrl + "Addresses/getAddressesByUserId?userId=" + id);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var addressDTO = JsonConvert.DeserializeObject<List<GetAddressDTO>>(jsonContent);

                return addressDTO;
            }
            else
            {
                // API'dan veri alınırken hata oluştu, uygun bir hata sayfasına yönlendirilebilir.
                return null;
            }
            
        }

        public async Task<GetAddressDTO> UpdateAddress(GetAddressDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync(ApiUrl + "Addresses/update", dto);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var addressDTO = JsonConvert.DeserializeObject<GetAddressDTO>(jsonContent);

                return addressDTO;
            }
            else
            {
                // API'dan veri alınırken hata oluştu, uygun bir hata sayfasına yönlendirilebilir.
                return null;
            }
        }

        public async Task<GetAddressDTO> DeleteAddress(int id)
        {
            var response = await _httpClient.DeleteAsync(ApiUrl + "Addresses/delete?addressID=" + id);

            if (response.IsSuccessStatusCode)
            {
                //var jsonContent = await response.Content.ReadAsStringAsync();
                //var addressDTO = JsonConvert.DeserializeObject<GetAddressDTO>(jsonContent);

                //return addressDTO;

                return null;
            }
            else
            {
                // API'dan veri alınırken hata oluştu, uygun bir hata sayfasına yönlendirilebilir.
                return null;
            }
        }
    }
}
