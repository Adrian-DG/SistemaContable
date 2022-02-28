using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;

namespace API.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        PagedDataDTO<T> GetAllAsync(PaginationFilterDTO<T> filters);
        Task<T> GetByIdAsync(object id);
        Task CreateAsync(T model);
        void UpdateAsync(T entity);
        Task DeleteAsync(object id);

    }
}