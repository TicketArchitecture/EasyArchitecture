using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Plugins.Validation.Persistence.Stuff;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.Validation.Persistence
{
    [TestFixture]
    public abstract class MinimalPersistenceTest
    {
        protected IPersistence PluginInstance;

        [SetUp]
        public abstract void SetUp();


        [Test]
        public void Should_begin_transaction()
        {
            Assert.That(() => PluginInstance.BeginTransaction(), Throws.Nothing);
        }

        [Test]
        public void Should_commit_transaction()
        {
            Assert.That(() => PluginInstance.BeginTransaction(), Throws.Nothing);
            Assert.That(() => PluginInstance.CommitTransaction(), Throws.Nothing);
        }

        [Test]
        public void Should_not_commit_a_non_initialized_transaction()
        {
            Assert.That(() => PluginInstance.CommitTransaction(), Throws.Exception);
        }

        [Test]
        public void Should_rollback_transaction()
        {
            Assert.That(() => PluginInstance.BeginTransaction(), Throws.Nothing);
            Assert.That(() => PluginInstance.RollbackTransaction(), Throws.Nothing);
        }

        [Test]
        public void Should_not_rollback_a_non_initialized_transaction()
        {
            Assert.That(() => PluginInstance.RollbackTransaction(), Throws.Exception);
        }

        [Test]
        public void Should_save_entity()
        {
            var dog = new Dog { Age = 15, Name = "Old Dog" };
            Assert.That(() => PluginInstance.Save(dog), Throws.Nothing);
        }

        [Test]
        public void Should_get_entity()
        {
            var dog = new Dog { Age = 15, Name = "Old Dog" };

            PluginInstance.Save(dog);

            var dogs = PluginInstance.Get<Dog>(new Dog() { Age = 15 });

            Assert.That(dogs[0], Is.EqualTo(dog));
        }

        [Test]
        public void Should_get_list_of_entity()
        {
            var dog = new Dog { Age = 15, Name = "Old Dog" };

            PluginInstance.Save(dog);

            var dogs = PluginInstance.Get<Dog>();

            Assert.That(dogs[0], Is.EqualTo(dog));
        }


        [Test]
        public void Should_update_entity()
        {
            var dog = new Dog { Age = 15, Name = "Old Dog" };

            PluginInstance.Save(dog);

            var dogs = PluginInstance.Get<Dog>();

            dogs[0].Age = 200;

            PluginInstance.Update(dogs[0]);

            dogs = PluginInstance.Get<Dog>();

            Assert.That(dogs[0].Age, Is.EqualTo(200));
        }

        [Test]
        public void Should_delete_entity()
        {
            var _dog = new Dog { Age = 15, Name = "Old Dog" };

            PluginInstance.Save(_dog);

            var dogs = PluginInstance.Get<Dog>();

            dogs[0].Age = 200;

            PluginInstance.Delete(dogs[0]);

            dogs = PluginInstance.Get<Dog>();

            Assert.That(dogs.Count, Is.EqualTo(0));
        }
    }
}
