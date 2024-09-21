using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TitleRepo
{
    public class TitleRepo : ITitleRepo
    {
        private readonly PubsContext _context;

        public TitleRepo(PubsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Title>> GetTitles()
        {
            return await _context.Titles.ToListAsync();
        }

        public async Task<Title> GetTitle(string id)
        {
            return await _context.Titles.FindAsync(id);
        }

        public async Task<bool> UpdateTitle(string id, Title title)
        {
            _context.Entry(title).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateTitle(Title title)
        {
            _context.Titles.Add(title);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTitle(string id)
        {
            var title = await _context.Titles.FindAsync(id);
            if (title != null)
            {
                _context.Titles.Remove(title);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public bool TitleExists(string id)
        {
            return _context.Titles.Any(e => e.TitleId == id);
        }
    }
}
