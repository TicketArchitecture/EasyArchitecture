using EasyArchitecture.Mechanisms.Persistence;
using Exemplo.Produto.Domain.Repositories;

namespace Exemplo.Produto.Infrastructure.Repositories
{
    public class FornecedorRepository : Repository<Domain.Entities.Fornecedor>,IFornecedorRepository
    {
    }
}