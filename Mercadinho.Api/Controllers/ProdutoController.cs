using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetById([FromRoute] int id)
        {
            var produto = _app.SelecionarPorId(id);
            return Ok(produto);
        }

        [HttpPost]
        [Route("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Post([FromBody] ProdutoViewModel produto)
        {
            _app.Incluir(produto);
            return Ok("Produto incluído");
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete([FromRoute] int id)
        {
            _app.Excluir(id);
            return Ok("Produto excluído");
        }

        [HttpPut]
        [Route("")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Put([FromBody] ProdutoViewModel produto)
        {
            _app.Atualizar(produto);
            return Ok("Produto atualizado");
        }

        //[HttpGet]
        //[Route("produtoEspecifico/{nome}")]
        //public IActionResult GetByName([FromRoute] string nome)
        //{
        //    var produto = _app.SelecionarPorNome(nome);
        //    return Ok(produto);
        //}

    }
}
