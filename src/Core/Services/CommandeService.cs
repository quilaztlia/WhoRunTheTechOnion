using Contracts;
using Domain.Repository.Abstractions;
using Services.Abstractions;

namespace Services;

internal sealed class CommandeService : ICommandeService
{
    private readonly IRepositoryManager _repositoryManager;
    
    public CommandeService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public Task<CommandeDto> CreateAsync(CommandeCreationDto commandeToCreate, CancellationToken cancellationToken=default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CommandeDto>> GetAllAsync(CancellationToken cancellationToken=default)
    {
        Console.WriteLine("GetAllAsync");
        return default;
    }

    public Task<CommandeDto> GetByIdAsync(Guid commandeId, CancellationToken cancellationToken=default)
    {
        throw new NotImplementedException();
    }
}