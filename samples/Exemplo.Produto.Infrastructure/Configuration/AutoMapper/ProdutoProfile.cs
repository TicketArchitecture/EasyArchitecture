using System.Linq;
using AutoMapper;
using Exemplo.Produto.Application.Contracts.DTOs;
using Exemplo.Produto.Domain.Entities;
using Exemplo.Produto.Infrastructure.Repositories;

namespace Exemplo.Produto.Infrastructure.Configuration.AutoMapper
{
    public class ProdutoProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Domain.Entities.Produto, ProdutoDTO>()
                .ForMember(x => x.IdCategoria, o => o.MapFrom(m => m.Categoria.Id))
                .ForMember(x => x.IdFornecedor, o => o.MapFrom(m => m.Fornecedor.Id));

            var categoriaRepository = new CategoriaRepository();
            var fornecedorRepository = new FornecedorRepository();

            Mapper.CreateMap<ProdutoDTO, Domain.Entities.Produto>()
                .ForMember(x => x.Categoria, o => o.MapFrom(m => m.IdCategoria.HasValue ? categoriaRepository.Get(new Categoria() { Id = m.IdCategoria.Value }).FirstOrDefault() : null))
                .ForMember(x => x.Fornecedor, o => o.MapFrom(m => m.IdFornecedor.HasValue ? fornecedorRepository.Get(new Fornecedor() { Id = m.IdFornecedor.Value }).FirstOrDefault() : null));
        }
    }
}