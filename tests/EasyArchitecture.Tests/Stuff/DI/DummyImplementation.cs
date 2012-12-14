namespace EasyArchitecture.Tests.Stuff.DI
{
    public class DummyImplementation : IDummyInterface
    {
        public string DummyMethod()
        {
            return "DummyMethod";
        }
    }



        public class DummyRequiredObjectImplementation : IDummyRequiredObjectInterface
    {
            public string RequiredMethod()
            {
                return "RequiredMethod";
            }
    }

    public interface IDummyRequiredObjectInterface
    {
        string RequiredMethod();
    }


    public class DependencyImplementation : IDummyInterface
    {
        private readonly IDummyRequiredObjectInterface _requiredObject;

        //public DependencyImplementation ()
        //{
        //}

        public DependencyImplementation (IDummyRequiredObjectInterface requiredObject)
        {
            _requiredObject = requiredObject;
        }

        public string DummyMethod()
        {
            return _requiredObject.RequiredMethod();
        }
    }
}
