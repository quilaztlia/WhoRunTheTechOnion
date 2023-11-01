namespace Services;

internal sealed class CommandeService 
: ICommandeService
{
    private readonly ICommandeRepository _commandeRepository;
    
    public CommandeService(ICommandeRepository commandeRepository)
    {
        _commandeRepository = commandeRepository;
    }
}
