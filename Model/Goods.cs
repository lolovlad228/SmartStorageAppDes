namespace SmartSorage.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Goods
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Prise { get; set; }

        [Column(TypeName = "image")]
        public byte[] Img { get; set; }

        [Column(TypeName = "image")]
        public byte[] QrImg { get; set; }

        public DateTime? DateReg { get; set; }

        [StringLength(10)]
        public string Seassons { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }
    }
}
