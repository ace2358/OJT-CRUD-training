using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TitleRepo
{
    public interface ITitleRepo
    {
        Task<IEnumerable<Title>> GetTitles();
        Task<Title> GetTitle(string id);
        Task<bool> UpdateTitle(string id, Title title);
        Task<bool> CreateTitle(Title title);
        Task<bool> DeleteTitle(string id);
        bool TitleExists(string id);
    }
}
