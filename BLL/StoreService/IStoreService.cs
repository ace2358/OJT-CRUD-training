using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.StoreService
{
    public interface IStoreService
    {
        Task<IEnumerable<StoreDTO>> GetStores();
        Task<StoreDTO> GetStore(string id);
        Task<bool> UpdateStore(string id, StoreDTO storeDto);
        Task<bool> CreateStore(StoreDTO storeDTO);
        Task<bool> DeleteStore(string id);
        bool StoreExists(string id);
    }
}
