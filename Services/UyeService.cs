using CelebiWebApi.Data;
using CelebiWebApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CelebiWebApi.Services
{
    public interface IUyeService
    {
        Task<UyeInfo?> GetUyeInfo(int id);
        Task<IEnumerable<UyePaketDTO?>?> GetUyePaket(int id);
    }

    public class UyeService : IUyeService
    {
        private readonly CelebiDbContext _dbContext;

        public UyeService(CelebiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UyeInfo?> GetUyeInfo(int id)
        {
            var _user = await _dbContext.Uye.FindAsync(id);
            if (_user == null) return null;
         

            var _userInfo = new UyeInfo
            {
                TC = _user.TC,
                AdSoyad = _user.Ad + " " + _user.Soyad,
                AnneAdi = _user.AnneAd,
                BabaAdi = _user.BabaAd,
                AnneTelefon = _user.Tel1,
                BabaTelefon = _user.Tel2,
                FotoUrl = _user.Foto,
                Brans = GetBransAd(_user.BransId),
                AltBrans = GetAltBransAd(_user.AltBransId),
                Antrenor = GetAntrenorAd(_user.AntrenorId),
                Kusak = _user.kusakId.ToString(),
                KayitTarihi = _user.KayitTarihi,
                Durum = _user.Durum.ToString(),
                LisansNo = _user.LisansNo,
                LisansYili = _user.LisansYil,
                AidatTutari = _user.aidat
            };

            return _userInfo;
        }

        public async Task<IEnumerable<UyePaketDTO?>?> GetUyePaket(int id)
        {

            var _uyePaketler = await _dbContext.UyePaket.Where(u => u.UyeId == id).ToListAsync();
            if (!_uyePaketler.Any()) return null;

            List<UyePaketDTO?> _result = new List<UyePaketDTO?>();

            _uyePaketler.ForEach(u => {
                _result.Add(new UyePaketDTO {
                    UyeId = u.UyeId,
                    Paket = u.Paket,
                    Tutar = u.Tutar,
                    BaslangicTarihi = u.BasTarih,
                    BitisTarihi = u.BitTarih,
                    IzinBaslangicTarihi = u.izinBasTarih,
                    IzinBitisTarihi = u.izinBitTarih,
                    OlusturanKullanici = GetAntrenorAd(u.CreateUserId)
                });
            });

            return _result;

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
