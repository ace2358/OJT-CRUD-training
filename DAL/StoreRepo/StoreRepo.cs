using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.StoreRepo
{
    public class StoreRepo : IStoreRepo
    {
        private readonly PubsContext _context;

        public StoreRepo(PubsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task<Store> GetStore(string id)
        {
            return await _context.Stores.FindAsync(id);
        }

        public async Task<bool> UpdateStore(string id, Store store)
        {
            _context.Entry(store).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateStore(Store store)
        {
            _context.Stores.Add(store);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteStore(string id)
        {
            var store = await _context.Stores.FindAsync(id);
            if (store != null)
            {
                _context.Stores.Remove(store);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public bool StoreExists(string id)
        {
            return _context.Stores.Any(e => e.StorId == id);
        }
    }
}
