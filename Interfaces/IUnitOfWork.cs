using API.DTO;
using System;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        Task<ServerResponseDTO> CommitChangesAsync();
        IGenericRepository<T> GenericRepository { get; }
        IAuthRepository AuthRepository { get; }
    }
}