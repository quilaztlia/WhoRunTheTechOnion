namespace Persistance;

public sealed class DbContext DbContext
{
    public DbContext(DbContextOptions options)
    : base(options)
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Restaurant> Restaurants{get;set;}
        public DbSet<Plat> Plats{get;set;}
        public DbSet<Commande> Commandes { get; set; }
        //public DbSet<Factur> Factures{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfigurationsFromAssemble(typeof(DbContext).Assembly)
        }
    }
}
