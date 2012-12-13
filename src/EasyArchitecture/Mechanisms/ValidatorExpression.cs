using System.Collections.Generic;
using EasyArchitecture.Internal;

namespace EasyArchitecture.Mechanisms
{
    public class ValidatorExpression<T>
    {
        private readonly T _obj;

        internal ValidatorExpression(T obj)
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