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
        Task<IEnumerable<Store>> GetStores();
        Task<Store> GetStore(string id);
        Task<bool> UpdateStore(string id, Store store);
        Task<bool> CreateStore(Store store);
        Task<bool> DeleteStore(string id);
        bool StoreExists(string id);
    }
}
