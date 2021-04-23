using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Helpers
{
    public enum StatusCodeEnum : int
    {
        IslemBasarili = 200,
        LoginBasarisiz = 100,
        DataNotFound = 101,
        KayitEklerkenHataOlustu = 102,
        KayitGuncellerkenHataOlustu = 103,
        KayitSilerkenkenHataOlustu = 104,
        IdNoGiriniz=303,
        DegerAraligindaGiriniz=304,
        AdSoyadGiriniz=305,
        KarakterAraligindaGiriniz=306

    }
}