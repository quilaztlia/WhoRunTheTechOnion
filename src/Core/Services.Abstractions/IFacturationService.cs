using Contracts;

namespace Services.Abstractions;

public interface IFacturationService
{
    Task<IEnumerable<FactureDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<FactureDto> GetByIdAsync(Guid factureId, CancellationToken cancellationToken = default);
}
