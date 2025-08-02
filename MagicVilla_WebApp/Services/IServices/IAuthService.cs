using MagicVilla_WebApp.Model.Dto;

namespace MagicVilla_WebApp.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LogInAsync<T>(LoginRequestDTO obj);
        Task<T> RegisterAsync<T>(RegistrationRequestDTO obj);
    }
}
