using EasyArchitecture.Mechanisms.Persistence;
using Exemplo.Produto.Domain.Repositories;

namespace Exemplo.Produto.Infrastructure.Repositories
{
    public class ProdutoRepository : Repository<Domain.Entities.Produto>, IProdutoRepository
    {
    }
}
