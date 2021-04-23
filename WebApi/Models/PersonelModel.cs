using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class PersonelModel
    {
        [Required(ErrorMessage = Helpers.StatusCodeConstant.IdNoGiriniz)]
        [Range(1, 1000, ErrorMessage =Helpers.StatusCodeConstant.DegerAraligindaGiriniz)]
        public int Id { get; set; }

        [Required(ErrorMessage = Helpers.StatusCodeConstant.AdSoyadGiriniz)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = Helpers.StatusCodeConstant.KarakterAraligindaGiriniz)]
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}