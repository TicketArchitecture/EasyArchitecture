using System;

namespace EasyArchitecture.Plugins.Validation.IoC.Stuff
{
    public class DummyClass
    {
        public string DummyAttribute { get; set; }

        public string DummyMethod()
        {
            return "DummyMethod";

        }

        public DummyClass() { 
            DummyAttribute = "DummyAttribute"; 
        }

        public override bool Equals(Object obj)
        {
            var dummy = obj as DummyClass;
            return DummyAttribute.Equals(dummy.DummyAttribute);
        }

    }
}
