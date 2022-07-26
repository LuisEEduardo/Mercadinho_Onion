using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mercadinho.Api.Controllers
{
    [Route("v1/carrinhoDeCompras")]
    [ApiController]
    public class CarrinhoDeComprasController : ControllerBase
    {
        private readonly ICarrinhoDeComprasAplicacao _appCarrinhoCompras;

        public CarrinhoDeComprasController(ICarrinhoDeComprasAplicacao appCarrinhoCompras)
        {
            _appCarrinhoCompras = appCarrinhoCompras;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_appCarrinhoCompras.SelecionarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var carrinho = _appCarrinhoCompras.SelecionarPorId(id);
            return Ok(carrinho);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] CarrinhoDeComprasViewModel carrinho)
        {
            _appCarrinhoCompras.Incluir(carrinho);
            return Ok("Carrinho incluído");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _appCarrinhoCompras.Excluir(id);
            return Ok("Carrinho excluído");
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] CarrinhoDeComprasViewModel carrinho)
        {
            _appCarrinhoCompras.Atualizar(carrinho);
            return Ok("Carrinho atualizado");
        }


        [HttpGet]
        [Route("item")]
        public IActionResult GetAllItensCarrinho()
        {
            return Ok(_appCarrinhoCompras.SelecionarTodosItens());
        }

        [HttpGet]
        [Route("item/{id:int}")]
        public IActionResult GetByIdItensCarrinho([FromRoute] int id)
        {
            var itemCarrinho = _appCarrinhoCompras.SelecionarPorIdItem(id);
            return Ok(itemCarrinho);
        }


        [HttpPost]
        [Route("item")]
        public IActionResult PostItensCarrinho([FromForm] int produtoId, int qtd, int carrinhoId)
        {
            var itemCarrinho = new ItemCarrinhoViewModel
            {
                ProdutoId = produtoId,
                Qtd = qtd,
                CarrinhoDeComprasId = carrinhoId
            };
            _appCarrinhoCompras.IncluirItem(itemCarrinho);
            return Ok(itemCarrinho);
        }

        [HttpDelete]
        [Route("item/{id:int}")]
        public IActionResult DeleteItensCarrinho([FromRoute] int id)
        {
            _appCarrinhoCompras.ExcluirItem(id);
            return Ok("Item retirado do carrinho");
        }

        [HttpPut]
        [Route("item")]
        public IActionResult PutItensCarrinho([FromBody] ItemCarrinhoViewModel itemCarrinho)
        {
            _appCarrinhoCompras.AtualizarItem(itemCarrinho);
            return Ok("Item atualizado");
        }

    }
}
