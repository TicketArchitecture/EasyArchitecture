using System.Collections.Generic;
using EasyArchitecture.Configuration.Instance;

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
            EasyConfigurations.SelectorByThread().Validator.IsValid(_obj);
        }

        public IList<string> HasMessages()
        {
            //return  EasyConfigurations.Selector<T>().Validator.GetMessages(_obj);
            return EasyConfigurations.SelectorByThread().Validator.GetMessages(_obj);
        }
    }
}