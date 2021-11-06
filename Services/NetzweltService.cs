using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FerdsWebApp.DTOs;
using Newtonsoft.Json;

namespace FerdsWebApp.Services
{
    public interface INetzweltService
    {
        Task<ReturnAuthUserDto> GetUser(AuthUserDto authUserDTO);
        Task<ReturnTerritoryDto> GetTerritories();
    }

    public class NetzweltService : INetzweltService
    {
        private HttpClient _httpClient;
        public NetzweltService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ReturnTerritoryDto> GetTerritories()
        {
            var url = "/Territories/All";
            var response = await _httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                return  null;

            var returnTerritoryDto = JsonConvert.DeserializeObject<ReturnTerritoryDto>(result.ToString());
            return returnTerritoryDto;
        }

        public async Task<ReturnAuthUserDto> GetUser(AuthUserDto authUserDTO)
        {
            var url = "/Account/SignIn";
            var json = JsonConvert.SerializeObject(authUserDTO);
            var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, data);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return new ReturnAuthUserDto { Error = result.ToString() };

            return JsonConvert.DeserializeObject<ReturnAuthUserDto>(result.ToString());
        }

        // private List<TerritoryDto> ArrangeTerritories(List<TerritoryDto> territories) 
        // {
        //     var arrangedTerritories = new List<TerritoryDto>();
        //     return arrangedTerritories;
        // }
    }
}