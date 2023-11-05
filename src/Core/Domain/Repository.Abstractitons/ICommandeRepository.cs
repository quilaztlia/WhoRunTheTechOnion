using Domain.Entities;

namespace Domain.Repository.Abstractions;

public interface ICommandeRepository
{
    Task<IEnumerable<Commande>> GetAllByClient(Guid idClient, CancellationToken cancellationToken=default);
    Task<Commande> Create(Commande commande, CancellationToken cancellationToken=default);
    Task<bool> Delete(Commande commande, CancellationToken cancellationToken=default);
}
