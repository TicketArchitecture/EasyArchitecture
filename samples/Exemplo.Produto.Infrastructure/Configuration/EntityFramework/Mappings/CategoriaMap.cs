using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Exemplo.Produto.Infrastructure.Configuration.EntityFramework.Mappings
{
    public class CategoriaMap : EntityTypeConfiguration<Domain.Entities.Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao);
        }
    }
}