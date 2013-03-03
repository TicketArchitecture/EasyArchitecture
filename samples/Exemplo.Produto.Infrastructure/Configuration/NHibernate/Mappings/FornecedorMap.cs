using FluentNHibernate.Mapping;

namespace Exemplo.Produto.Infrastructure.Configuration.NHibernate.Mappings
{
    public class FornecedorMap : ClassMap<Domain.Entities.Fornecedor>
    {
        public FornecedorMap()
        {
            Table("Fornecedor");
            Id(x => x.Id);
            Map(x => x.Nome);
            Map(x => x.DataCadastro);
            Map(x => x.Telefone);
        }
    }
}