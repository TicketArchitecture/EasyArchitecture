using EasyArchitecture.Mechanisms.Persistence;
using Exemplo.Produto.Domain.Repositories;

namespace Exemplo.Produto.Infrastructure.Repositories
{
    public class CategoriaRepository : Repository<Domain.Entities.Categoria>, ICategoriaRepository
    {
    }
}