using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{
    public class FacadeMatchingRule : IMatchingRule
    {
        public bool Matches(MethodBase member)
        {
            if (member.DeclaringType==null || member.DeclaringType.IsInterface)
                return false;

            //TODO: essa regra é muito genérica
            return member.DeclaringType.Name.EndsWith("Facade");
        }
    }
}