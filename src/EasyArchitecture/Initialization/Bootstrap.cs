using System;
using System.Diagnostics;
using EasyArchitecture.Configuration;
using EasyArchitecture.Data;
using EasyArchitecture.Diagnostic;
using EasyArchitecture.Domain;

namespace EasyArchitecture.Initialization
{
    public sealed class Bootstrap
    {
        private static readonly object SyncRoot = new object();
        private static volatile Bootstrap _instance;

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

                    AutoMapperInitializer.Configure(applicationAssembly);

                    UnityContainerInitializer.AutoRegister(domainAssembly, infrastructureAssembly, false);
                    UnityContainerInitializer.AutoRegister(contractsAssembly, applicationAssembly, true);

                    PersistenceManagerInitializer.Configure(configuration.Name, configuration.ConnectionString, infrastructureAssembly);
                }

                Log.To(typeof(Bootstrap)).Message("Finalizing Bootstrap at {0}ms", sw.ElapsedMilliseconds).Debug();
                LogManager.FinalizeFrameworkLogger();

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
    }
}