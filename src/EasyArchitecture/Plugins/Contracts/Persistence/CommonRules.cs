using System.Reflection;

namespace EasyArchitecture.Plugins.Contracts.Persistence
{
    public static class CommonRules
    {
        //ignore all these non initialized properties, as well as boolean ones
        public static bool ShouldNotUseForComparison(object exampleValue, PropertyInfo property)
        {
            return (exampleValue == null || exampleValue is bool || exampleValue.Equals(0) ||
                    exampleValue.Equals(string.Empty) ||
                    (property.PropertyType == typeof(decimal) && (decimal)exampleValue == 0));
        }

    }
}
