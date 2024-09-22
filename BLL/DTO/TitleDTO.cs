using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TitleDTO
    {
        public string TitleId { get; set; } = null!;
        public string Title1 { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? PubId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public string? Notes { get; set; }
        public DateTime Pubdate { get; set; }
    }
}
