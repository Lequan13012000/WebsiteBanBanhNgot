namespace DbWebsite
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bill_detail
    {
        public int id { get; set; }

        public int id_bill { get; set; }

        public int id_product { get; set; }

        public int quantity { get; set; }

        public double unit_price { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] updated_at { get; set; }

        public virtual bill bill { get; set; }

        public virtual products product { get; set; }
    }
}
