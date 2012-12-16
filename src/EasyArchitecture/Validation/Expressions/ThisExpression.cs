using System.Collections.Generic;
using EasyArchitecture.Runtime;

namespace EasyArchitecture.Validation.Expressions
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
            InstanceProvider.GetInstance<Instance.Validator>().IsValid(_entity);
        }

        public IList<string> HasMessages()
        {
            return InstanceProvider.GetInstance<Instance.Validator>().GetMessages(_entity);
        }
    }
}