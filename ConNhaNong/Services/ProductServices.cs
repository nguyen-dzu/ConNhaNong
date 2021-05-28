using ConNhaNong.Models;
using ConNhaNong.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConNhaNong.Services
{
    public static class ProductServices
    {
        public static Models.Model1 context = new Models.Model1();
        public static void AddProduct(string Name, int? Amout, double? Price,string Image,string Des)
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
            products.Descriptions = Des;
            context.products.Add(products);
            context.SaveChanges();
        }
        public static List<ProductViewModel> GetProductViewModel(User user)
        {
            var listView = new List<ProductViewModel>();
            var users = context.Users.Where(s => s.Email.Equals(user.Email)).FirstOrDefault();
            var listProduct = (context.Carts.Where(s => s.ID.Equals(users.ID)).Select(x => x.list)).FirstOrDefault();
            var listAmount = (context.Carts.Where(s => s.ID.Equals(users.ID)).Select(x => x.amount)).FirstOrDefault();
            if(listProduct ==null || listAmount ==null)
            {
                return listView;
            }
            if (!String.IsNullOrEmpty(listProduct.ToString()) && !String.IsNullOrEmpty(listAmount.ToString()))
            {
                var listP = listProduct.ToString().Split(',');
                var listA = listAmount.ToString().Split(',') ;
                int i = 0;
                foreach(var item in listP)
                {
                    var product = context.products.Where(s => s.ID.Equals(item)).FirstOrDefault();
                    if (product != null)
                    {
                        ProductViewModel productView = new ProductViewModel();
                        productView.Id = product.ID;
                        productView.Name_Product = product.name_product;
                        productView.Image = product.file_names;
                        productView.Total = product.price;
                        productView.Amount = int.Parse(listA[i]);
                        listView.Add(productView);
                        i++;
                    }
                    else
                    {
                        i++;
                        continue;
                    }
                }
                return listView;
            }
            else 
            { 
               return listView; 
            }
            

        }

    }
}