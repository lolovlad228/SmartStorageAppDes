namespace SmartSorage.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NowDataMap")]
    public partial class NowDataMap
    {
        public int Id { get; set; }

        public int? IdCell { get; set; }

        public int? IdGoods { get; set; }
    }
}
