using System;
using System.Collections.Generic;
using EasyArchitecture.Mechanisms.Persistence;
using Exemplo.Produto.Domain.Repositories;
using NHibernate;
using NHibernate.Criterion;

namespace Exemplo.Produto.Infrastructure.Repositories
{
    public class ProdutoRepository : Repository<Domain.Entities.Produto>, IProdutoRepository
    {
        public IList<Domain.Entities.Produto> ObterProdutosCadastradosAteHoje()
        {
            var session = (ISession) base.GetUnderlayerPersistence();
            return session.CreateCriteria<Domain.Entities.Produto>()
                .Add(Restrictions.Lt("DataCadastro", DateTime.Today ))
                .List<Produto.Domain.Entities.Produto>();
        }
    }
}
