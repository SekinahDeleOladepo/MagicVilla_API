using MagicVilla_WebApp.Models.Dto;

namespace MagicVilla_WebApp.Model.Dto
{
    public class LoginResponseDTO
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }
        
    }
}
