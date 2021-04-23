using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Attribute;
using WebApi.Data;
using WebApi.Helpers;
using WebApi.Models;


namespace WebApi.Controllers
{
    public class PersonelController : ApiController
    {
        #region Default Api Methodları
        // GET: api/Personel
        public ResponseModel<List<PersonelModel>> Get()
        {
            var personelList = PersonelData.Personels;

            if (personelList != null && personelList.Count > 0)
            {
                return new ResponseModel<List<PersonelModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = personelList
                };
            }

            else
            {
                return new ResponseModel<List<PersonelModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.DataNotFound,
                    StatusCode = (int)StatusCodeEnum.DataNotFound,
                    Data = personelList
                };
            }
        }


        // GET: api/Personel/5
        public ResponseModel<PersonelModel> Get(int id)
        {
            var personel = PersonelData.Personels.FirstOrDefault(p => p.Id == id);

            if (personel != null)
            {
                return new ResponseModel<PersonelModel>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = personel
                };
            }
            else
            {
                return new ResponseModel<PersonelModel>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.DataNotFound,
                    StatusCode = (int)StatusCodeEnum.DataNotFound,
                    Data = personel
                };
            }
        }

        // POST: api/Personel
        [Validate]
        public ResponseModel<bool> Post([FromBody]PersonelModel model)
        {
            bool result = true;
            string message = string.Empty;
          
            try
            {

                //throw new Exception("Keyfe keder hata fırlattık");
                PersonelData.Personels.Add(model);
            }
            catch (Exception ex)
            {
                result = false;
                message = ex.Message;
            }

            if (result)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = result
                };
            }
            else
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.KayitEklerkenHataOlustu + " Hata Detayı: " + message,
                    StatusCode = (int)StatusCodeEnum.KayitEklerkenHataOlustu,
                    Data = false
                };
            }

        }

        // PUT: api/Personel/5
        public ResponseModel<bool> Put(int id, [FromBody]PersonelModel model)
        {
            bool result = true;
            string message = string.Empty;

            try
            {
                PersonelData.Personels.RemoveAll(p => p.Id == id);
                PersonelData.Personels.Add(model);
            }
            catch (Exception ex)
            {
                result = false;
                message = ex.Message;
            }

            if (result)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = result
                };
            }
            else
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.KayitGuncellerkenHataOlustu + " Hata Detayı: " + message,
                    StatusCode = (int)StatusCodeEnum.KayitGuncellerkenHataOlustu,
                    Data = result
                };
            }
        }

        // DELETE: api/Personel/5
        public ResponseModel<bool> Delete(int id)
        {
            bool result = true;
            string message = string.Empty;

            try
            {
                //throw new Exception("Keyfe Keder Hata Fırlatıldı");
                PersonelData.Personels.RemoveAll(p => p.Id == id);
            }
            catch (Exception ex)
            {
                result = false;
                message = ex.Message;
            }

            if (result)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = result
                };
            }
            else
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.KayitSilerkenkenHataOlustu + " Hata Detayı: " + message,
                    StatusCode = (int)StatusCodeEnum.KayitSilerkenkenHataOlustu,
                    Data = result
                };
            }
        }
        #endregion

        #region Yeni Eklenen Methodlar
        //Yukarıda Get adında bir method tanımlamıştık burada parametrenin tipini değiştirerek (string namesurname) ikinci kez yazdık.

        public ResponseModel<List<PersonelModel>> Get(string nameSurname)
        {
            var result = PersonelData.Personels.Where(p => p.NameSurname.Contains(nameSurname)).ToList();

            if (result != null && result.Count > 0)
            {
                return new ResponseModel<List<PersonelModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = result
                };
            }
            else
            {
                return new ResponseModel<List<PersonelModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.DataNotFound,
                    StatusCode = (int)StatusCodeEnum.DataNotFound,
                    Data = result
                };
            }
        }

        [HttpPost]
        [Route("api/personel/Login")]
        public ResponseModel<bool> Login([FromBody]PersonelModel model)
        {
            var result = PersonelData.Personels.Any(p => p.Username == model.Username && p.Password == model.Password);

            if (result)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = result
                };
            }
            else
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.LoginBasarisiz,
                    StatusCode = (int)StatusCodeEnum.LoginBasarisiz,
                    Data = result
                };
            }
        }

        [Route("api/personel/GetByTitle/{title}")]
        public ResponseModel<List<PersonelModel>> GetByTitle(string title)
        {
            var result = PersonelData.Personels.Where(p => p.Title.Contains(title)).ToList();

            if (result != null && result.Count > 0)
            {
                return new ResponseModel<List<PersonelModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = result
                };
            }
            else
            {
                return new ResponseModel<List<PersonelModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.DataNotFound,
                    StatusCode = (int)StatusCodeEnum.DataNotFound,
                    Data = result
                };
            }
        }
        #endregion

        [Route("api/personel/GetByTitle2/{title}")]
        public ResponseModel<List<PersonelModel>> GetByTitle2(string title)
        {
            var result = PersonelData.Personels.Where(p => p.Title.Contains(title)).ToList();

            if (result != null && result.Count > 0)
            {
                return new ResponseModel<List<PersonelModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = result
                };
            }
            else
            {
                return new ResponseModel<List<PersonelModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.DataNotFound,
                    StatusCode = (int)StatusCodeEnum.DataNotFound,
                    Data = result
                };
            }
        }

        [Route("api/personel/GetByTitle4/{title}")]
        public ResponseModel<List<PersonelModel>> GetByTitle4(string title)
        {
            var result = PersonelData.Personels.Where(p => p.Title.Contains(title)).ToList();

            if (result != null && result.Count > 0)
            {
                return new ResponseModel<List<PersonelModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = result
                };
            }
            else
            {
                return new ResponseModel<List<PersonelModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.DataNotFound,
                    StatusCode = (int)StatusCodeEnum.DataNotFound,
                    Data = result
                };
            }
        





    }
}
