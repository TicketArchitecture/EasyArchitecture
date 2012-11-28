using EasyArchitecture.Diagnostic;
using EasyArchitecture.Initialization;
using Application4Test.Domain;
using EasyArchitecture.Plugins.Log4net;
using NUnit.Framework;
using EasyArchitecture.Domain;

namespace EasyArchitecture.Tests.Internals.Domain
{
    [TestFixture]
    public class ValidatorEngineTest
    {
        private Dog _oldDog ;
        private Dog _youngDog;

        [SetUp]
        public void Init() {
            Bootstrap.Configure<ILogPlugin>(new Log4NetPlugin()); 
            Bootstrap.GetInstance();

            _oldDog = new Dog { Age = 15, Name = "Old Dog" };
            _youngDog = new Dog { Age = 5, Name = "Young Dog" };
        }

        [Test]
        public void IsValidTest()
        {
            ValidatorEngine.IsValid(_youngDog);
            Assert.That(true);

            //Assert.Throws<InvalidEntityException>(() => ValidatorEngine.IsValid(_oldDog));
            Assert.That(() => ValidatorEngine.IsValid(_oldDog), Throws.TypeOf<InvalidEntityException>());
        }



        [Test]
        public void GetMessagesTest()
        {
            var expected = new System.Collections.Generic.List<string>() {"There's no dog so old"};
            var actual = ValidatorEngine.GetMessages(_oldDog);

            Assert.That(actual,Is.EqualTo(expected));


            expected = new System.Collections.Generic.List<string>() ;
            actual = ValidatorEngine.GetMessages(_youngDog);

            Assert.That(actual, Is.EqualTo(expected));

        }

    }
}
