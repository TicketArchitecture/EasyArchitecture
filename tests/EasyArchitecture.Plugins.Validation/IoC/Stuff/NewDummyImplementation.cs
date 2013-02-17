namespace EasyArchitecture.Plugins.Validation.IoC.Stuff
{
    public class NewDummyImplementation : IDummyInterface
    {
        public string DummyMethod()
        {
            return "NewDummyMethod";
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

        public System.Type WithTypedInterfaceArg(System.Collections.Generic.KeyValuePair<int, DummyClass> kvp)
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

        public System.Collections.Generic.IList<DummyClass> TypedInterfaceWithoutArgs()
        {
            throw new System.NotImplementedException();
        }


        public string Message()
        {
            throw new System.NotImplementedException();
        }
    }
}