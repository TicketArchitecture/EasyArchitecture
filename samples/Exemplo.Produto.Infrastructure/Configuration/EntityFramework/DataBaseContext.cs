using System;
using System.Data.Entity;
using Exemplo.Produto.Infrastructure.Configuration.EntityFramework.Mappings;

namespace Exemplo.Produto.Infrastructure.Configuration.EntityFramework
{
    public class DogContext : DbContext
    {
        public DogContext(): base("Exemplo.Produto")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory + @"\db");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new FornecedorMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
        }
    }
}
