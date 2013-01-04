using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyArchitecture.Tests.Stuff.DI
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
