using System.Collections.Generic;
namespace Application4Test.Domain.Repositories
{
    public interface IDogRepository
    {
        void Save(Dog dog);
        Dog Get(int id);
        void Update(Dog dog);
        IList<Dog> Get(Dog dog);
    }
}
