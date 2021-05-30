namespace DbWebsite
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public products()
        {
            bill_detail = new HashSet<bill_detail>();
            images = "~/assets/image/product/add.png";
        }

        public int id { get; set; }

        [StringLength(20,ErrorMessage ="Vui lòng không nhập quá 20 kí tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string name_pr { get; set; }
    

        public int? id_type { get; set; }

        [StringLength(1000)]
        [Required(ErrorMessage = "Vui lòng nhập phần mô tả")]
        public string description_pr { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá gốc sản phẩm")]
        public double? unit_price { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá khuyến mãi sản phẩm")]
        public double? promotion_price { get; set; }

        [StringLength(255)]
        public string images { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Vui lòng nhập unit sản phẩm")]
        public string unit { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập new_pr sản phẩm")]
        public byte? new_pr { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? updated_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill_detail> bill_detail { get; set; }

        public virtual type_products type_products { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        [NotMapped]
        public List<products> CateCollection { get; set; }
    }
}
