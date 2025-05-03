using System.Globalization;

namespace fintrip.src.Models {
    public record Expense {
        public int Id { get; set; }
        public decimal Nominal { get; set; }
        public DateTime Tanggal { get; set; }
        public string Waktu => Tanggal.ToString("hh:mm tt", CultureInfo.InvariantCulture);
        public string SiangSorePagi => Tanggal.Hour switch
        {
            >= 0 and < 12 => "Pagi",
            >= 12 and < 18 => "Siang",
            _ => "Sore"
        };
        public string? Catatan { get; set; }
        public bool Lunas { get; set; }
        public int? CategoryId { get; set; }
    }
}