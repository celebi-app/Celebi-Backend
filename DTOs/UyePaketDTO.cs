namespace CelebiWebApi.DTOs
{
    public class UyePaketDTO
    {
        public int? Paket { get; set; }
        public double? Tutar { get; set; }
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public DateTime? IzinBaslangicTarihi { get; set; }
        public DateTime? IzinBitisTarihi { get; set; }
        public string? OlusturanKullanici { get; set; }
    }
}
