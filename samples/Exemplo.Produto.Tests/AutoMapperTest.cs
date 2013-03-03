using EasyArchitecture.Configuration;
using EasyArchitecture.Mechanisms.IoC;
using Exemplo.Produto.Application.Contracts;
using Exemplo.Produto.Domain.Repositories;
using Exemplo.Produto.Tests.Helpers;
using Exemplo.Produto.Tests.Repositories;
using NUnit.Framework;

namespace Exemplo.Produto.Tests
{
    [TestFixture]
    public class AutoMapperTest : BaseTest
    {
        [SetUp]
        public override void SetUp()
        {
            Configure
                .For<IProdutoFacade>()
                .Translation<EasyArchitecture.Plugins.AutoMapper.AutoMapperPlugin>()
                .Done();

            Container.Register<IProdutoRepository, ProdutoMemoryRepository>();

            var categoriaRepository = Container.Resolve<ICategoriaRepository>();
            var fornecedorRepository = Container.Resolve<IFornecedorRepository>();
            var produtoRepository = Container.Resolve<IProdutoRepository>();

            DataBaseHelper.LoadData(categoriaRepository, fornecedorRepository, produtoRepository);

        }
    }
}