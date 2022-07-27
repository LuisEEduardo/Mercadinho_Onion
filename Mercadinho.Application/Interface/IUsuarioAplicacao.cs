using Mercadinho.Application.ViewModel;
using System.Threading.Tasks;

namespace Mercadinho.Application.Interface
{
    public interface IUsuarioAplicacao
    {
        Task<UsuarioToken> RegistrarUsuario(UsuarioViewModel usuarioVM);
        Task<UsuarioToken> Login(UsuarioViewModel usuarioVM);
    }
}
