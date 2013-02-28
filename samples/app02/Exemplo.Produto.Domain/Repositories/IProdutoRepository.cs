using System.Collections.Generic;
using EasyArchitecture.Mechanisms.Persistence;

namespace Exemplo.Produto.Domain.Repositories
{
    public interface IProdutoRepository : IRepository<Entities.Produto>
    {
        IList<Domain.Entities.Produto> ObterProdutosCadastradosAteHoje();
    }
}
