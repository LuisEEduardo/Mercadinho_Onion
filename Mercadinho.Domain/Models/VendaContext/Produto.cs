using Mercearia.Models.SharedContext;
using System.Collections.Generic;

namespace Mercearia.Models.VendaContext
{
    public class Produto : Base
    {
        private Produto(string nome, double preco, string descricao)
            : base()
        {
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
        }

        public static Produto CriarProduto(string nome, double preco, string descricao)
        {
            return new Produto(nome, preco, descricao);
        }

        public string Nome { get; private set; }
        public double Preco { get; private set; }
        public string Descricao { get; private set; }
        public List<ItemCarrinho> ItensCarrinho { get; private set; }

        public void AlterarNome(string nome)
        {
            if (!string.IsNullOrEmpty(nome) && Nome.Trim().Length >= 3)
                Nome = nome;
        }

        public void AlterarPreco (double preco)
        {
            if (preco > 0)
                Preco = preco;
        }   

        public void AlterarDescricao(string descricao)
        {
            if (!string.IsNullOrEmpty(descricao) && descricao.Trim().Length < 30 && descricao.Trim().Length > 3)
                Descricao = descricao.Trim();
        }

    }
}