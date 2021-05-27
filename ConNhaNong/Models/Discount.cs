namespace ConNhaNong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discount")]
    public partial class Discount
    {
        [StringLength(10)]
        public string ID { get; set; }

        public DateTime? Date_active { get; set; }

        public DateTime? Date_end { get; set; }

        [StringLength(500)]
        public string Name_discount { get; set; }

        [StringLength(2000)]
        public string Description_discount { get; set; }
    }
}
