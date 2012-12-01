//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Reflection;
//using EasyArchitecture.Diagnostic;
//using EasyArchitecture.Domain;
//using EasyArchitecture.Plugins;
//using EasyArchitecture.Translation;

//namespace EasyArchitecture.Initialization
//{
//    public class BusinessModuleInstance
//    {
//        private static readonly Dictionary<string, BusinessModuleInstance> Instances = new Dictionary<string, BusinessModuleInstance>();
//        private readonly string _businessModule;


//        private BusinessModuleInstance(string businessModule)
//        {

//            _businessModule = businessModule;

//            var sw = new Stopwatch();
//            sw.Start();

//            try
//            {

//                //configure 
//                //LogManager.Configure(businessModule, "debug");
//                //ValidatorEngine.Configure(_domainAssembly);
//                // PersistencePlugin.Configure(businessModule, "", _infrastructureAssembly);


//                Log.Message("Finalizing Bootstrap at {0}ms", sw.ElapsedMilliseconds).Debug();
//            }
//            catch (Exception exception)
//            {
//                Log.Exception(exception, "Fail to run bootstrap at {0}ms", sw.ElapsedMilliseconds).Fatal();
//                throw;

//            }
//        }







//        public static BusinessModuleInstance CreateInstance(string businessModule)
//        {
//            var instance = new BusinessModuleInstance(businessModule);
//            Instances.Add(businessModule, instance);
//            return instance;
//        }

//    }
////}