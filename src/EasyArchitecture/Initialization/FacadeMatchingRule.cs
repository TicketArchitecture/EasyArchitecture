using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Initialization
{
    public class FacadeMatchingRule : IMatchingRule
    {
        private readonly bool _allFacades;

        public FacadeMatchingRule(bool allFacades)
        {
            _allFacades = allFacades;
        }

        public bool Matches(MethodBase member)
        {
            if (member.DeclaringType==null || member.DeclaringType.IsInterface)
                return false;

            var isQuery = member.GetCustomAttributes(typeof(QueryMethodAttribute),true).Length!=0;
            var isFacade = member.DeclaringType.Name.EndsWith("Facade");

            return (!isQuery || _allFacades) && isFacade;
        }
    }
}