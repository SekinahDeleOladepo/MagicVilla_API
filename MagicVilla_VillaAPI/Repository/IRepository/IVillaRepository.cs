using System.Linq.Expressions;
using MagicVilla_VillaAPI.Model.Dto;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAll(Expression<Func<Villa,bool>> filter = null);
        Task <Villa> Get(Expression<Func<Villa, bool>> filter = null,bool tracking =true);
        Task Create(Villa entity);
        Task Remove(Villa entity);
        Task Save();
    }
}
