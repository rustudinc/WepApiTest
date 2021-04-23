using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
    public static class PersonelData
    {
        public static List<PersonelModel> Personels = new List<PersonelModel>
        {
            new PersonelModel { Id = 1, NameSurname = "Bahadır Soğucaklı", Title = "Dba", Username = "bhadir.sogucakli", Password = "1234" },
            new PersonelModel { Id = 2, NameSurname = "İlker Topal", Title = "Yazılım Uzmanı", Username="ilker.topal", Password = "4321" },
            new PersonelModel { Id = 3, NameSurname = "Utku Koçlar", Title = "Öğrenci", Username="utku.koclar", Password = "qqqq" },
            new PersonelModel { Id = 4, NameSurname = "Rüştü Dinç", Title = "İş Analisti", Username="rustu.dinc", Password = "4444" },
            new PersonelModel { Id = 5, NameSurname = "Fatih Taylan", Title = "Yazılım Uzmanı", Username="fatih.taylan", Password = "5555" },
            new PersonelModel { Id = 6, NameSurname = "Şerif Kocagöz", Title = "Araştırma Görevlisi", Username="serif.kocagoz", Password = "6666" },
        };
    }
}