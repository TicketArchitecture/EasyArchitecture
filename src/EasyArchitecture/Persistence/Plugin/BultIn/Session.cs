using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EasyArchitecture.Runtime;

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
        /// Retrieves all existent objects according to the given example.
        /// </summary>
        /// <remarks>Not initialized primitive properties as well as null references are ignored.</remarks>
        /// <typeparam name="T">Type of the given example</typeparam>
        /// <param name="qbe">Query By Example object</param>
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

            
            ArrayList list = null;
            if (_dataBase.ContainsKey(typeof(T)))
                list = _dataBase[typeof(T)];

            var listlistlist = new ArrayList();


           // var dictionary = new Dictionary<string, object>();


//obtem a lista de propriedades/valores, q devem ser usados na comparacao
            var type = typeof (T);
            var properties = type.GetProperties();
            //foreach (var propertyInfo in properties)
            //{
            //    var name = propertyInfo.Name;
            //    var value = propertyInfo.GetValue(key);

            //    if(value!=null)
            //    dictionary.Add(name,value);
            //}


            //compara
            foreach (var item in list)
            {
                //compara o item
                if(exampleMatchesItem(item,properties,qbe))
                {
                    listlistlist.Add(item);
                }
            }

            //if (list != null) return new List<T>((IEnumerable<T>) list);
            var listlistlistlist = new List<T>();
            foreach (var item in listlistlist)
            {
                listlistlistlist.Add((T)item);
                
            }

            return listlistlistlist;
        }

        private bool exampleMatchesItem(object item, PropertyInfo[] typeProperties, object qbe)
        {
            var ok = false;

            foreach (var property in typeProperties)
            {
                
                var qbeValue = property.GetValue(qbe, BindingFlags.Default, null, null, null);

                //ignore all these non initialized properties
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