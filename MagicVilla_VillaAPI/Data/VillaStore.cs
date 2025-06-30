using System.Security.Cryptography.X509Certificates;
using MagicVilla_VillaAPI.Model.Dto;

namespace MagicVilla_VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList= new List<VillaDTO>
            {
                new VillaDTO{Id=1, Name="Treasure"},
                new VillaDTO{Id=2, Name="Bliss"}

            };
    }
}
