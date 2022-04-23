using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Mercadinho.Api.Controllers
{
    [Route("v1/carrinhoDeCompras")]
    [ApiController]
    public class CarrinhoDeComprasController : ControllerBase
    {

        private readonly ICarrinhoDeComprasAplicacao _app;

        public CarrinhoDeComprasController(ICarrinhoDeComprasAplicacao app)
        {
            _app = app;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            return Ok(_app.SelecionarTodos());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var carrinho = _app.SelecionarPorId(id);
            return Ok(carrinho);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] CarrinhoDeComprasViewModel carrinho)
        {
            _app.Incluir(carrinho);
            return Ok("Carrinho incluído");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _app.Excluir(id);
            return Ok("Carrinho excluído");
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] CarrinhoDeComprasViewModel carrinho)
        {
            _app.Atualizar(carrinho);
            return Ok("Carrinho atualizado");
        }

    }
}
