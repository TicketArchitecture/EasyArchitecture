using System.Collections.Generic;
using System.Linq;
using EasyArchitecture.Mechanisms.Persistence;
using Exemplo.Produto.Domain.Repositories;

namespace Exemplo.Produto.Tests.Repositories
{
    public class ProdutoMemoryRepository : Repository<Domain.Entities.Produto>, IProdutoRepository
    {
        public override void Save(Domain.Entities.Produto entity)
        {
            var elements = base.Get();
            entity.Id = (elements.Count > 0 ? elements.Max(e => e.Id) : 0) + 1;
            base.Save(entity);
        }

        public IList<Domain.Entities.Produto> ObterProdutosCadastradosAteHoje()
        {
            return base.Get();
        }
    }

}
