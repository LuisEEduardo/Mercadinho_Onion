using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mercadinho.Api.Controllers
{
    [Route("v1/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAplicacao _app;

        public ProdutoController(IProdutoAplicacao app)
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
        public IActionResult GetById([FromRoute] Guid id)
        {
            var produto = _app.SelecionarPorId(id);
            return Ok(produto);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] ProdutoViewModel produto)
        {
            _app.Incluir(produto);
            return Ok("Produto incluído");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _app.Excluir(id);
            return Ok("Produto excluído");
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] ProdutoViewModel produto)
        {
            _app.Atualizar(produto);
            return Ok("Produto atualizado");
        }

    }
}
