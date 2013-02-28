﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EasyArchitecture.Plugin.Contracts.Persistence;

namespace EasyArchitecture.Plugin.BultIn.Persistence
{
    public class Persistence : IPersistence
    {
        private bool _inTransaction;
        private readonly Dictionary<Type, ArrayList> _dataBase;

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
            if (!_inTransaction)
                throw new Exception("Transaction not started");

            _inTransaction = false;
        }

        public void RollbackTransaction()
        {
            if (!_inTransaction)
                throw new Exception("Transaction not started");

            _inTransaction = false;
        }

        public void Save(object entity)
        {
            if (!_dataBase.ContainsKey(entity.GetType()))
                _dataBase.Add(entity.GetType(), new ArrayList());

            _dataBase[entity.GetType()].Add(entity);
        }

        public void Update(object entity)
        {
        }

        public void Delete(object entity)
        {
            if (_dataBase.ContainsKey(entity.GetType()))
                _dataBase[entity.GetType()].Remove(entity);
        }

        public IList<T> Get<T>(object example)
        {
            var type = typeof(T);
            var properties = type.GetProperties();

            if (!_dataBase.ContainsKey(type))
                return new List<T>();
            
            var specificTypeList = _dataBase[typeof (T)];
            return
                (from object item in specificTypeList
                 where ExampleMatchesItem(item, properties, example)
                 select (T) item).ToList();
        }

        private static bool ExampleMatchesItem(object item, IEnumerable<PropertyInfo> typeProperties, object example)
        {
            return !(from property in typeProperties let exampleValue = property.GetValue(example, BindingFlags.Default, null, null, null) where exampleValue != null && !(exampleValue is bool) && !exampleValue.Equals(0) && !exampleValue.Equals(string.Empty) let itemValue = property.GetValue(item, BindingFlags.Default, null, null, null) where !exampleValue.Equals(itemValue) select exampleValue).Any();
        }

        public IList<T> Get<T>()
        {
            var list = new List<T>();

            if (_dataBase.ContainsKey(typeof(T)))
            {
                list.AddRange(from object item in _dataBase[typeof(T)] select (T)item);
            }

            return list;
        }

        public object GetUnderlayerPersistenceObject()
        {
            throw new NotImplementedException();
        }
    }
}
