using BLL.DTO;
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

        public async Task<IEnumerable<StoreDTO>> GetStores()
        {
            var stores = await _storeRepo.GetStores();
            return stores.Select(store => new StoreDTO
            {
                StorId = store.StorId,
                StorName = store.StorName,
                StorAddress = store.StorAddress,
                City = store.City,
                State = store.State,
                Zip = store.Zip
            }).ToList();
        }

        public async Task<StoreDTO> GetStore(string id)
        {
            var store = await _storeRepo.GetStore(id);
            if (store == null) return null; // Handle not found case

            return new StoreDTO
            {
                StorId = store.StorId,
                StorName = store.StorName,
                StorAddress = store.StorAddress,
                City = store.City,
                State = store.State,
                Zip = store.Zip
            };
        }

        public async Task<bool> UpdateStore(string id, StoreDTO storeDto)
        {
            var existingStore = await _storeRepo.GetStore(id);
            if (existingStore == null)
            {
                return false;
            }
            existingStore.StorName = storeDto.StorName;
            existingStore.StorAddress = storeDto.StorAddress;
            existingStore.City = storeDto.City;
            existingStore.State = storeDto.State;
            existingStore.Zip = storeDto.Zip;

            return await _storeRepo.UpdateStore(id, existingStore);
        }

        public async Task<bool> CreateStore(StoreDTO storeDTO)
        {
            var store = new Store
            {
                StorId = storeDTO.StorId,
                StorName = storeDTO.StorName,
                StorAddress = storeDTO.StorAddress,
                City = storeDTO.City,
                State = storeDTO.State,
                Zip = storeDTO.Zip
            };
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
