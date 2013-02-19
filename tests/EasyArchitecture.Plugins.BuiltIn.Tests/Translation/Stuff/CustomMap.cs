using EasyArchitecture.Plugins.Validation.Translation.Stuff;
using EasyArchitecture.Translation.Plugin.BultIn;

namespace EasyArchitecture.Plugins.BuiltIn.Tests.Translation.Stuff
{
    public class CustomMap : MapRule
    {
        public CustomMap()
        {
            AddMapRule<Dog, OtherDogDto>((source, target) =>
                {
                    target.Id = source.Id;
                    target.Age = source.Age + 1;
                    target.Name = "NewName";
                    return target;
                });
        }
    }
}
