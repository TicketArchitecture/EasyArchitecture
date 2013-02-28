using System;
using System.Data.Entity;
using EasyArchitecture.Plugins.EntityFramework.Tests.Stuff.Mappings;

namespace EasyArchitecture.Plugins.EntityFramework.Tests.Stuff
{
    public class DogContext : DbContext
    {
        public DogContext()
            : base("DbContext")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory + @"\Stuff");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new DogMapping());
        }
    }
}
