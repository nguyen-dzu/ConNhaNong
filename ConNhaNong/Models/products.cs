namespace ConNhaNong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public products()
        {
            Report = new HashSet<Report>();
        }

        [StringLength(30)]
        public string ID { get; set; }

        public double? price { get; set; }

        public int? amount { get; set; }

        [StringLength(100)]
        [Display(Name ="Tên sản phẩm")]
        public string name_product { get; set; }

        [StringLength(2000)]
        public string file_names { get; set; }

        [StringLength(1000)]
        public string Descriptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Report { get; set; }
    }
}
