using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Exemplo.Produto.Infrastructure.Configuration.EntityFramework.Mappings
{
    public class ProdutoMap : EntityTypeConfiguration<Domain.Entities.Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome);
            Property(x => x.Descricao);
            Property(x => x.DataCadastro);
            HasOptional(x => x.Categoria).WithMany().Map(m => m.MapKey("IdCategoria"));
            HasOptional(x => x.Fornecedor).WithMany().Map(m => m.MapKey("IdFornecedor"));
        }
    }
}