using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConNhaNong.ViewModels
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Name_Product { get; set; }
        public int Amount { get; set; }
        public string Image { get; set; }
        public double? Total { get; set; }
    }
}