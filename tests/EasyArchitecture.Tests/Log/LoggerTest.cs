using EasyArchitecture.Log;
using EasyArchitecture.Log.Plugin.Contracts;
using EasyArchitecture.Runtime;
using NUnit.Framework;
using Rhino.Mocks;

namespace EasyArchitecture.Tests.Log
{
    [TestFixture]
    public class LoggerTest
    {
        private MockRepository _mockery;
        private ILogger _instancePlugin;

        [SetUp]
        public void SetUp()
        {
            _mockery = new MockRepository();
            _instancePlugin = _mockery.DynamicMock<ILogger>();

            LocalThreadStorage.SetInstance(new EasyArchitecture.Log.Instance.Logger(_instancePlugin));
        }

        [TearDown]
        public void TearDown()
        {
            LocalThreadStorage.SetInstance<EasyArchitecture.Log.Instance.Logger>(null);
        }

        [Test]
        public void Should_log()
        {
            var message = "mensagem de teste";
            
            Expect.Call(() => _instancePlugin.Log(LogLevel.Debug, message,null)).Repeat.Once();
            _mockery.ReplayAll();

            Logger.Message(message).Debug();

            _mockery.VerifyAll();
        }
    }
}