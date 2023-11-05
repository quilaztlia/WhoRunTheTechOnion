using Domain.Entities;
using Domain.Repository.Abstractions;

namespace Persistance;

internal sealed class CommandeRepository : ICommandeRepository 
{
    private readonly DBContext _dbContext;

    public CommandeRepository(DBContext dbContext)
    => _dbContext = dbContext;

    public Task<Commande> Create(Commande commande, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Commande commande, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Commande>> GetAllByClient(Guid idClient, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}