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

        public double? price { get; set; }

        public int? amount { get; set; }

        [StringLength(100)]
        public string name_product { get; set; }

        [StringLength(2000)]
        public string file_names { get; set; }
    }
}
