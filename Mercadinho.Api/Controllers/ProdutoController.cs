using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Mercadinho.Api.Controllers
{

    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAplicacao _app;

        public ProdutoController(IProdutoAplicacao app)
        {
            _app = app;
        }

        [HttpGet]
        [Route("v1/produtos")]
        public IActionResult GetAll()
        {            
            return Ok(_app.SelecionarTodos());
        }

        [HttpPost]
        [Route("v1/produtos/incluir")]
        public IActionResult Post(ProdutoViewModel produto)
        {
            _app.Incluir(produto);
            return Ok("Produto incluído");
        }
    }
}
