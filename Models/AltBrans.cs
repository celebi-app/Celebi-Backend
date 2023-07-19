using System;

namespace CelebiWebApi.Models
{
    public class AltBrans
    {
        public int Id { get; set; }
        public int? BransId { get; set; }
        public string? Ad { get; set; }
        public int? Pazartesi { get; set; }
        public int? Sali { get; set; }
        public int? Carsamba { get; set; }
        public int? Persembe { get; set; }
        public int? Cuma { get; set; }
        public int? Cumartesi { get; set; }
        public int? Pazar { get; set; }
        public double? Gunluk { get; set; }
        public double? Aylik { get; set; }
        public double? Ucaylik { get; set; }
        public double? Altiaylik { get; set; }
        public double? Yillik { get; set; }
        public double? AylikIndirimli { get; set; }
        public double? UcaylikIndirimli { get; set; }
        public double? AltiaylikIndirimli { get; set; }
        public double? YillikIndirimli { get; set; }
    }
}
