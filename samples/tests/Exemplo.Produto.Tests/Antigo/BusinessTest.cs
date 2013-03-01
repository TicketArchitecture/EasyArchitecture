using System;
using Exemplo.Produto.Data.TO;
using Exemplo.Produto.Service;
using System.Linq;
using NUnit.Framework;

namespace Exemplo.Produto.Tests.Antigo
{
    [TestFixture]
    public class BusinessTest
    {
        [Test]
        public void Consegue_executar_cadastro_complexo()
        {

            var produto = new ProdutoTO
            {
                DataCadastro = DateTime.Now,
                Descricao = "Produto Repetido",
                IdCategoria = 1,
                IdFornecedor = 1,
                Nome = "Nome"
            };

            //esse metodo insere 3 vezes o mesmo produto
            new ProdutoService().InserirProdutosIguais(produto);

            //recuperando
            var produtos =
                new ProdutoService().ObterTodos().Where(p => p.Descricao == produto.Descricao && p.DataCadastro.ToString() == produto.DataCadastro.ToString()).ToList();

            Assert.That(produtos.Count, Is.EqualTo(3));
        }
    }
}
