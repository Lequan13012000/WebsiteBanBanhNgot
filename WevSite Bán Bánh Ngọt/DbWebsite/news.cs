namespace DbWebsite
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string content { get; set; }

        [Required]
        [StringLength(100)]
        public string image { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? create_at { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] update_at { get; set; }
    }
}
