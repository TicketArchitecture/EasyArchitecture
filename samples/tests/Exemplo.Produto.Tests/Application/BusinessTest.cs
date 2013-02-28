using System;
using EasyArchitecture.Mechanisms.Configuration;
using EasyArchitecture.Mechanisms.IoC;
using Exemplo.Produto.Application.Contracts;
using Exemplo.Produto.Application.Contracts.DTOs;
using NUnit.Framework;
using System.Linq;

namespace Exemplo.Produto.Tests.Application
{
    [TestFixture]
    public class BusinessTest
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
        public void Consegue_executar_cadastro_complexo()
        {

            var produto = new ProdutoDTO
            {
                DataCadastro = DateTime.Now,
                Descricao = "Produto Repetido",
                IdCategoria = 1,
                IdFornecedor = 1,
                Nome = "Nome"
            };

            var service = Container.Resolve<IProdutoFacade>();

            //esse metodo insere 3 vezes o mesmo produto
            service.InserirProdutosIguais(produto);

            //recuperando
            var produtos =
                service.ObterTodos().Where(p => p.Descricao == produto.Descricao && p.DataCadastro.ToString() == produto.DataCadastro.ToString()).ToList();

            Assert.That(produtos.Count, Is.EqualTo(3));
        }
    }
}
