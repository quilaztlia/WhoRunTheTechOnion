namespace Domain;

public interface ICommandeRepository
{
    Task<IEnumerable<Commande>> GetAllByClient(Guid idClient, CancellationToken cancellationToken=default);
    Task<Commande> Create(Commande commande, CancellationToken cancellationToken=default);
    Task<bool> Delte(Commande commande, CancellationToken cancellationToken=default);
}
