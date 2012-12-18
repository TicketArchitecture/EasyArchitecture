using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using EasyArchitecture.Persistence.Plugin.Contracts;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Persistence.Plugin.BultIn
{
    internal class PersistencePlugin : IPersistencePlugin
    {
        //database
        private Dictionary<Type, ArrayList> _dataBase = new Dictionary<Type, ArrayList>();

        public void Configure(ModuleAssemblies moduleAssemblies )
        {
            
        }

        public IPersistence GetInstance()
        {
            return new Persistence(_dataBase);
        }
    }
}