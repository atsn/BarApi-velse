namespace BarApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FredagsbarContext : DbContext
    {
        public FredagsbarContext()
            : base("name=FredagsbarContext")
        {
        }

        public virtual DbSet<Money> Money { get; set; }
        public virtual DbSet<Vare> Vare { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Money>()
                .Property(e => e.Place)
                .IsFixedLength();

            modelBuilder.Entity<Vare>()
                .Property(e => e.Varenavn)
                .IsFixedLength();
        }
    }
}
