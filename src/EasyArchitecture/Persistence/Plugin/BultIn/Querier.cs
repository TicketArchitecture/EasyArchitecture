using System.Collections.Generic;
using EasyArchitecture.Configuration.Instance;

namespace EasyArchitecture.Persistence.Plugin.BultIn
{
    public abstract class Querier<T>
    {
        //public abstract IList<T> Execute(string namedQuery, params object[] @params);
        public IList<T> Execute(string namedQuery, params object[] @params)
        {
            //TODO: por reflection executar o metodo namedQuery, passando parametrosd

            return null;
        }

        protected object GetSession()
        {
            return EasyConfigurations.SelectorByThread().Persistence.GetSession();
        }

    }
}


