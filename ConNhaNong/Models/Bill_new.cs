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
        public string addresz { get; set; }

        [StringLength(20)]
        public string SDt { get; set; }

        [StringLength(50)]
        public string name_bill { get; set; }

        [Key]
        [StringLength(10)]
        public string ID_bill { get; set; }

        public virtual Users Users { get; set; }
    }
}
