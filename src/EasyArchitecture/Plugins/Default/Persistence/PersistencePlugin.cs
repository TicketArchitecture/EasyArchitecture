using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace EasyArchitecture.Plugins.Default.Persistence
{
    public class PersistencePlugin:IPersistencePlugin
    {

        private Dictionary<string,SessionFactory> sessionFactories = new Dictionary<string,SessionFactory>();

        public void Configure(string name, string connectionString, Assembly assembly)
        {
//            throw new NotImplementedException();
        }

        public void BeginTransaction(object session)
        {
            var mySession = session as Session;
            mySession.BeginTransaction();
        }

        public void CommitTransaction(object session)
        {
            var mySession = session as Session;
            mySession.CommitTransaction();
        }

        public void RollbackTransaction(object session)
        {
            var mySession = session as Session;
            mySession.RollbackTransaction();
        }

        public object GetSession(string moduleName)
        {
            
            SessionFactory sessionFactory = null;
            if(sessionFactories.ContainsKey(moduleName))
            {
                sessionFactory = sessionFactories[moduleName];
            }else
            {
                sessionFactory = new SessionFactory();
                sessionFactories[moduleName] = sessionFactory;
            }

            return sessionFactory.GetSession();
            
        }
    }

    internal class SessionFactory
    {
        public Dictionary<Guid,Session> sessions = new Dictionary<Guid,Session>();

        public Session GetSession()
        {
            return new Session();
        }
    }

    internal class Session
    {
        public Session()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id;
        private bool _inTransaction = false;
        //public Dictionary<Guid, Session> sessions = new Dictionary<Guid, Session>();
        public ArrayList List = new ArrayList();


        public void BeginTransaction()
        {
            _inTransaction = true;
        }

        public void CommitTransaction()
        {
            _inTransaction = false;
        }

        public void RollbackTransaction()
        {
            _inTransaction = false;
        }

        public void Save(object o)
        {
            List.Add(o);
        }

        public void Update(object o)
        {
            throw new NotImplementedException();
        }

        public void Delete(object o)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(object key)
        {
            throw new NotImplementedException();
        }

        public IList<T> CreateCriteria<T>()
        {
            throw new NotImplementedException();
        }
    }
}