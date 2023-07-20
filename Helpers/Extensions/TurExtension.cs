using CelebiWebApi.Helpers.Enums;
using System.ComponentModel;
using System.Reflection;

namespace CelebiWebApi.Helpers.Extensions
{
    public static class TurExtension
    {
        private static readonly Dictionary<Tur, string> turMappings = new Dictionary<Tur, string>
    {
        { Tur.Peşin, "Peşin" },
        { Tur.Ziraat, "Ziraat Bankası" },
        { Tur.İşBankası, "İş Bankası" },
        { Tur.HalkBankası, "Halk Bankası" },
        { Tur.EFT, "EFT" }
    };

        public static string? TurConverter(this int? value)
        {
            if (value == null) return null;
            Tur tur = (Tur)value;
            return turMappings.TryGetValue(tur, out string? turWithSpaces) ? turWithSpaces : value.ToString();
        }
    }
}
