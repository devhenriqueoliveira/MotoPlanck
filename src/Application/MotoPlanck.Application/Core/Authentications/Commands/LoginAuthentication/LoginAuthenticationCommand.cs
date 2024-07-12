using MotoPlanck.Application.Abstractions.Messaging;
using MotoPlanck.Domain.Primitives.Result;

namespace MotoPlanck.Application.Core.Authentications.Commands.LoginAuthentication
{
    public sealed record LoginAuthenticationCommand(
        string Login,
        string Password) : ICommand<Result>;
}
