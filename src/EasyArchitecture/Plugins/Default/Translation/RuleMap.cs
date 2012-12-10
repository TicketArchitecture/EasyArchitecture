using System;

namespace EasyArchitecture.Plugins.Default.Translation
{
    internal sealed class RuleMap
    {
        public Type Source;
        public Type Target;

        public Type PropertySource;
        public Type PropertyTarget;

        public object DeclaredRuleMap;
    }
}