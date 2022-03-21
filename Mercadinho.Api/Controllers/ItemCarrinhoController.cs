using AutoMapper;
using Mercadinho.Application.Interface;
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
        public IActionResult Index()
        {
            return Ok("Item Carrinho");
        }




    }
}
