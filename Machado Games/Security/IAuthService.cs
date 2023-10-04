using Machado_Games.Model;

namespace Machado_Games.Security
{
    public interface IAuthService
    {
        Task<UserLogin?> Autenticar(UserLogin userlogin);
    }
}