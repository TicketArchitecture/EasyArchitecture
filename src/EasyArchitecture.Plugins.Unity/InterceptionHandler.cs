using System;
using EasyArchitecture.Plugins.BultIn.IoC;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{
    public class InterceptionHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var methods = input.Target.GetType().GetMethods();
            var method=Array.Find(methods, m => m.Name == input.MethodBase.Name);

            //TODO: analisar se interception hook eh contrato ou implementacao builtin
            var hook = new InterceptionHook(input.Target, method,null);
            hook.Execute();

            return getNext()(input, getNext);
        }
    }
}