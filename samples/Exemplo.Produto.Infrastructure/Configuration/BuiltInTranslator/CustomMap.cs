using System.Linq;
using EasyArchitecture.Plugins.BultIn.Translation;
using Exemplo.Produto.Application.Contracts.DTOs;
using Exemplo.Produto.Domain.Entities;
using Exemplo.Produto.Infrastructure.Repositories;

namespace Exemplo.Produto.Infrastructure.Configuration.BuiltInTranslator
{
    public class CustomMap : MapRule
    {
        public CustomMap()
        {
            AddMapRule<Domain.Entities.Produto, ProdutoDTO>((source, target) =>
            {
                target.IdCategoria = source.Categoria != null ? source.Categoria.Id : (long?)null;
                target.IdFornecedor = source.Fornecedor != null ? source.Fornecedor.Id : (long?)null;
                target.Id = source.Id;
                target.DataCadastro = source.DataCadastro;
                target.Descricao = source.Descricao;
                target.Nome = source.Nome;

                return target;
            });

            AddMapRule<ProdutoDTO, Domain.Entities.Produto>((source, target) =>
            {
                var categoriaRepository = new CategoriaRepository();
                var fornecedorRepository = new FornecedorRepository();

                target.Categoria = source.IdCategoria.HasValue ? categoriaRepository.Get(new Categoria { Id = source.IdCategoria.Value }).FirstOrDefault() : null;
                target.Fornecedor = source.IdFornecedor.HasValue ? fornecedorRepository.Get(new Fornecedor { Id = source.IdFornecedor.Value }).FirstOrDefault() : null;
                target.DataCadastro = source.DataCadastro;
                target.Descricao = source.Descricao;
                target.Nome = source.Nome;

                return target;
            });
        }
    }
}
