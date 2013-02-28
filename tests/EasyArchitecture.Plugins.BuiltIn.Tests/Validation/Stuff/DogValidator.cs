using EasyArchitecture.Plugin.BultIn.Validation;
using EasyArchitecture.Plugins.Validation.Validation.Stuff;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.Validation.Stuff
{
    public class DogValidator:ValidationRuleSet<Dog>
    {
        public DogValidator() {
            AddRule(d => d.Age > 10, "There's no dog so old");
        }
    }
}
