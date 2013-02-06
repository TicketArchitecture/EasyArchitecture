using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EasyArchitecture.Persistence.Plugin.BultIn
{
    internal class Session
    {
        public Guid Id;
        //public readonly bool InTransaction = false;
        public bool InTransaction { get; private set; }
        public ArrayList List = new ArrayList(); 
        private readonly Dictionary<Type, ArrayList> _dataBase;
        private readonly Dictionary<Type, ArrayList> _localDataBase;

        public Session(Dictionary<Type, ArrayList> dataBase)
        {
            _dataBase = dataBase;
            Id = Guid.NewGuid();
        }

        public void BeginTransaction()
        {
            InTransaction = true;
        }

        public void CommitTransaction()
        {
            //copia da lista temp para lista final


            if(!InTransaction)
                throw new NotInTransactionException();

            //marca transacao como finalizada
            InTransaction = false;
        }

        public void RollbackTransaction()
        {

            if (!InTransaction)
                throw new NotInTransactionException();
            //destroi lista
            //if(_inTransaction)
            //    List.Clear();

            //marca transacao como finalizada
            InTransaction = false;
        }

        public void Save(object o)
        {
            //if(_inTransaction)
            //{
            //    //salva numa lista interna
            //    List.Add(o);
            //}else
            //{
            //    //find lista final
            //    var db = _dataBase[o.GetType()];
                
            //    //salva na lista final
            //    db.Add(o);
            //}

            
            if (!_dataBase.ContainsKey(o.GetType()))
                _dataBase.Add(o.GetType(),new ArrayList());
            
            
            var list = _dataBase[o.GetType()];

            if (list != null) list.Add(o);
        }

        public void Update(object o)
        {
            //if (_inTransaction)
            //{
            //    //salva numa lista interna
            //    List.Add(o);
            //}
            //else
            //{
            //    //find lista final
            //    var db = _dataBase[o.GetType()];

            //    //salva na lista final
            //    db.Add(o);
            //}
        }

        public void Delete(object o)
        {
            ArrayList list = null;
            if (_dataBase.ContainsKey(o.GetType()))
                list = _dataBase[o.GetType()];

            if (list != null) list.Remove(o);
        }

        /// <summary>
        /// Retrieves all existent objects according to the given example in <paramref name="qbe"/>. 
        /// <para>Not initialized primitive properties as well as boolean and null references are ignored in the comparison.</para></summary>
        /// <typeparam name="T">Type of the given example</typeparam>
        /// <param name="qbe">object used in query by example <see cref="http://en.wikipedia.org/wiki/Query_by_Example"/></param>
        /// <returns>A list containing objects found according to the <paramref name="qbe"/>, if any.</returns>
        public IList<T> Get<T>(object qbe)
        {
            //localiza objeto na lista geral
            //var db = _dataBase[typeof(T)];
            //var o = db.find(key);
           // var o = new object();

            //if (_inTransaction)
            //{
            //    //clona objeto para lista interna
            //    var a =  o.MemberwiseClone();
            //    var b = o;
            //    o = a;
            //    List.Add(o);
            //}

            
            ArrayList specificTypeList = null;
            if (_dataBase.ContainsKey(typeof(T)))
                specificTypeList = _dataBase[typeof(T)];

            var matchedItemsList = new List<T>();
            var type = typeof (T);
            var properties = type.GetProperties();

            foreach (var item in specificTypeList)
            {
                if(exampleMatchesItem(item,properties,qbe))
                {
                    matchedItemsList.Add((T)item);
                }
            }


            return matchedItemsList;
        }


        /// <summary>
        /// Compares <paramref name="qbe"/> against <paramref name="item"/> 
        /// </summary>
        /// <param name="item">The instance to compare to</param>
        /// <param name="typeProperties">Properties of the <paramref name="qbe"/> and <paramref name="item"/> reference Type.</param>
        /// <param name="qbe">The Query by example object to compare from</param>
        /// <returns>true when all <paramref name="qbe"/> properties' values are equal to item's properties. False otherwise.</returns>
        private bool exampleMatchesItem(object item, PropertyInfo[] typeProperties, object qbe)
        {
            var ok = false;

            foreach (var property in typeProperties)
            {
                
                var qbeValue = property.GetValue(qbe, BindingFlags.Default, null, null, null);

                //ignore all these non initialized properties, as well as boolean ones
                if(qbeValue == null || qbeValue is bool || qbeValue.Equals(0) || qbeValue.Equals(""))
                    continue;

                var itemValue = property.GetValue(item, BindingFlags.Default, null, null, null);
                ok = qbeValue.Equals(itemValue);
                if (!ok)
                    break;
            }

            return ok;

        }

        public IList<T> Get<T>()
        {
            var list = new List<T>();

            //retorna todos os objetos do tipo q estiverem na database
            if (_dataBase.ContainsKey(typeof(T)))
            {
                list.AddRange(from object item in _dataBase[typeof (T)] select (T) item);
            }

            return list;
        }
    }
}