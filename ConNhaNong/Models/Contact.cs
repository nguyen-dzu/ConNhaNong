namespace ConNhaNong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage ="Email không được bỏ trống")]
        [Display(Name ="Địa chỉ Email")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Địa chỉ Email không hợp lệ")]
        public string Email { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Tên liên hệ không được bỏ trống")]
        [Display(Name = "Tên liên hệ ")]
        public string Name_contact { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [Display(Name = "Số điện thoại ")]
        [DataType(DataType.PhoneNumber)]
        public string NumberPhone { get; set; }

        [StringLength(20)]
        public string Status_contact { get; set; }
    }
}
