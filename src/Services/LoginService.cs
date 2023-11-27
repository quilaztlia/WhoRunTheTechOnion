using Contracts;
using Domain.Repository.Abstractions;
using Services.Abstractions;

namespace Services;

 internal sealed class LoginService
: ILoginService
{
    private readonly IRepositoryManager _repopositoryManager;

    public LoginService(IRepositoryManager repopositoryManager)
    => _repopositoryManager = repopositoryManager;

    public Task<IEnumerable<LoginDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<FactureDto> GetByIdAsync(Guid loguinId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}