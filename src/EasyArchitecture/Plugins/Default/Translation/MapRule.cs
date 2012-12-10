using System;

namespace EasyArchitecture.Plugins.Default.Translation
{
    public class MapRule<T, TD>
    {
        public MapRule<T, TD> Rule<T1, T2>(Func<T1, T2> func)
        {
            Translator.mappedRules.Add(new RuleMap()
            {
                Source = typeof(T),
                Target = typeof(TD),
                PropertySource = typeof(T1),
                PropertyTarget = typeof(T2),
                DeclaredRuleMap = func
            });

            return new MapRule<T, TD>();
        }
    }
}