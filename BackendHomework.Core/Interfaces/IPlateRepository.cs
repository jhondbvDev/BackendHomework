using BackendHomework.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BackendHomework.Core.Interfaces
{
    public interface  IPlateRepository: IRepository<Plate>
    {
        IQueryable<Plate> GetPublicPlates(int pageNumber,int pageSize);
        Task<int> GetPublicCount();
        Task<int> GetPrivateCount(string userId);
        IQueryable<Plate> GetPlatesByUserId(int pageNumber, int pageSize, string userId);
    }
}
