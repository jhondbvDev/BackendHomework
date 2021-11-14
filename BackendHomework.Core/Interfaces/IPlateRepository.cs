using BackendHomework.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendHomework.Core.Interfaces
{
    public interface  IPlateRepository: IRepository<Plate>
    {
        IQueryable<Plate> GetPublic(int pageNumber,int pageSize);
        Task<int> GetPublicCount();
        Task<int> GetPrivateCount(string userId);
        IQueryable<Plate> GetPlatesByUserId(string userId);
    }
}
