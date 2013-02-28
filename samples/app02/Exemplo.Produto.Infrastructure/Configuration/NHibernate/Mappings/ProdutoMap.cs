using FluentNHibernate.Mapping;

namespace Exemplo.Produto.Infrastructure.Configuration.NHibernate.Mappings
{
    public class ProdutoMap : ClassMap<Domain.Entities.Produto>
    {
        public ProdutoMap()
        {
            Table("Produto");
            Id(x => x.Id);
            Map(x => x.Nome);
            Map(x => x.Descricao);
            Map(x => x.DataCadastro);
            References(x => x.Categoria).Column("IdCategoria").Cascade.None();
            References(x => x.Fornecedor).Column("IdFornecedor").Cascade.None();
        }
    }
}
