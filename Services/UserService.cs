using CelebiWebApi.Data;
using CelebiWebApi.DTOs;

namespace CelebiWebApi.Services
{
    public interface IUyeService
    {
        Task<UyeInfo?> GetUserInfo(int id);
    }

    public class UyeService : IUyeService
    {
        private readonly CelebiDbContext _dbContext;

        public UyeService(CelebiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UyeInfo?> GetUserInfo(int id)
        {
            var user = await _dbContext.Uye.FindAsync(id);
            if (user == null) return null;
         

            var userInfo = new UyeInfo
            {
                TC = user.TC,
                AdSoyad = user.Ad + " " + user.Soyad,
                AnneAdi = user.AnneAd,
                BabaAdi = user.BabaAd,
                AnneTelefon = user.Tel1,
                BabaTelefon = user.Tel2,
                FotoUrl = user.Foto,
                Brans = GetBransAd(user.BransId),
                AltBrans = GetAltBransAd(user.AltBransId),
                Antrenor = GetAntrenorAd(user.AntrenorId)
            };

            return userInfo;
        }

        private string? GetBransAd(int? bransId)
        {
            var brans = _dbContext.Brans.FirstOrDefault(b => b.Id == bransId);
            return brans?.Ad;
        }

        private string? GetAltBransAd(int? altBransId)
        {
            var altBrans = _dbContext.AltBrans.FirstOrDefault(ab => ab.Id == altBransId);
            return altBrans?.Ad;
        }

        private string? GetAntrenorAd(int? antrenorId)
        {
            var antrenor = _dbContext.Personel.FirstOrDefault(p => p.Id == antrenorId);
            string fullname = antrenor?.Ad + " " + antrenor?.Soyad;
            return fullname;
        }
    }
}
