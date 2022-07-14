using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Mercadinho.Api.Controllers
{
    [Route("v1/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoAplicacao _app;

        public PedidoController(IPedidoAplicacao app)
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
            var pedido = _app.SelecionarPorId(id);
            return Ok(pedido);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromForm] PedidoViewModel pedido)
        {
            _app.Incluir(pedido);
            return Ok(pedido);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _app.Excluir(id);
            return Ok("Pedido excluído");
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] PedidoViewModel pedido)
        {
            _app.Atualizar(pedido);
            return Ok("Pedido atualizado");
        }

    }
}
