using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
    public static class ProductData
    {
        public static List<ProductModel> Products = new List<ProductModel>
        {
            new ProductModel { Id = 1, Name = "Monitör", Price = 1000, PersonelId = 4 },
            new ProductModel { Id = 2, Name = "Mouse", Price = 100, PersonelId = 5 },
            new ProductModel { Id = 3, Name = "Laptop", Price = 15000, PersonelId = 6 },
            new ProductModel { Id = 4, Name = "Kulaklık", Price = 120, PersonelId = 4 },
            new ProductModel { Id = 5, Name = "Klavye", Price = 400, PersonelId = 4 },
        };
    }
}