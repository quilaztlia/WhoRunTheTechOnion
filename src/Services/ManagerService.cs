using Domain.Repository.Abstractions;
using Services.Abstractions;

namespace Services;

public sealed class ManagerService
    : IServiceManager
{
    private readonly Lazy<ICommandeService> _lazyCommandeService;

    private readonly ICommandeService _commandeService;
    private readonly IFacturationService _facturationService;
    //private readonly ILoginService _loginService;

    public ICommandeService CommandeService
        => _commandeService;

    //public IFacturationService FacturationService
    //    => _facturationService;

    //public ILoginService LoginService
    //    => _loginService;

    public ManagerService(IRepositoryManager repopositoryManager)
    {
        _commandeService = new CommandeService(repopositoryManager);
        //_facturationService = new FacturationService(repopositoryManager);
        //_loginService = new LoginService(repopositoryManager);

        _lazyCommandeService = new Lazy<ICommandeService>(() => new CommandeService(repopositoryManager));
    }
}
