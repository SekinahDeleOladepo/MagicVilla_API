using static MagicVilla_Utility.SD;

namespace MagicVilla_WebApp.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public String Url { get; set; }
        public object Data { get; set; }
    }
}
