using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Mercadinho.Api.Controllers
{
    [Route("v1/item-carrinho")]
    [ApiController]
    public class ItemCarrinhoController : ControllerBase
    {
        private readonly IItemCarrinhoAplicacao _app;        

        public ItemCarrinhoController(IItemCarrinhoAplicacao app)
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
            var itemCarrinho = _app.SelecionarPorId(id);
            return Ok(itemCarrinho);
        }


        [HttpPost]
        [Route("")]
        public IActionResult Post([FromForm] int produtoId, int qtd, int carrinhoId)
        {
            var itemCarrinho = new ItemCarrinhoViewModel
            {
                ProdutoId = produtoId,
                Qtd = qtd,
                CarrinhoDeComprasId = carrinhoId
            };
            _app.Incluir(itemCarrinho);
            return Ok(itemCarrinho);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _app.Excluir(id);
            return Ok("Item retirado do carrinho");
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] ItemCarrinhoViewModel itemCarrinho)
        {
            _app.Atualizar(itemCarrinho);
            return Ok("Item atualizado");
        }
    }
}
