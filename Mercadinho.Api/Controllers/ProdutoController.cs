using Mercadinho.Application.Interface;
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

        [Route("v1/produtos")]
        public IActionResult Get()
        {
            return Ok("Hello World!");
        }
    }
}
