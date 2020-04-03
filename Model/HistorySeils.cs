namespace SmartSorage.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HistorySeils
    {
        public int Id { get; set; }

        public int? IdGoods { get; set; }

        public int? IdCell { get; set; }

        public int? IdData { get; set; }

        public DateTime? DateIn { get; set; }

        public DateTime? DateOut { get; set; }

        [StringLength(20)]
        public string NameCompany { get; set; }

        public int? Number { get; set; }
    }
}
