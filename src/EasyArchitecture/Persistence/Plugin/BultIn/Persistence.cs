using System;
using System.Collections;
using System.Collections.Generic;
using EasyArchitecture.Persistence.Plugin.Contracts;

namespace EasyArchitecture.Persistence.Plugin.BultIn
{
    public class Persistence:IPersistence
    {
        private readonly Dictionary<Type, ArrayList> _dataBase;

        public Persistence(Dictionary<Type, ArrayList> dataBase)
        {
            _dataBase = dataBase;
        }

        public void BeginTransaction(object session)
        {
            ((Session)session).BeginTransaction();
        }

        public void CommitTransaction(object session)
        {
            ((Session)session).CommitTransaction();
        }

        public void RollbackTransaction(object session)
        {
            ((Session)session).CommitTransaction();
        }

        public object GetSession(string moduleName)
        {
            return new Session(_dataBase);
        }
    }
}
