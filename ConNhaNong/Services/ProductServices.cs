using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConNhaNong.Services
{
    public static class ProductServices
    {
        public static Models.Model1 context = new Models.Model1();
        public static void AddProduct(string Name, int? Amout, double? Price,string Image)
        {
            string Id = Services.IDServices.RandomIDProduct(); 
            var product = context.products.Where(s => s.ID.Equals(Id)).FirstOrDefault();
            while (product != null)
            {
                Id = Services.IDServices.RandomIDUser();
            }
            Models.product products = new Models.product();
            products.ID = Id;
            products.name_product = Name;
            products.price = Price;
            products.amount = Amout;
            products.file_names = Image;
            context.products.Add(products);
            context.SaveChanges();
        }

    }
}