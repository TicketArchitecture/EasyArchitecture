namespace EasyArchitecture.Tests.Internals.DependencyInjection.Stuff
{
    public class NewDummyImplementation : IDummyInterface
    {
        public string DummyMethod()
        {
            return "NewDummyMethod";
        }
    }
}