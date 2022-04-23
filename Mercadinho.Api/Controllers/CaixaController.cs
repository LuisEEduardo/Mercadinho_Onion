using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Mercadinho.Api.Controllers
{
    [Route("v1/caixa")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        private readonly ICaixaAplicacao _app;

        public CaixaController(ICaixaAplicacao app)
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
            var caixa = _app.SelecionarPorId(id);
            return Ok(caixa);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] CaixaViewModel caixa)
        {
            _app.Incluir(caixa);
            return Ok("Caixa incluído");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _app.Excluir(id);
            return Ok("Produto excluído");
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] CaixaViewModel caixa)
        {
            _app.Atualizar(caixa);
            return Ok("Caixa atualizado");
        }

    }
}
