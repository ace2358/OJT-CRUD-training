using DAL.Entities;
using DAL.StoreRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.StoreService
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepo _storeRepo;

        public StoreService(IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            return await _storeRepo.GetStores();
        }

        public async Task<Store> GetStore(string id)
        {
            return await _storeRepo.GetStore(id);
        }

        public async Task<bool> UpdateStore(string id, Store store)
        {
            return await _storeRepo.UpdateStore(id, store);
        }

        public async Task<bool> CreateStore(Store store)
        {
            return await _storeRepo.CreateStore(store);
        }

        public async Task<bool> DeleteStore(string id)
        {
            return await _storeRepo.DeleteStore(id);
        }

        public bool StoreExists(string id)
        {
            return _storeRepo.StoreExists(id);
        }
    }
}
