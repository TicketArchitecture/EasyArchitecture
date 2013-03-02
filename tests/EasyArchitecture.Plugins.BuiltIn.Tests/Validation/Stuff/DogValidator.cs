using EasyArchitecture.Plugin.BultIn.Validation;
using EasyArchitecture.Plugins.Tests.Validation.Stuff;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.Validation.Stuff
{
    public class DogValidator:ValidationRuleSet<Mouse>
    {
        public DogValidator() {
            AddRule(d => d.Age > 10, "There's no dog so old");
        }
    }
}
