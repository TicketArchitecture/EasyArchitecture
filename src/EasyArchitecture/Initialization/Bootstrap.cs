using System;
using System.Diagnostics;
using EasyArchitecture.Configuration;
using EasyArchitecture.Data;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Domain;
using Remotion.Linq.Utilities;

namespace EasyArchitecture.Initialization
{
    public sealed class Bootstrap
    {
        private static readonly object SyncRoot = new object();
        private static volatile Bootstrap _instance;
        internal static ILogPlugin LogPlugin;
        internal static IObjectMapperPlugin ObjectMapperPlugin;

        //http://msdn.microsoft.com/en-us/library/ff650316.aspx
        public static Bootstrap GetInstance()
        {
            if (_instance == null)
            {
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new Bootstrap();
                }
            }
            return _instance;
        }


        private Bootstrap()
        {
            var sw = new Stopwatch();
            sw.Start();

            try
            {
                if (LogPlugin == null)
                    throw new ArgumentNullException("LogPlugin");

                if (ObjectMapperPlugin==null)
                    throw new ArgumentNullException("ObjectMapperPlugin");
                
                LogManager.InitializeFrameworkLogger(ConfigurationManager.GetLogLevel());
                Log.To(typeof(Bootstrap)).Message("Initializing Bootstrap").Debug();

                UnityContainerInitializer.Configure();

                var configurations = ConfigurationManager.GetBusinessModulesConfiguration();

                foreach (var configuration in configurations)
                {
                    Log.To(typeof(Bootstrap)).Message("Prepare to configure [{0}] business module", configuration.Name).Debug();

                    var domainAssembly = AssemblyManager.GetDomainAssembly(configuration.Name);
                    var infrastructureAssembly = AssemblyManager.GetInfrastructureAssembly(configuration.Name);
                    var applicationAssembly = AssemblyManager.GetApplicationAssembly(configuration.Name);
                    var contractsAssembly = applicationAssembly;

                    LogManager.Configure(configuration.Name, configuration.LogLevel);

                    ValidatorEngine.Configure(domainAssembly);

                    ObjectMapperPlugin.Configure(infrastructureAssembly);

                    UnityContainerInitializer.AutoRegister(domainAssembly, infrastructureAssembly, false);
                    UnityContainerInitializer.AutoRegister(contractsAssembly, applicationAssembly, true);

                    PersistenceManagerInitializer.Configure(configuration.Name, configuration.ConnectionString, infrastructureAssembly);
                }

                Log.To(typeof(Bootstrap)).Message("Finalizing Bootstrap at {0}ms", sw.ElapsedMilliseconds).Debug();
                //LogManager.FinalizeFrameworkLogger();

            }
            catch (Exception exception)
            {
                Log.To(this).Exception(exception, "Fail to run bootstrap at {0}ms", sw.ElapsedMilliseconds).Fatal();
                throw;
            }
        }

        public void Register<T, U>() where U : T
        {
            UnityContainerInitializer.Register<T, U>();
        }

        public void OutterRegister<T, U>() where U : T
        {
            UnityContainerInitializer.OutterRegister<T, U>();
        }

        public T GetInstance<T>()
        {
            return UnityContainerInitializer.GetInstance<T>();
        }

        public static void Configure<T>(T plugin) //where T : IObjectMapperPlugin,ILogPlugin
        {
            if (plugin is ILogPlugin)
            {
                LogPlugin = plugin as ILogPlugin;
                return;
            }

            if (plugin is IObjectMapperPlugin)
            {
                ObjectMapperPlugin = plugin as IObjectMapperPlugin;
                return;
            }

            throw new ArgumentTypeException("plugin", typeof(ILogPlugin),typeof(T));
        
        }
    }
}