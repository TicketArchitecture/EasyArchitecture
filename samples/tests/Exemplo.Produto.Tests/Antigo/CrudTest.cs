using System;
using Exemplo.Produto.Data.TO;
using Exemplo.Produto.Service;
using Framework.Service;
using NUnit.Framework;

namespace Exemplo.Produto.Tests.Antigo
{
    [TestFixture]
    public class CrudTest
    {
        [Test]
        public void Consegue_listar_todos_produtos()
        {
            var produtos = new ProdutoService().ObterTodos();

            Assert.That(produtos.Count, Is.AtLeast(1));
        }

        [Test]
        public void Consegue_obter_produto_por_id()
        {
            var produtos = new ProdutoService().ObterTodos();
            var produto = CollectionHelper.GetRandom(produtos);
            var id = produto.Id;

            //recuperando
            var actual = new ProdutoService().Obter(id);

            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void Consegue_cadastrar_produtos()
        {

            var produto = new ProdutoTO
            {
                DataCadastro = DateTime.Now,
                Descricao = "Descricao",
                IdCategoria = 1,
                IdFornecedor = 1,
                Nome = "Nome"
            };

            new ProdutoService().Inserir(produto);

            Assert.That(produto.Id, Is.GreaterThan(1));
        }

        [Test]
        public void Nao_deve_cadastrar_produto_sem_nome()
        {
            var produto = new ProdutoTO
            {
                DataCadastro = DateTime.Now,
                Descricao = "Descricao",
                IdCategoria = 1,
                IdFornecedor = 1
            };

            Assert.That(() => new ProdutoService().Inserir(produto), Throws.TypeOf<PreconditionException>());
        }


        [Test]
        public void Consegue_modificar_produtos()
        {
            var produtos = new ProdutoService().ObterTodos();
            var produto = CollectionHelper.GetRandom(produtos);
            var id = produto.Id;

            //modificando
            produto.Nome = "Teste modificação";
            produto.Descricao = string.Format("Modificado em {0}", DateTime.Now.ToString());
            new ProdutoService().Atualizar(produto);
            
            var expected = produto;

            var actual = new ProdutoService().Obter(id);

            Assert.That(actual.Descricao,Is.EqualTo(expected.Descricao));

        }

        [Test]
        public void Consegue_excluir_produtos()
        {
            var produtos = new ProdutoService().ObterTodos();
            var produto = CollectionHelper.GetRandom(produtos);
            var id = produto.Id;

            //excluindo
            new ProdutoService().Excluir(id);

            var actual = new ProdutoService().Obter(id);

            Assert.That(actual, Is.Null);

        }
    }
}
