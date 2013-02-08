using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EasyArchitecture.Persistence.Plugin.Contracts;

namespace EasyArchitecture.Persistence.Plugin.BultIn
{
    public class Persistence : IPersistence
    {
        private bool _inTransaction;
        public ArrayList List = new ArrayList();
        private readonly Dictionary<Type, ArrayList> _dataBase;
        private readonly Dictionary<Type, ArrayList> _localDataBase;


        public Persistence(Dictionary<Type, ArrayList> dataBase)
        {
            _dataBase = dataBase;
        }

        public void BeginTransaction()
        {
            _inTransaction = true;
        }

        public void CommitTransaction()
        {
            //copia da lista temp para lista final
            if (!_inTransaction)
                throw new NotInTransactionException();

            //marca transacao como finalizada
            _inTransaction = false;
        }

        public void RollbackTransaction()
        {

            if (!_inTransaction)
                throw new NotInTransactionException();
            //destroi lista
            //if(_inTransaction)
            //    List.Clear();

            //marca transacao como finalizada
            _inTransaction = false;
        }

        public void Save(object entity)
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


            if (!_dataBase.ContainsKey(entity.GetType()))
                _dataBase.Add(entity.GetType(), new ArrayList());


            var list = _dataBase[entity.GetType()];

            if (list != null) list.Add(entity);
        }

        public void Update(object entity)
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

        public void Delete(object entity)
        {
            ArrayList list = null;
            if (_dataBase.ContainsKey(entity.GetType()))
                list = _dataBase[entity.GetType()];

            if (list != null) list.Remove(entity);
        }

        /// <summary>
        /// Retrieves all existent objects according to the given example in <paramref name="example"/>. 
        /// <para>Not initialized primitive properties as well as boolean and null references are ignored in the comparison.</para></summary>
        /// <typeparam name="T">Type of the given example</typeparam>
        /// <param name="example">object used in query by example <see cref="http://en.wikipedia.org/wiki/Query_by_Example"/></param>
        /// <returns>A list containing objects found according to the <paramref name="example"/>, if any.</returns>
        public IList<T> Get<T>(object example)
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

            var type = typeof(T);
            var properties = type.GetProperties();

            return (from object item in specificTypeList where ExampleMatchesItem(item, properties, example) select (T)item).ToList();
        }


        /// <summary>
        /// Compares <paramref name="example"/> against <paramref name="item"/> 
        /// </summary>
        /// <param name="item">The instance to compare to</param>
        /// <param name="typeProperties">Properties of the <paramref name="example"/> and <paramref name="item"/> reference Type.</param>
        /// <param name="example">The Query by example object to compare from</param>
        /// <returns>true when all <paramref name="example"/> properties' values are equal to item's properties. False otherwise.</returns>
        private static bool ExampleMatchesItem(object item, IEnumerable<PropertyInfo> typeProperties, object example)
        {
            var ok = false;

            foreach (var property in typeProperties)
            {
                var exampleValue = property.GetValue(example, BindingFlags.Default, null, null, null);

                //ignore all these non initialized properties, as well as boolean ones
                if (exampleValue == null || exampleValue is bool || exampleValue.Equals(0) || exampleValue.Equals(string.Empty))
                    continue;

                var itemValue = property.GetValue(item, BindingFlags.Default, null, null, null);
                ok = exampleValue.Equals(itemValue);
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
                list.AddRange(from object item in _dataBase[typeof(T)] select (T)item);
            }

            return list;
        }

    }
}
