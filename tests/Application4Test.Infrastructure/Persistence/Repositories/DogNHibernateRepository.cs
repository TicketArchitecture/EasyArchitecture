using Application4Test.Domain;
using Application4Test.Domain.Repositories;
using EasyArchitecture.Plugins.NHibernate;

namespace Application4Test.Infrastructure.Persistence.Repositories
{
    public class DogNHibernateRepository : NHibernateRepository<Dog>, IDogRepository
    {


    }
}
