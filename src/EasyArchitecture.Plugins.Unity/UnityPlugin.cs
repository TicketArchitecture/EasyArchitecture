using EasyArchitecture.Core;
using EasyArchitecture.Plugins.Contracts.IoC;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace EasyArchitecture.Plugins.Unity
{
    public class UnityPlugin : Plugin,IContainerPlugin
    {
        private IUnityContainer _container;

        private void ConfigurePoliceInterceptor()
        {
            _container.Configure<Interception>()
                .AddPolicy("Interception")
                .AddMatchingRule<FacadeMatchingRule>()
                .AddCallHandler(typeof(InterceptionHandler));
        }

        public IContainer GetInstance()
        {
            return new UnityContainer(_container);
        }

        protected override void ConfigurePlugin(PluginConfiguration pluginConfiguration, PluginInspector pluginInspector)
        {
               if (_container != null) return;

            _container = new Microsoft.Practices.Unity.UnityContainer();
            _container.AddNewExtension<Interception>();

            ConfigurePoliceInterceptor();
        }        
    }
}
