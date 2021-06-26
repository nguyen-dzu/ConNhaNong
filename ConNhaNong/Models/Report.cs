namespace ConNhaNong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Report")]
    public partial class Report
    {
        public int id { get; set; }

        [StringLength(30)]
        public string id_product { get; set; }

        [StringLength(100)]
        [Display(Name ="Email người gửi")]
        public string Email_send { get; set; }

        [StringLength(1000)]
        [Display(Name ="Ghi chú")]
        [Required(ErrorMessage ="Ghi chú không được bỏ trống")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [StringLength(20)]
        public string Status_report { get; set; }

        public virtual products products { get; set; }
    }
}
