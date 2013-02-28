using EasyArchitecture.Core;
using EasyArchitecture.Instances.Log;
using EasyArchitecture.Plugin.Contracts.Log;
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

            LocalThreadStorage.CreateContext("EasyArchitecture.Tests");
            LocalThreadStorage.GetCurrentContext().SetInstance(new Logger(_instancePlugin));
        }

        [TearDown]
        public void TearDown()
        {
            LocalThreadStorage.GetCurrentContext().SetInstance<Logger>(null);
        }

        [Test]
        public void Should_log()
        {
            var message = "mensagem de teste";
            
            Expect.Call(() => _instancePlugin.Log(LogLevel.Debug, message,null)).Repeat.Once();
            _mockery.ReplayAll();

            Mechanisms.Log.Logger.Message(message).Debug();

            _mockery.VerifyAll();
        }
    }
}