using Application4Test.Domain;
using Application4Test.Domain.Repositories;
using EasyArchitecture.Plugins.NHibernate;

namespace Application4Test.Infrastructure.Repositories
{
    public class DogRepository : NHibernateRepository<Dog>, IDogRepository
    {


    }
}
