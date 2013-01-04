using System.Collections.Generic;
namespace EasyArchitecture.Tests.Stuff.DI
{
    public class DummyImplementation : IDummyInterface
    {

        private string _message = "";

        public string DummyMethod()
        {
            return "DummyMethod";
        }


        public void VoidDummyMethod()
        {
            _message = "VoidDummyMethodExecuted";
        }

        public int PrimitiveWithOneArg(int number)
        {
            return number;
        }

        public string withArgs(string message1, string message2)
        {
            return message1 + message2;
        }

        public System.Type WithTypedInterfaceArg(KeyValuePair<int,DummyClass> kvp)
        {
            var _kvp = new KeyValuePair<int,DummyClass>(1,new DummyClass());

            return _kvp.Value.GetType();
        }

        public DummyEnum EnumWithEnumArg(DummyEnum aEnum)
        {
            return aEnum;
        }

        public string[] ArrayWithArrArg(string[] messages)
        {
            return messages;
        }

     
        public IList<DummyClass> TypedInterfaceWithoutArgs()
        {
            IList<DummyClass> list = new List<DummyClass>();

            list.Add(new DummyClass());

            return list;
        }


        public string Message()
        {
            return _message;
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


        public void VoidDummyMethod()
        {
            throw new System.NotImplementedException();
        }

        public int PrimitiveWithOneArg(int number)
        {
            throw new System.NotImplementedException();
        }

        public string withArgs(string message1, string message2)
        {
            throw new System.NotImplementedException();
        }

        public System.Type WithTypedInterfaceArg(KeyValuePair<int, DummyClass> kvp)
        {
            throw new System.NotImplementedException();
        }

        public DummyEnum EnumWithEnumArg(DummyEnum aEnum)
        {
            throw new System.NotImplementedException();
        }

        public string[] ArrayWithArrArg(string[] messages)
        {
            throw new System.NotImplementedException();
        }

        public IList<DummyClass> TypedInterfaceWithoutArgs()
        {
            throw new System.NotImplementedException();
        }


        public string Message()
        {
            throw new System.NotImplementedException();
        }
    }
}
