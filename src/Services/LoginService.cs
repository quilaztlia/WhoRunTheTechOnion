using Domain.Repository.Abstractions;
using Services.Abstractions;

namespace Services;

 internal sealed class LoginService
: ILoginService
{
    private readonly ILoginRepository _loginRepository;

    public LoginService(ILoginRepository loginRepository)
    => _loginRepository = loginRepository;
}