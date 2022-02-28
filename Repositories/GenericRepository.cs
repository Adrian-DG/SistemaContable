using API.Interfaces;
using API.DTO;
using API.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private APIContext _context;
        private DbSet<T> _repo;
        public GenericRepository(APIContext context)
        {
            _context = context;
            _repo = _context.Set<T>();
        }

        public async Task CreateAsync(T model)
        {
           await _repo.AddAsync(model);
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _repo.FindAsync(id);
            _repo.Remove(entity);
        }

        public PagedDataDTO<T> GetAllAsync(PaginationFilterDTO<T> filters)
        {
            var query = $"SELECT * FROM  {filters.TableName}";
            var paginationQuery = $"ORDER BY FechaCreacion DESC OFFSET {filters.Cantidad} ROWS FETCH NEXT {filters.Pagina} ROWS ONLY";
            query += paginationQuery; 
            
            if(filters.Termino != null)
            {
                query = $"{query} where {filters.FilterProp} = {filters.Termino} {paginationQuery}";
            }            
            
            var result = _repo.FromSqlRaw(query);

            var pagedData = (PagedDataDTO<T>) filters;
            pagedData.Records = result;

            return pagedData;
            
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _repo.FindAsync(id); 
        }

        public void UpdateAsync(T entity)
        {
            _context.Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}