namespace BarApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Fredagsbarcontext : DbContext
    {
        public Fredagsbarcontext()
            : base("name=Fredagsbarcontext")
        {
            base.Configuration.ProxyCreationEnabled = false;
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
