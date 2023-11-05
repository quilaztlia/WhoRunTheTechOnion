using Domain.Entities;

namespace Domain.Repository.Abstraction;

public interface ICommandeRepository
{
    Task<IEnumerable<Commande>> GetAllByClient(Guid idClient, CancellationToken cancellationToken=default);
    Task<Commande> Create(Commande commande, CancellationToken cancellationToken=default);
    Task<bool> Delte(Commande commande, CancellationToken cancellationToken=default);
}
