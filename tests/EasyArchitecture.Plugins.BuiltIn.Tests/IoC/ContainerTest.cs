﻿using EasyArchitecture.Plugin.BultIn.IoC;
using EasyArchitecture.Plugins.Validation.IoC;
using NUnit.Framework;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.IoC
{
    [TestFixture]
    public class ContainerTest:MinimalContainerTest
    {
        [SetUp]
        public override void SetUp()
        {
            Container = new ContainerPlugin().GetInstance();
        }
    }
}
