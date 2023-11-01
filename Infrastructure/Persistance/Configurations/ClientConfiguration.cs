namespace Persistance;

//internal why ??
internal sealed class ClientConfiguration
: IEntityTypeConfiguration
{
    public void Configure(EntityTypeBuilder<Client> builder){
        builder.ToTable(nameof(Client));
        builder.HasKey(client => client.Id);
    }
}
