using EasyArchitecture.Plugins.Validation.Validation.Stuff;
using EasyArchitecture.Validation.Plugin.BultIn;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.Validation.Stuff
{
    public class DogValidator:ValidationRuleSet<Dog>
    {
        public DogValidator() {
            AddRule(d => d.Age > 10, "There's no dog so old");
        }
    }
}
