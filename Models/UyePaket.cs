namespace CelebiWebApi.Models
{
    public class UyePaket
    {
        public int Id { get; set; }
        public int? UyeId { get; set; }
        public int? Paket { get; set; }
        public double? Tutar { get; set; }
        public DateTime? BasTarih { get; set; }
        public DateTime? BitTarih { get; set; }
        public DateTime? izinBasTarih { get; set; }
        public DateTime? izinBitTarih { get; set; }
        public int? indirimli { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
