using Application4Test.Domain;
using Application4Test.Domain.Repositories;
using EasyArchitecture.Plugins.Default.Persistence;

namespace Application4Test.Infrastructure.Persistence.Repositories
{
    public class DogMemoryRepository : MemoryRepository<Dog>, IDogRepository
    {


    }
}