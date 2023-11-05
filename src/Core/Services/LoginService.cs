using Domain.Repository.Abstraction;
using Services.Abstractions;

namespace Services;

//pq internal
internal sealed class LoginService
: ILoginService
{
    private readonly IClientRepository _clientRepository;

    public LoginService(IClientRepository clientRepository)
    => _clientRepository = clientRepository;

}
