using System.ComponentModel.DataAnnotations.Schema;

namespace CelebiWebApi.Models
{
    public class UyeAidat
    {
        public int Id { get; set; }
        public int? UyeId { get; set; }
        public double? Borc { get; set; }
        public int? Tur { get; set; }
        [Column("createuserId")]
        public int? CreateUserId { get; set; }
        [Column("createdate")]
        public DateTime? CreateDate { get; set; }
        public int? Donem { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public double? Odenen { get; set; }
        public string? Aciklama { get; set; }
        public int? Yil { get; set; }
    }
}
