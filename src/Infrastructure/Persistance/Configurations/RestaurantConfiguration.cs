using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration;

internal sealed class RestaurantConfiguration
: IEntityTypeConfiguration<Restaurant>
{
    // public void Configure(Entity){
    // }
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        throw new NotImplementedException();
    }
}
