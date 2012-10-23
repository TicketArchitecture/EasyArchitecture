namespace Application4Test.Domain.Repositories
{
    public interface IDogRepository
    {
        void CreateDog(Dog dog);
        Dog GetDog(Dog dog);
        void UpdateDog(Dog dog);
    }
}
