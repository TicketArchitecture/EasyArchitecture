using EasyArchitecture.Internal;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{
    public class ContextHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //var moduleName = AssemblyManager.RemoveAssemblySufix(input.MethodBase.DeclaringType.Namespace);
            //LocalThreadStorage.SetCurrentBusinessModuleName(moduleName);

            //TODO: nao devia ser chamado diretamente
            LocalThreadStorage.SetCurrentBusinessModuleName(input.MethodBase.DeclaringType);

            return getNext()(input, getNext);
        }
    }
}