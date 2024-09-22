using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.TitleService
{
    public interface ITitleService
    {
        Task<IEnumerable<TitleDTO>> GetTitles();
        Task<TitleDTO> GetTitle(string id);
        Task<bool> UpdateTitle(string id, TitleDTO titleDto);
        Task<bool> CreateTitle(TitleDTO titleDto);
        Task<bool> DeleteTitle(string id);
        bool TitleExists(string id);
    }
}