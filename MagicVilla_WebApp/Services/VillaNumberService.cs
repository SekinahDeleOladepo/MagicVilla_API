using MagicVilla_Utility;
using MagicVilla_WebApp.Model.Dto;
using MagicVilla_WebApp.Models;
using MagicVilla_WebApp.Services.IServices;
using Newtonsoft.Json.Linq;

namespace MagicVilla_WebApp.Services
{
    public class VillaNumberService : BaseServices, IVillaNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaurl;
        public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaurl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }
        public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = villaurl + "/api/villaAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = villaurl + "/api/villaAPI/" + id,
                Token = token
            });

        }

        public Task<T> GetAllAsync<T>(string token)
        {
            var response = SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaurl + "/api/villaAPI",
                Token = token
            });
            return response;
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaurl + "/api/villaAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = villaurl + "/api/villaAPI/" + dto.VillaNo,
                Token = token
            });
        }

       
    }
}
