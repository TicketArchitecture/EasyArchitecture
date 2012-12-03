using System.Data.Entity;
using Application4Test.Domain;

namespace Application4Test.Infrastructure.Persistence.Configuration
{
    public class DogContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Dog>();
            entity.ToTable("Dog");
            //entity.HasRequired(x => x.Name).WithRequiredPrincipal();
        }
    }
}
