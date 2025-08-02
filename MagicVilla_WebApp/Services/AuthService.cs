using MagicVilla_Utility;
using MagicVilla_WebApp.Model.Dto;
using MagicVilla_WebApp.Models;
using MagicVilla_WebApp.Services.IServices;

namespace MagicVilla_WebApp.Services
{
    public class AuthService : BaseServices, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaurl;
        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaurl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> LogInAsync<T>(LoginRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data =obj,
                Url = villaurl + "/api/UsersAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegistrationRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = villaurl + "/api/UsersAuth/register"
            });
        }
    }
}
