using System.Collections.Generic;
using EasyArchitecture.Plugin.Contracts.Translation;
using EasyArchitecture.Plugins.Tests.Translation.Stuff;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.Tests.Translation
{
    [TestFixture]
    public abstract class MinimalTranslatorTest
    {
        protected ITranslator Translator;

        [SetUp]
        public abstract void SetUp();

        [Test]
        public void Should_match_same_name_properties()
        {
            var entity = new Cat() { Age = 15, Id = 8, Name = "Rex" };
            var expected = new CatDto() { Age = 15, Id = 8, Name = "Rex" };

            var actual = Translator.Translate<Cat, CatDto>(entity);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_match_same_name_properties_only()
        {
            var entity = new Cat() { Age = 15, Id = 8, Name = "Rex" };
            var expected = new AnotherCatDto() { Id = 8, Name = "Rex" };

            var actual = Translator.Translate<Cat, AnotherCatDto>(entity);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_translate_using_custom_rule()
        {
            var entity = new Cat() { Age = 15, Id = 8, Name = "Rex" };
            var expected = new OtherCatDto() { Age = 16, Id = 8, Name = "NewName" };

            var actual = Translator.Translate<Cat, OtherCatDto>(entity);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_translate_lists()
        {
            var entityList = new List<Cat>
                                 {
                                     new Cat() {Age = 15, Id = 8, Name = "Rex"},
                                     new Cat() {Age = 4, Id = 1, Name = "Jimmy"},
                                     new Cat() {Age = 95, Id = 3, Name = "Arthur"}
                                 };

            var expected = new List<CatDto>()
                    {
                                     new CatDto() {Age = 15, Id = 8, Name = "Rex"},
                                     new CatDto() {Age = 4, Id = 1, Name = "Jimmy"},
                                     new CatDto() {Age = 95, Id = 3, Name = "Arthur"}
                    };

            var actual = Translator.Translate<List<Cat>, List<CatDto>>(entityList);

            Assert.That(actual, Is.EqualTo(expected));
        }
        
        [Test]
        public void Should_translate_inner_types()
        {
            var entity = new Holder { Internal = new Cat() { Age = 15, Id = 8, Name = "Rex" } };
            var expected = new HolderDto { Internal = new CatDto() { Age = 15, Id = 8, Name = "Rex" } };

            var actual = Translator.Translate<Holder, HolderDto>(entity);

            Assert.That(actual.Internal, Is.EqualTo(expected.Internal));
        }
    }
}
