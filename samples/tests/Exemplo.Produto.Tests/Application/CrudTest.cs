using System;
using EasyArchitecture.Mechanisms.Configuration;
using EasyArchitecture.Mechanisms.IoC;
using Exemplo.Produto.Application.Contracts;
using Exemplo.Produto.Application.Contracts.DTOs;
using NUnit.Framework;

namespace Exemplo.Produto.Tests.Application
{
    [TestFixture]
    public class CrudTest
    {
        [SetUp]
        public void SetUp()
        {
            Configure
                .For<IProdutoFacade>()
                .Persistence<EasyArchitecture.Plugins.NHibernate.Persistence.NHibernatePlugin>()
                .Translation<EasyArchitecture.Plugins.AutoMapper.AutoMapperPlugin>()
                .Done();
        }

        [Test]
        public void Consegue_cadastrar_produtos()
        {
            var produto = new ProdutoDTO
            {
                DataCadastro = DateTime.Now,
                Descricao = "Descricao",
                IdCategoria = 1,
                IdFornecedor = 1,
                Nome = "Nome"
            };

            var service = Container.Resolve<IProdutoFacade>();
            service.Inserir(produto);

            Assert.That(produto.Id, Is.GreaterThan(0));
        }


        [Test]
        public void Consegue_listar_todos_produtos()
        {
            var service = Container.Resolve<IProdutoFacade>();

            var produtos = service.ObterTodos();

            Assert.That(produtos.Count, Is.AtLeast(1));
        }

        [Test]
        public void Consegue_obter_produto_por_id()
        {
            var service = Container.Resolve<IProdutoFacade>();

            var produtos = service.ObterTodos();
            var expected = CollectionHelper.GetRandom(produtos);
            var id = expected.Id;

            var actual = service.Obter(id);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Descricao, Is.EqualTo(expected.Descricao));
        }

        [Test]
        public void Nao_deve_cadastrar_produto_sem_nome()
        {
            var produto = new ProdutoDTO
            {
                DataCadastro = DateTime.Now,
                Descricao = "Descricao",
                IdCategoria = 1,
                IdFornecedor = 1
            };

            var service = Container.Resolve<IProdutoFacade>();

            Assert.That(() => service.Inserir(produto), Throws.Exception);
        }

        [Test]
        public void Consegue_modificar_produtos()
        {
            var service = Container.Resolve<IProdutoFacade>();

            var produtos = service.ObterTodos();
            var produto = CollectionHelper.GetRandom(produtos);
            var id = produto.Id;

            //modificando
            produto.Nome = "Teste modificação";
            produto.Descricao = string.Format("Modificado em {0}", DateTime.Now.ToString());
            service.Atualizar(produto);

            var expected = produto;

            var actual = service.Obter(id);

            Assert.That(actual.Descricao, Is.EqualTo(expected.Descricao));

        }

        [Test]
        public void Consegue_excluir_produtos()
        {
            var service = Container.Resolve<IProdutoFacade>();

            var produtos = service.ObterTodos();
            var produto = CollectionHelper.GetRandom(produtos);
            var id = produto.Id;

            //excluindo
            service.Excluir(id);

            var actual = service.Obter(id);

            Assert.That(actual, Is.Null);

        }
    }
}
