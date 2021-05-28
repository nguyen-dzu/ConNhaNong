namespace ConNhaNong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Bill_new = new HashSet<Bill_new>();
            Carts = new HashSet<Cart>();
        }

        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Địa chỉ Email không đúng định dạng")]
        [Required(ErrorMessage = "Địa chỉ Email không được bỏ trống")]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải nhiều hơn 6 kí tự")]
        [MaxLength(25, ErrorMessage = "Mật khẩu phải ít hơn 25 kí tự")]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Passwords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill_new> Bill_new { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
