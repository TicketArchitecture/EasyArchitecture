using System.Collections.Generic;
using EasyArchitecture.Core;

namespace EasyArchitecture.Mechanisms.Validation.Expressions
{
    public class ThisExpression<T>
    {
        private readonly T _entity;

        internal ThisExpression(T entity)
        {
            _entity = entity;
        }

        public void IsValid()
        {
            InstanceProvider.GetInstance<Instances.Validation.Validator>().IsValid(_entity);
        }

        public IList<string> HasMessages()
        {
            return InstanceProvider.GetInstance<Instances.Validation.Validator>().GetMessages(_entity);
        }
    }
}