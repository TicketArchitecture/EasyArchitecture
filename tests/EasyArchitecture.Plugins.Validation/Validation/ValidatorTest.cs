using EasyArchitecture.Plugin.Contracts.Validation;
using EasyArchitecture.Plugins.Validation.Validation.Stuff;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.Validation.Validation
{
    [TestFixture]
    public abstract class MinimalValidatorTest
    {
        protected IValidator Validator;

        [SetUp]
        public abstract void SetUp();

        [Test]
        public void Should_return_validation_messages_to_invalid_entity()
        {
            var oldDog = new Mouse { Age = 15, Name = "Old Dog" };

            var expected = new System.Collections.Generic.List<string>() { "There's no dog so old" };
            var actual = Validator.Validate(oldDog);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_not_return_messages_valid_entity()
        {
            var youngDog = new Mouse { Age = 5, Name = "Young Dog" };

            var expected = new System.Collections.Generic.List<string>();
            var actual = Validator.Validate(youngDog);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
