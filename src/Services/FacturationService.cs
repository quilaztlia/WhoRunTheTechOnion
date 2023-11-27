using Contracts;
using Domain.Repository.Abstractions;
using Services.Abstractions;

namespace Services;

internal sealed class FacturationService
    : IFacturationService
{
    private IRepositoryManager _repopositoryManager;

    public FacturationService(IRepositoryManager repopositoryManager)
    {
        _repopositoryManager = repopositoryManager;
    }

    public Task<IEnumerable<FactureDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<FactureDto> GetByIdAsync(Guid factureId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
