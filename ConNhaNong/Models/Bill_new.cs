namespace ConNhaNong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_new
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(2000)]
        public string list { get; set; }

        [StringLength(2000)]
        public string amount { get; set; }

        public double? total { get; set; }
        
        [StringLength(1000)]
        [Display(Name = "địa chỉ")]
        public string addresz { get; set; }
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Số Điện Thoại")]
        public string SDt { get; set; }
        [StringLength(50)]
        [Display(Name = "Người Nhận")]
        public string name_bill { get; set; }

        [Key]
        [StringLength(10)]
        public string ID_bill { get; set; }

        public virtual User User { get; set; }
    }
}
