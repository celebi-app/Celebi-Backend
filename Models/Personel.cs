namespace CelebiWebApi.Models
{
    public class Personel
    {
        public int Id { get; set; }
        public string? KullaniciAd { get; set; }
        public string? Sifre { get; set; }
        public int? KullaniciTur { get; set; }
        public string? TC { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Cinsiyet { get; set; }
        public string? Telefon { get; set; }
        public int? BransId { get; set; }
        public string? Görev { get; set; }
        public double? Maas { get; set; }
        public DateTime? GirisTarihi { get; set; }
        public int? OdemeGunu { get; set; }
        public string? Durum { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUserId { get; set; }
        public double? YuzdelikOdeme { get; set; }
        public double? Bakiye { get; set; }
        public string? HesKodu { get; set; }
        public double? HesapBakiyesi { get; set; }
        public DateTime? MaasHesabaAktarimTarih { get; set; }

    }
}
