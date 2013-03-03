using System;
using System.Collections.Generic;
using System.Linq;
using EasyArchitecture.Mechanisms.Persistence;
using Exemplo.Produto.Domain.Repositories;

namespace Exemplo.Produto.Infrastructure.Repositories
{
    public class ProdutoRepository : Repository<Domain.Entities.Produto>, IProdutoRepository
    {
        public IList<Domain.Entities.Produto> ObterProdutosCadastradosAteHoje()
        {
            return base.Get().Where(p=>p.DataCadastro< DateTime.Today).ToList();
        }
    }
}