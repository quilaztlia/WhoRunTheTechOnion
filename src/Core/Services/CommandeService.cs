using Contracts;
using Domain.Repository.Abstraction;
using Services.Abstractions;

namespace Services;

internal sealed class CommandeService 
: ICommandeService
{
    private readonly ICommandeRepository _commandeRepository;
    
    public CommandeService(ICommandeRepository commandeRepository)
    {
        _commandeRepository = commandeRepository;
    }

    public Task<CommandeDto> CreateAsync(CommandeCreationDto commandeToCreate, CancellationToken cancellationToken=default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CommandeDto>> GetAllAsync(CancellationToken cancellationToken=default)
    {
        throw new NotImplementedException();
    }

    public Task<CommandeDto> GetByIdAsync(Guid commandeId, CancellationToken cancellationToken=default)
    {
        throw new NotImplementedException();
    }
}