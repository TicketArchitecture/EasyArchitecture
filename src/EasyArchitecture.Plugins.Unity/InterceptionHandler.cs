using System;
using System.Collections.Generic;
using System.Linq;
using EasyArchitecture.Plugins.Contracts.IoC;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{
    public class InterceptionHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var methods = input.Target.GetType().GetMethods();
            var method = Array.Find(methods, m => m.Name == input.MethodBase.Name);
           
            //TODO: melhorar
            new InterceptionHook(input.Target, method, input.Inputs.Cast<object>().ToArray()).Execute();

            return getNext()(input, getNext);
        }
    }
}