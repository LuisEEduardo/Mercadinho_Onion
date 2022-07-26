using Mercearia.Models.VendaContext;
using Xunit;

namespace Mercadinho.Tests.Models
{
    public class ProdutoUnitTest
    {
        private readonly Produto produto1 = Produto.CriarProduto("abacate", 5.5, "abacate verde");


        [Fact]
        public void Alterar_nome_retornaTrue()
        {            
            produto1.AlterarNome("mamão");
            Assert.Equal("mamão", produto1.Nome);
        }

        [Fact]
        public void Alterar_nome_retornaFalse()
        {
            produto1.AlterarNome("  ");
            Assert.NotEqual("  ", produto1.Nome);
        }

        [Theory]
        [InlineData(-1)]
        public void Alterar_preco_retornarTrue(double preco)
        {
            produto1.AlterarPreco(preco);
            Assert.NotEqual(preco, produto1.Preco);
        }

    }
}
