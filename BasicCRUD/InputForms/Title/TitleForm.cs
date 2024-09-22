namespace BasicCRUD.InputForms.Title
{
    public class TitleForm
    {
        public string TitleId { get; set; }

        public string Title1 { get; set; }

        public string Type { get; set; }

        public string? PubId { get; set; }

        public decimal? Price { get; set; }

        public decimal? Advance { get; set; }

        public int? Royalty { get; set; }

        public int? YtdSales { get; set; }

        public string? Notes { get; set; }

        public int PubYear { get; set; }

        public int PubMonth { get; set; }

        public int PubDay { get; set; }
    }
}
