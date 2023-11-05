using Domain.Repository.Abstractions;

namespace Persistance;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<ICommandeRepository> _lazyCommandeRepository;

    private readonly ICommandeRepository _commandeRepository;

    public RepositoryManager(DBContext dbContext)
    {
        _lazyCommandeRepository = new Lazy<ICommandeRepository>(() => new CommandeRepository(dbContext));
        _commandeRepository = new CommandeRepository(dbContext);
    }
}
