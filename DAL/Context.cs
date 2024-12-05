using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace DAL
{
    public class Context : DbContext
    {
        public Context() : base("Tidogsag") { }

        public DbSet<AfdelingDAL> Afdelinger { get; set; }
        public DbSet<MedarbejderDAL> Medarbejdere { get; set; }
        public DbSet<SagDAL> Sager { get; set; }
        public DbSet<TidsregistreringDAL> Tidsregistreringer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<MedarbejderDAL>()
               .HasMany(m => m.Tidsregistrering)
               .WithRequired(t => t.Medarbejder)
               .WillCascadeOnDelete(true);
        }
    }
}
