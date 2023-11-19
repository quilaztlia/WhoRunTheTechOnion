using Contracts;

namespace Services.Abstractions;

public interface ICommandeService
{   
    Task<CommandeDto> CreateAsync(CommandeCreationDto commandeToCreate, CancellationToken cancellationToken = default);
    Task<IEnumerable<CommandeDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CommandeDto> GetByIdAsync(Guid commandeId, CancellationToken cancellationToken=default);    
}