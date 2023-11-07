using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

/* 
 dotnet ef migrations add init --verbose --project Persistance --startup-project Web
dotnet ef database update
 
 */
public sealed class DBContext : DbContext
{
    public DBContext(DbContextOptions options)
    : base(options)
    { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Restaurant> Restaurants{get;set;}
        public DbSet<Plat> Plats{get;set;}
        public DbSet<Commande> Commandes { get; set; }
        //public DbSet<Factur> Factures{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DBContext).Assembly);
        }    

        //protected override void OnConfiguring(DbContextOptionsBuilder options){
        //    options.UseSqlServer(@"Server=(localdb\mssqlllocaldb;Database=Commandes;Trusted_Connection=True;")
        //    .LogTo(Console.WriteLine
        //    //, LogLevel.Information
        //    );
        //}
}
