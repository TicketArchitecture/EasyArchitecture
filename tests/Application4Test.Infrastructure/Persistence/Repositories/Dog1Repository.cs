using Application4Test.Domain;
using Application4Test.Domain.Repositories;
using EasyArchitecture.Plugins.EntityFramework;

namespace Application4Test.Infrastructure.Persistence.Repositories
{
    public class Dog1Repository : EntityRepository<Dog>, IDogRepository
    {


    }
}