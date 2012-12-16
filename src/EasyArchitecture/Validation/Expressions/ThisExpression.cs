using System.Collections.Generic;
using EasyArchitecture.Runtime;
using EasyArchitecture.Validation.Instance;

namespace EasyArchitecture.Validation.Expressions
{
    public class ThisExpression<T>
    {
        private readonly T _obj;

        internal ThisExpression(T obj)
        {
            _obj = obj;
        }

        public void IsValid()
        {
            //EasyConfigurations.Selector<T>().Validator.IsValid(_obj);
            InstanceProvider.GetInstance<Instance.Validator>().IsValid(_obj);
            //ConfigurationSelector.Selector().ValidatorFactory.GetInstance().IsValid(_obj);
        }

        public IList<string> HasMessages()
        {
            //return  EasyConfigurations.Selector<T>().Validator.GetMessages(_obj);
            //return ConfigurationSelector.Selector().ValidatorFactory.GetInstance().GetMessages(_obj);
            return InstanceProvider.GetInstance<Instance.Validator>().GetMessages(_obj);
        }
    }
}