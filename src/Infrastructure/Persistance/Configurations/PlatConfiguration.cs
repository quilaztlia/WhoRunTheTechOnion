using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration;

/*
 * 
 * 
 * internal sealed class PlatConfiguration
: IEntityTypeConfiguration<Plat>
{
    public void Configure(EntityTypeBuilder<Plat> builder){
        
        builder.ToTable(nameof(Plat));

        builder.HasKey(plat => plat.Id);
    }
}
*/