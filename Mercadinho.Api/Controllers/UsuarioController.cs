using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mercadinho.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _app;

        public UsuarioController(IUsuarioAplicacao app)
        {
            _app = app;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioToken>> Login([FromBody] LoginViewModel usuarioVM)
        {
            var result = await _app.Login(usuarioVM);

            if (result is null)
                return BadRequest("Usuário ou senha incorretos");

            return Ok(result);
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<string>> RegistrarUsuario([FromBody] UsuarioViewModel usuarioVM)
        {
            var result = await _app.RegistrarUsuario(usuarioVM);

            if (result != "Usuário registrado")
                return BadRequest(result);

            return Ok(result);
        }

    }
}
