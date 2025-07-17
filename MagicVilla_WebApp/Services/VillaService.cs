
using System;
using MagicVilla_Utility;
using MagicVilla_WebApp.Model.Dto;
using MagicVilla_WebApp.Models;
using MagicVilla_WebApp.Services.IServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static MagicVilla_Utility.SD;


namespace MagicVilla_WebApp.Services
{
    public class VillaService : BaseServices, IVillaService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaurl;
        public VillaService(IHttpClientFactory clientFactory,IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaurl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }
        public Task<T> CreateAsync<T>(VillaCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            { 
                ApiType =SD.ApiType.POST,
                Data = dto,
                Url = villaurl+"/api/villaAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = villaurl + "/api/villaAPI/" + id
            });

        }
       
        public Task<T> GetAllAsync<T>()
        {
            var response= SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaurl + "/api/villaAPI"
            });
            return response;
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaurl + "/api/villaAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = villaurl + "/api/villaAPI/" +dto.Id
            });
        }
       

    }
}
