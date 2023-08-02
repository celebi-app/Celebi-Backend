using CelebiWebApi.Helpers.Enums;

namespace CelebiWebApi.Helpers.Extensions
{
    public static class PaketExtension
    {
 
        private static readonly Dictionary<Paket, string> paketMappings = new Dictionary<Paket, string>
        {
            { Paket.Gunluk, "Günlük" },
            { Paket.Aylik1, "1 Aylık" },
            { Paket.Aylik3, "3 Aylık" },
            { Paket.Aylik6, "6 Aylık" },
            { Paket.Yillik, "Yıllık" }
        };

        public static string? PaketConverter(this int? value)
        {
            if (value == null) return null;
            Paket tur = (Paket)value;
            return paketMappings.TryGetValue(tur, out string? paketName) ? paketName : value.ToString();
        }
        
    }
}
