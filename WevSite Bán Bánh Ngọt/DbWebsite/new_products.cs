namespace DbWebsite
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class new_products
    {
        public int id { get; set; }

        [StringLength(100)]
        public string name_pr { get; set; }

        public int? id_type { get; set; }

        [StringLength(1000)]
        public string description_pr { get; set; }

        public double? unit_price { get; set; }

        public double? promotion_price { get; set; }

        [StringLength(255)]
        public string images { get; set; }

        [StringLength(255)]
        public string unit { get; set; }

        public byte? new_pr { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? updated_at { get; set; }
    }
}
