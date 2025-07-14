using System.Linq.Expressions;
using MagicVilla_VillaAPI.Model;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IVillaRepository :IRepository<Villa>
    {

        Task <Villa> UpdateAsync(Villa entity);

    }
}
