using System;
using Application4Test.Domain;
using EasyArchitecture.Persistence.Plugin.BultIn;
using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Runtime;
using EasyArchitecture.Runtime.Plugin;
using NUnit.Framework;

namespace EasyArchitecture.Tests.Plugins
{
    [TestFixture]
    public class PersistenceTest
    {
        private Dog _dog;
        private IPersistence _pluginInstance;
        private string _moduleName;

        [SetUp]
        public void SetUp()
        {
            _dog = new Dog { Age = 15, Name = "Old Dog" };

            _moduleName = Guid.NewGuid().ToString();

            var plugin = new PersistencePlugin();
            PluginInspector pluginInspector;
            plugin.Configure(new ModuleAssemblies(_moduleName, null, null, null), out pluginInspector);
            _pluginInstance = plugin.GetInstance();
        }


         [Test]
         public void Should_begin_transaction()
         {
             Assert.That(() => _pluginInstance.BeginTransaction(), Throws.Nothing);
         }

         [Test]
         public void Should_commit_transaction()
         {
             Assert.That(() => _pluginInstance.BeginTransaction(), Throws.Nothing);
             Assert.That(() => _pluginInstance.CommitTransaction(), Throws.Nothing);
         }

         [Test]
         public void Should_not_commit_a_non_initialized_transaction()
         {
             Assert.That(() => _pluginInstance.CommitTransaction(), Throws.TypeOf<NotInTransactionException>());
             
         }

         [Test]
         public void Should_rollback_transaction()
         {
             Assert.That(() => _pluginInstance.BeginTransaction(), Throws.Nothing);
             Assert.That(() => _pluginInstance.RollbackTransaction(), Throws.Nothing);
         }

         [Test]
         public void Should_not_rollback_a_non_initialized_transaction()
         {
             Assert.That(() => _pluginInstance.RollbackTransaction(), Throws.TypeOf<NotInTransactionException>());
         }

         [Test]
         public void Should_save_entity()
         {
             Assert.That(() => _pluginInstance.Save(_dog), Throws.Nothing);
         }

         [Test]
         public void Should_get_entity()
         {
             _pluginInstance.Save(_dog);

             var dog = _pluginInstance.Get<Dog>(new Dog() { Age = 15 });

             Assert.That(dog[0] ,Is.EqualTo(_dog));
         }

         [Test]
         public void Should_get_list_of_entity()
         {
             _pluginInstance.Save(_dog);

             var dog = _pluginInstance.Get<Dog>();

             Assert.That(dog[0], Is.EqualTo(_dog));
         }


         [Test]
         public void Should_update_entity()
         {
             _pluginInstance.Save(_dog);

             var dogs = _pluginInstance.Get<Dog>();
             var dog = dogs[0];

             dog.Age = 200;

             _pluginInstance.Update(dog);

             dogs = _pluginInstance.Get<Dog>();
             dog = dogs[0];

             Assert.That(dog.Age, Is.EqualTo(200));
         }

         [Test]
         public void Should_delete_entity()
         {
             _pluginInstance.Save(_dog);

             var dogs = _pluginInstance.Get<Dog>();
             var dog = dogs[0];

             dog.Age = 200;

             _pluginInstance.Delete(dog);

             dogs = _pluginInstance.Get<Dog>();

             Assert.That(dogs.Count, Is.EqualTo(0));
         }
    }
}
