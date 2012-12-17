using System;
using Application4Test.Domain;
using EasyArchitecture.Persistence;
using EasyArchitecture.Runtime;
using EasyArchitecture.Tests.Stuff.Helpers;
using EasyArchitecture.Validation.Plugin.BultIn;
using EasyArchitecture.Validation.Plugin.Contracts;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class RepositoryTest
    {
        private Dog _dog;

        [SetUp]
        public void SetUp()
        {
            _dog = new Dog { Age = 15, Name = "Old Dog" };

            //var _moduleName = Guid.NewGuid().ToString();

            //var validatorPlugin = new ValidatorPlugin();
            //var infraAssembly = AssemblyLoader.LoadAssemblyFromFile(AssemblyLoader.InfrastructureAssemblyName);

            //validatorPlugin.Configure(new ModuleAssemblies(_moduleName, null, null, infraAssembly));
            //_plugin = validatorPlugin.GetInstance();
        }

         [Test]
        public void Should_save_entity()
         {
             var repo = new Repository<Dog>();
             Assert.That(() => repo.Save(_dog), Throws.Nothing);
         }

         [Test]
         public void Should_get_entity()
         {
             var repo = new Repository<Dog>();
             Assert.That(() => repo.Save(_dog), Throws.Nothing);
         }

         [Test]
         public void Should_update_entity()
         {
             var repo = new Repository<Dog>();
             Assert.That(() => repo.Save(_dog), Throws.Nothing);
         }

         [Test]
         public void Should_delete_entity()
         {
             var repo = new Repository<Dog>();
             Assert.That(() => repo.Save(_dog), Throws.Nothing);
         }


    
    }
}
