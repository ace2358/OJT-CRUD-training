using BLL.DTO;
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

        public async Task<IEnumerable<TitleDTO>> GetTitles()
        {
            var titles = await _titleRepo.GetTitles();
            return titles.Select(title => new TitleDTO
            {
                TitleId = title.TitleId,
                Title1 = title.Title1,
                Type = title.Type,
                PubId = title.PubId,
                Price = title.Price,
                Advance = title.Advance,
                Royalty = title.Royalty,
                YtdSales = title.YtdSales,
                Notes = title.Notes,
                Pubdate = title.Pubdate
            }).ToList();
        }

        public async Task<TitleDTO> GetTitle(string id)
        {
            var title = await _titleRepo.GetTitle(id); // Fetch the title from the repository
            if (title == null)
            {
                return null; // Handle the case where the title doesn't exist
            }

            return new TitleDTO
            {
                TitleId = title.TitleId,
                Title1 = title.Title1,
                Type = title.Type,
                PubId = title.PubId,
                Price = title.Price,
                Advance = title.Advance,
                Royalty = title.Royalty,
                YtdSales = title.YtdSales,
                Notes = title.Notes,
                Pubdate = title.Pubdate
            };
        }

        public async Task<bool> CreateTitle(TitleDTO titleDto)
        {
            var title = new Title
            {
                TitleId = titleDto.TitleId,
                Title1 = titleDto.Title1,
                Type = titleDto.Type,
                PubId = titleDto.PubId,
                Price = titleDto.Price,
                Advance = titleDto.Advance,
                Royalty = titleDto.Royalty,
                YtdSales = titleDto.YtdSales,
                Notes = titleDto.Notes,
                Pubdate = titleDto.Pubdate
            };

            return await _titleRepo.CreateTitle(title);
        }

        public async Task<bool> UpdateTitle(string id, TitleDTO titleDto)
        {
            var existingTitle = await _titleRepo.GetTitle(id);
            if (existingTitle == null)
            {
                return false;
            }

            existingTitle.Title1 = titleDto.Title1;
            existingTitle.Type = titleDto.Type;
            existingTitle.PubId = titleDto.PubId;
            existingTitle.Price = titleDto.Price;
            existingTitle.Advance = titleDto.Advance;
            existingTitle.Royalty = titleDto.Royalty;
            existingTitle.YtdSales = titleDto.YtdSales;
            existingTitle.Notes = titleDto.Notes;
            existingTitle.Pubdate = titleDto.Pubdate;

            return await _titleRepo.UpdateTitle(id, existingTitle);
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