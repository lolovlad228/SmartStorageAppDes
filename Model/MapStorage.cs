namespace SmartSorage.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MapStorage")]
    public partial class MapStorage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(1)]
        public string District { get; set; }

        public int? Shell { get; set; }

        public int? Row { get; set; }

        public int? Floor { get; set; }

        public int? FullCell { get; set; }
    }
}
