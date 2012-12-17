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
        //public void Configure(string moduleName, Assembly assembly)
        //{
        //    //load mini map ???

        //}

        //public void BeginTransaction(object session)
        //{
        //    var mySession = session as Session;
        //    mySession.BeginTransaction();
        //}

        //public void CommitTransaction(object session)
        //{
        //    var mySession = session as Session;
        //    mySession.CommitTransaction();
        //}

        //public void RollbackTransaction(object session)
        //{
        //    var mySession = session as Session;
        //    mySession.RollbackTransaction();
        //}

        //public object GetSession(string moduleName)
        //{
            
        //    //cria novo uow
        //    var session = new Session();
        //    return session;


        //}
        
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