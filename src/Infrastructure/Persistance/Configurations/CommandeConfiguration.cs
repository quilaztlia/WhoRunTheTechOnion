using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration;

internal sealed class CommandeConfiguration
: IEntityTypeConfiguration<Commande>
{
    public void Configure(EntityTypeBuilder<Commande> builder){
        builder.ToTable(nameof(Commande));
        builder.HasKey(commande => commande.Id);
    }
}
