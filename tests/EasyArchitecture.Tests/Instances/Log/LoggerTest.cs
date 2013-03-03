using System;
using EasyArchitecture.Core;
using EasyArchitecture.Instances.Log;
using EasyArchitecture.Plugins.Contracts.Log;
using NUnit.Framework;
using Rhino.Mocks;

namespace EasyArchitecture.Tests.Instances.Log
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

            ThreadContext.Create("EasyArchitecture.Tests");
            ThreadContext.GetCurrent().SetInstance(new Logger(_instancePlugin));
        }

        [TearDown]
        public void TearDown()
        {
            ThreadContext.GetCurrent().SetInstance<Logger>(null);
        }

        [Test]
        public void Should_log()
        {
            const string message = "mensagem de teste";
            var identifier = ThreadContext.GetCurrent().Identifier;
            Expect.Call(() => _instancePlugin.Log(LogLevel.Debug, identifier, message, null)).Repeat.Once();
            _mockery.ReplayAll();

            Mechanisms.Log.Logger.Message(message).Debug();

            _mockery.VerifyAll();
        }
    }
}