using System;

namespace EasyArchitecture.Plugins.Default.DI
{
	public class DefaultProxy : IProxyInvocationHandler
	{
        Object obj = null;

        public DefaultProxy( Object obj ) {
            this.obj = obj;
        }

        public static Object NewInstance( Object obj ) {
            return ProxyFactory.GetInstance().Create( 
                new DefaultProxy( obj ), obj.GetType() );
        }

        public Object Invoke(Object proxy, System.Reflection.MethodInfo method, Object[] parameters) {

            Object retVal = null;

            //TODO: remove
            Console.WriteLine("Bye bye");

            //TODO: call chain


            // The actual method is invoked
            retVal = method.Invoke( obj, parameters );

            return retVal;
        }
    }


}






