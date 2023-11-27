using Contracts;

namespace Services.Abstractions;

public interface ILoginService
{
    Task<IEnumerable<LoginDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<FactureDto> GetByIdAsync(Guid loginId, CancellationToken cancellationToken = default);
}
