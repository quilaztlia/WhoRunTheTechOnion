using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public sealed class RepositoryDbContext : DbContext
{
    public RepositoryDbContext(DbContextOptions options)
    : base(options)
    { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Restaurant> Restaurants{get;set;}
        public DbSet<Plat> Plats{get;set;}
        public DbSet<Commande> Commandes { get; set; }
        //public DbSet<Factur> Factures{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
        }    
}
