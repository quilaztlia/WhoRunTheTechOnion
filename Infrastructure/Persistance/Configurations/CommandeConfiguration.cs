namespace Persistance;

internal sealed class CommandeConfiguration
: IEntityTypeConfiguration
{
    public void Configure(EntityTypeBuilder<Commande> builder){
        builder.ToTable(nameof(Commande));
        builder.HasKey(commande => commande.Id);
    }
}
