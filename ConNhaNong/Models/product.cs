namespace ConNhaNong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class product
    {
        [StringLength(30)]

        public string ID { get; set; }

        [Display(Name ="Giá")]
        [DataType(DataType.Text)]
        public double? price { get; set; }

        [Display(Name = "Số lượng còn lại")]
        
        public int? amount { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string name_product { get; set; }

        [StringLength(2000)]
        public string file_names { get; set; }


        [StringLength(1000)]
        [Display(Name = "Mô tả sản phẩm")]
        [DataType(DataType.Text, ErrorMessage = "Địa chỉ Email không đúng định dạng")]
        [Required(ErrorMessage = "Mô tả không được bỏ trống")]
        public string Descriptions { get; set; }
    }
}
