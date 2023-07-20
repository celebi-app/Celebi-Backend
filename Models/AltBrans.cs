using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebiWebApi.Models
{
    public class AltBrans
    {
        [Column("Id")]
        public int Id { get; set; }
        
        [Column("BransId")]
        public int? BransId { get; set; }

        [Column("ad")]
        public string? Ad { get; set; }

        [Column("pazartesi")]
        public int? Pazartesi { get; set; }

        [Column("sali")]
        public int? Sali { get; set; }

        [Column("carsamba")]
        public int? Carsamba { get; set; }

        [Column("persembe")]
        public int? Persembe { get; set; }

        [Column("cuma")]
        public int? Cuma { get; set; }

        [Column("cumartesi")]
        public int? Cumartesi { get; set; }

        [Column("pazar")]
        public int? Pazar { get; set; }

        [Column("gunluk")]
        public double? Gunluk { get; set; }

        [Column("aylik")]
        public double? Aylik { get; set; }

        [Column("ucaylik")]
        public double? Ucaylik { get; set; }

        [Column("altiaylik")]
        public double? Altiaylik { get; set; }

        [Column("yillik")]
        public double? Yillik { get; set; }

        [Column("aylikindirimli")]
        public double? AylikIndirimli { get; set; }

        [Column("ucaylikindirimli")]
        public double? UcaylikIndirimli { get; set; }

        [Column("altiaylikindirimli")]
        public double? AltiaylikIndirimli { get; set; }

        [Column("yillikindirimli")]
        public double? YillikIndirimli { get; set; }
    }
}
