namespace SmartSorage.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<HistorySeils> HistorySeils { get; set; }
        public virtual DbSet<MapStorage> MapStorage { get; set; }
        public virtual DbSet<NowDataMap> NowDataMap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
