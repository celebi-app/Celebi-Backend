using CelebiWebApi.Data;
using CelebiWebApi.DTOs;
using CelebiWebApi.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CelebiWebApi.Services
{
    public interface IUyeService
    {
        Task<UyeInfo?> GetUyeInfo(int id);
        Task<IEnumerable<UyePaketDTO?>?> GetUyePaket(int id);
        Task<IEnumerable<UyeAidatDTO?>?> GetUyeTahsilat(int id);
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
                DogumTarihi = _user.DogumTarihi,
                AnneAdi = _user.AnneAd,
                BabaAdi = _user.BabaAd,
                AnneTelefon = _user.Tel1,
                BabaTelefon = _user.Tel2,
                Adres = _user.Adres,
                FotoUrl = _user.Foto,
                Brans = GetBransAd(_user.BransId),
                AltBrans = GetAltBransAd(_user.AltBransId),
                Antrenor = GetAntrenorAd(_user.AntrenorId),
                Kusak = GetKusakAd(_user.BransId, _user.kusakId),
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
                _result.Add(new UyePaketDTO
                {
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

        public async Task<IEnumerable<UyeAidatDTO?>?> GetUyeTahsilat(int id)
        {

            var _uyeAidatList = await _dbContext.UyeAidat.Where(u => u.UyeId == id).ToListAsync();
            if (!_uyeAidatList.Any()) return null;

            List<UyeAidatDTO?> _result = new List<UyeAidatDTO?>();

            _uyeAidatList.ForEach(u => {
                var _donemResult = (Yil: u.Yil, Donem: u.Donem);
                _result.Add(new UyeAidatDTO
                {
                    Borc = u.Borc,
                    Tur = u.Tur.TurConverter(),
                    Donem = _donemResult.DonemConverter(),
                    OdemeTarihi = u.OdemeTarihi,
                    Odenen = u.Odenen,
                    Aciklama = u.Aciklama,
                    Kalan = (u.Borc - u.Odenen)
                });
            });

            return _result;
        }

        private string? GetBransAd(int? bransId)
        {
            var brans = _dbContext.Brans.FirstOrDefault(b => b.Id == bransId);
            return brans?.Ad;
        }
        private string? GetKusakAd(int? bransId, int? kusakId)
        {
            var kusak = _dbContext.Kusak.Where(u => u.BransId == bransId).ToList().SingleOrDefault(u => u.Sira == kusakId);
            return kusak?.Ad;
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