using System;
using Application4Test.Domain;
using EasyArchitecture.Persistence;
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
        public void Should_get_session()
         {
             var session = (Session)_pluginInstance.GetSession(_moduleName);
             Assert.That(session, Is.Not.Null);
         }

         [Test]
         public void Should_begin_transaction()
         {
             var session = (Session)_pluginInstance.GetSession(_moduleName);
             _pluginInstance.BeginTransaction(session);

             Assert.That(session.InTransaction, Is.True);
         }

         [Test]
         public void Should_commit_transaction()
         {
             var session = (Session)_pluginInstance.GetSession(_moduleName);

             _pluginInstance.BeginTransaction(session);
             Assert.That(session.InTransaction, Is.True);

             _pluginInstance.CommitTransaction(session);
             Assert.That(session.InTransaction, Is.False);
         }

         [Test]
         public void Should_not_commit_a_non_initialized_transaction()
         {
             var session = (Session)_pluginInstance.GetSession(_moduleName);

             Assert.That(() => _pluginInstance.CommitTransaction(session), Throws.TypeOf<NotInTransactionException>());
         }

         [Test]
         public void Should_rollback_transaction()
         {
             var session = (Session)_pluginInstance.GetSession(_moduleName);

             _pluginInstance.BeginTransaction(session);
             Assert.That(session.InTransaction, Is.True);

             _pluginInstance.RollbackTransaction(session);
             Assert.That(session.InTransaction, Is.False);
         }

         [Test]
         public void Should_not_rollback_a_non_initialized_transaction()
         {
             var session = (Session)_pluginInstance.GetSession(_moduleName);

             Assert.That(() => _pluginInstance.RollbackTransaction(session), Throws.TypeOf<NotInTransactionException>());
         }

         [Test]
         public void Should_save_entity()
         {
             var session = (Session)_pluginInstance.GetSession(_moduleName);
             Assert.That(() => session.Save(_dog), Throws.Nothing);
         }

         [Test]
         public void Should_get_entity()
         {
             var session = (Session)_pluginInstance.GetSession(_moduleName);
             session.Save(_dog);

             var dog = session.Get<Dog>(new Dog(){Age = 15});

             Assert.That(dog[0] ,Is.EqualTo(_dog));

         }

         [Test]
         public void Should_get_list_of_entity()
         {
             var session = (Session)_pluginInstance.GetSession(_moduleName);
             session.Save(_dog);

             var dog = session.Get<Dog>();

             Assert.That(dog[0], Is.EqualTo(_dog));
         }


         [Test]
         public void Should_update_entity()
         {
             var session = (Session)_pluginInstance.GetSession(_moduleName);
             session.Save(_dog);

             var dogs = session.Get<Dog>();
             var dog = dogs[0];

             dog.Age = 200;

             session.Update(dog);

             dogs = session.Get<Dog>();
             dog = dogs[0];

             Assert.That(dog.Age, Is.EqualTo(200));


         }

         [Test]
         public void Should_delete_entity()
         {
             var session = (Session)_pluginInstance.GetSession(_moduleName);
             session.Save(_dog);

             var dogs = session.Get<Dog>();
             var dog = dogs[0];

             dog.Age = 200;

             session.Delete(dog);

             dogs = session.Get<Dog>();

             Assert.That(dogs.Count, Is.EqualTo(0));
         }
    }
}
