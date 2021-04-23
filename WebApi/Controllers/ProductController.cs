using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {
        #region Default Api Methodları
        // GET api/<controller>
        public ResponseModel<List<ProductModel>> Get()
        {
            var result = ProductData.Products;

            if (result != null && result.Count > 0)
            {
                return new ResponseModel<List<ProductModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = result
                };
            }
            else
            {
                return new ResponseModel<List<ProductModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.DataNotFound,
                    StatusCode = (int)StatusCodeEnum.DataNotFound,
                    Data = result
                };
            }
        }

        // GET api/<controller>/5
        public ResponseModel<ProductModel> Get(int id)
        {
            var result = ProductData.Products.FirstOrDefault(p => p.Id == id);

            if (result != null)
            {
                return new ResponseModel<ProductModel>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = result
                };
            }
            else
            {
                return new ResponseModel<ProductModel>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.DataNotFound,
                    StatusCode = (int)StatusCodeEnum.DataNotFound,
                    Data = result
                };
            }
        }

        // POST api/<controller>
        public ResponseModel<bool> Post([FromBody]ProductModel model)
        {
            bool result = true;
            string message = string.Empty;

            try
            {
                //throw new Exception("Keyfe keder hata fırlattık.");

                ProductData.Products.Add(model);
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
                    Data = result
                };
            }
        }

        // PUT api/<controller>/5
        public ResponseModel<bool> Put(int id, [FromBody]ProductModel model)
        {
            bool result = true;
            string message = string.Empty;

            try
            {
                ProductData.Products.RemoveAll(p => p.Id == id);
                ProductData.Products.Add(model);
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

        // DELETE api/<controller>/5
        public ResponseModel<bool> Delete(int id)
        {
            bool result = true;
            string message = string.Empty;

            try
            {
                ProductData.Products.RemoveAll(p => p.Id == id);
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
        [HttpPost]
        [Route("api/product/getbyusernamepassword")]
        public ResponseModel<List<ProductModel>> GetByUsernamePassword([FromBody]PersonelModel model)
        {
            var personel = PersonelData.Personels.FirstOrDefault(p => p.Username == model.Username && p.Password == model.Password);
            if (personel == null)
            {
                return new ResponseModel<List<ProductModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.LoginBasarisiz,
                    StatusCode = (int)StatusCodeEnum.LoginBasarisiz,
                    Data = null
                };
            }


            var result = ProductData.Products.Where(p => p.PersonelId == personel.Id).ToList();

            if (result != null && result.Count > 0)
            {
                return new ResponseModel<List<ProductModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.IslemBasarili,
                    StatusCode = (int)StatusCodeEnum.IslemBasarili,
                    Data = result
                };
            }
            else
            {
                return new ResponseModel<List<ProductModel>>
                {
                    IsSuccess = true,
                    Message = StatusCodeConstant.DataNotFound,
                    StatusCode = (int)StatusCodeEnum.DataNotFound,
                    Data = result
                };
            }
        }

        #endregion
    }
}
