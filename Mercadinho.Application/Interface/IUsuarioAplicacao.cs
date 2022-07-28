using Mercadinho.Application.ViewModel;
using System.Threading.Tasks;

namespace Mercadinho.Application.Interface
{
    public interface IUsuarioAplicacao
    {
        Task<string> RegistrarUsuario(UsuarioViewModel usuarioVM);
        Task<UsuarioToken> Login(LoginViewModel usuarioVM);
    }
}
