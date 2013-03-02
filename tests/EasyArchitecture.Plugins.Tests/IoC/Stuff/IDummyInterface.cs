using System.Collections.Generic;

namespace EasyArchitecture.Plugins.Tests.IoC.Stuff
{
    public interface IDummyInterface
    {
        string DummyMethod();

        void VoidDummyMethod();

        int PrimitiveWithOneArg(int number);

        string withArgs(string message1, string message2);

        System.Type WithTypedInterfaceArg(KeyValuePair<int, DummyClass> kvp);

        DummyEnum EnumWithEnumArg(DummyEnum aEnum);

        string[] ArrayWithArrArg(string[] messages);

        IList<DummyClass> TypedInterfaceWithoutArgs();

        string Message();

    }
}
