using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{
    public class AnyMatchingRule : IMatchingRule
    {
        public bool Matches(MethodBase member)
        {
            return true;
        }
    }
}