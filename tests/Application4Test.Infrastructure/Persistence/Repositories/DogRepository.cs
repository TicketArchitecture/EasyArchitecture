using System;
using System.Linq;
using System.Linq.Expressions;
using Application4Test.Domain;
using Application4Test.Domain.Repositories;
using EasyArchitecture.Persistence.Plugin.BultIn;

namespace Application4Test.Infrastructure.Persistence.Repositories
{
    public class DogRepository : MemoryRepository<Dog>, IDogRepository
    {
        public Dog Get(int id)
        {
            Expression<Func<Dog, bool>> predicate =  d => d.Id == id;
            return base.Get(predicate).FirstOrDefault();
        }
    }
}