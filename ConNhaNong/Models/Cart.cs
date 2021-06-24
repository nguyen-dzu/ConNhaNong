namespace ConNhaNong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(2000)]
        public string list { get; set; }

        [StringLength(2000)]
        public string amount { get; set; }

        [Key]
        [StringLength(10)]
        public string ID_cart { get; set; }

        public virtual Users Users { get; set; }
    }
}
