using System;
using System.Collections;
using System.Collections.Generic;

namespace EasyArchitecture.Persistence.Plugin.BultIn
{
    internal class Session
    {
        private static Dictionary<Type,ArrayList> _dataBase = new Dictionary<Type, ArrayList>();

        public Session()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id;
        private bool _inTransaction = false;
        public ArrayList List = new ArrayList();


        public void BeginTransaction()
        {
            _inTransaction = true;
        }

        public void CommitTransaction()
        {
            //copia da lista temp para lista final

            //marca transacao como finalizada
            _inTransaction = false;
        }

        public void RollbackTransaction()
        {
            //destroi lista
            if(_inTransaction)
                List.Clear();

            //marca transacao como finalizada
            _inTransaction = false;
        }

        public void Save(object o)
        {
            if(_inTransaction)
            {
                //salva numa lista interna
                List.Add(o);
            }else
            {
                //find lista final
                var db = _dataBase[o.GetType()];
                
                //salva na lista final
                db.Add(o);
            }
        }

        public void Update(object o)
        {
            if (_inTransaction)
            {
                //salva numa lista interna
                List.Add(o);
            }
            else
            {
                //find lista final
                var db = _dataBase[o.GetType()];

                //salva na lista final
                db.Add(o);
            }
        }

        public void Delete(object o)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(object key)
        {
            //localiza objeto na lista geral
            var db = _dataBase[typeof(T)];
            //var o = db.find(key);
            var o = new object();

            //if (_inTransaction)
            //{
            //    //clona objeto para lista interna
            //    var a =  o.MemberwiseClone();
            //    var b = o;
            //    o = a;
            //    List.Add(o);
            //}

            return (T) o;
        }

        public IList<T> Get<T>()
        {
            //obtem os

            throw new NotImplementedException();
        }
    }
}