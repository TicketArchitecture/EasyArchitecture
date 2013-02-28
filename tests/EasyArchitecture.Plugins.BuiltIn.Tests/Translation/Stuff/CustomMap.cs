using EasyArchitecture.Plugin.BultIn.Translation;
using EasyArchitecture.Plugins.Validation.Translation.Stuff;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.Translation.Stuff
{
    public class CustomMap : MapRule
    {
        public CustomMap()
        {
            AddMapRule<Cat, OtherCatDto>((source, target) =>
                {
                    target.Id = source.Id;
                    target.Age = source.Age + 1;
                    target.Name = "NewName";
                    return target;
                });
        }
    }
}
