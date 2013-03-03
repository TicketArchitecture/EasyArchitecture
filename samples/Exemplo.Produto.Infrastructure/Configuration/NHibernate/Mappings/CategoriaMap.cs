using FluentNHibernate.Mapping;

namespace Exemplo.Produto.Infrastructure.Configuration.NHibernate.Mappings
{
    public class CategoriaMap : ClassMap<Domain.Entities.Categoria>
    {
        public CategoriaMap()
        {
            Table("Categoria");
            Id(x => x.Id);
            Map(x => x.Descricao);
        }
    }
}