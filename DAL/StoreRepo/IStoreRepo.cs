using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.StoreRepo
{
    public interface IStoreRepo
    {
        Task<IEnumerable<Store>> GetStores();
        Task<Store> GetStore(string id);
        Task<bool> UpdateStore(string id, Store store);
        Task<bool> CreateStore(Store store);
        Task<bool> DeleteStore(string id);
        bool StoreExists(string id);
    }
}
