using API.Interfaces;
using API.DTO;
using System.Threading.Tasks;

namespace API.Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private APIContext _context;
        private ServerResponseDTO _reponse;
        public UnitOfWork(APIContext context, ServerResponseDTO responseDTO)
        {
            _context = context;
            _reponse = responseDTO;
        }

        public IGenericRepository<T> GenericRepository { get; }
        public IAuthRepository AuthRepository { get; }

        public async Task<ServerResponseDTO> CommitChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0) 
            ? _reponse.GetOkResponse()
            : _reponse.GetBadResponse();
        }
    }
}