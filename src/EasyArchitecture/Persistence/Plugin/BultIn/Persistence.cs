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

        public void BeginTransaction(ISession session)
        {
            session.BeginTransaction();
        }

        public void CommitTransaction(ISession session)
        {
            session.CommitTransaction();
        }

        public void RollbackTransaction(ISession session)
        {
            session.RollbackTransaction();
        }

        public ISession GetSession(string moduleName)
        {
            return new Session(_dataBase);
        }
    }
}
