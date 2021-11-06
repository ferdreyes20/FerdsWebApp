using System.Collections.Generic;
using System.Linq;
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
        private List<TerritoryDto> _territoriesFromApi { get; set; }

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

            var territoriesData = JsonConvert.DeserializeObject<ReturnTerritoryDto>(result.ToString());
            _territoriesFromApi = territoriesData.Data;

            territoriesData.Data = _territoriesFromApi.Where(t => string.IsNullOrEmpty(t.Parent)).ToList();
            territoriesData.Data = ArrangeTerritories(territoriesData.Data);

            return territoriesData;
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

        private List<TerritoryDto> ArrangeTerritories(List<TerritoryDto> territories) 
        {
            foreach (var territory in territories)
            {
                var childTerritories = _territoriesFromApi.Where(ct => !string.IsNullOrEmpty(ct.Parent) && ct.Parent == territory.Id);
                if(childTerritories != null && childTerritories.Count() > 0)
                {
                    territory.territories = childTerritories.ToList();
                    ArrangeTerritories(territory.territories);
                }
            }
            
            return territories;
        }
    }
}