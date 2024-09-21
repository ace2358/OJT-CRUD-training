using DAL.Entities;
using DAL.TitleRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.TitleService
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepo _titleRepo;

        public TitleService(ITitleRepo titleRepo)
        {
            _titleRepo = titleRepo;
        }

        public async Task<IEnumerable<Title>> GetTitles()
        {
            return await _titleRepo.GetTitles();
        }

        public async Task<Title> GetTitle(string id)
        {
            return await _titleRepo.GetTitle(id);
        }

        public async Task<bool> UpdateTitle(string id, Title title)
        {
            return await _titleRepo.UpdateTitle(id, title);
        }

        public async Task<bool> CreateTitle(Title title)
        {
            return await _titleRepo.CreateTitle(title);
        }

        public async Task<bool> DeleteTitle(string id)
        {
            return await _titleRepo.DeleteTitle(id);
        }

        public bool TitleExists(string id)
        {
            return _titleRepo.TitleExists(id);
        }
    }
}