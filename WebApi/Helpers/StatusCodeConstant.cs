using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Helpers
{
    public static class StatusCodeConstant
    {
        public const string IslemBasarili = "İşlem başarıyla tamamlandı";
        public const string LoginBasarisiz = "Login işlemi başarısız! Kullanıcı adı ya da şifre hatalı";
        public const string DataNotFound = "Kayıt bulunamadı!";
        public const string KayitEklerkenHataOlustu = "Insert aşamasında hata oluştu!";
        public const string KayitGuncellerkenHataOlustu = "Güncelleme aşamasında hata oluştu!";
        public const string KayitSilerkenkenHataOlustu = "Silme aşamasında hata oluştu!";
        public const string IdNoGiriniz = "Id Numarası boş geçilemez!";
        public const string DegerAraligindaGiriniz = "Minimum 1 Maksimum 1000 olarak değer girebilirsiniz!";
        public const string AdSoyadGiriniz = "Ad Soyad boş geçilemez!";
        public const string KarakterAraligindaGiriniz = "En az 5 en fazla 60 karakter girebilirsiniz!";
    }
}