using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Exemplo.Produto.Infrastructure.Configuration.EntityFramework.Mappings
{
    public class FornecedorMap : EntityTypeConfiguration<Domain.Entities.Fornecedor>
    {
        public FornecedorMap()
        {
            ToTable("Fornecedor");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome);
            Property(x => x.DataCadastro);
            Property(x => x.Telefone);
        }
    }
}