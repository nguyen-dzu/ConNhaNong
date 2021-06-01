using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConNhaNong.ViewModels
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Name_Product { get; set; }
        [Range(1,100,ErrorMessage ="Số lượng phải lớn hơn 1 và nhỏ hơm 100")]
        public int Amount { get; set; }
        public string Image { get; set; }
        public double? Total { get; set; }
    }
}