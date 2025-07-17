using MagicVilla_WebApp.Model;
using MagicVilla_WebApp.Models;

namespace MagicVilla_WebApp.Services.IServices
{
    public interface IBaseServices
    {
        APIResponse ResponseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
