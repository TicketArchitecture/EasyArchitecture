using EasyArchitecture.Internal;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Initialization
{
    public class ContextHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var moduleName = AssemblyManager.RemoveAssemblySufix(input.MethodBase.DeclaringType.Namespace);
            LocalThreadStorage.SetCurrentBusinessModuleName(moduleName);

            return getNext()(input, getNext);
        }
    }
}