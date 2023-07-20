using CelebiWebApi.Helpers.Enums;

namespace CelebiWebApi.Helpers.Extensions
{
    public static class DonemExtension
    {
        public static string? DonemConverter(this (int? yil, int? donem) dbResult)
        {
            if (dbResult.yil == null || dbResult.donem == null) return null;
            Month month = (Month)dbResult.donem;
            return $"{dbResult.yil}" + " " + month.ToString();
        }
    }
}
