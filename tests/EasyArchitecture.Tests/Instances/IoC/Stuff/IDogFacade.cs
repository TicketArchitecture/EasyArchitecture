namespace EasyArchitecture.Tests.Instances.IoC.Stuff
{
    public interface IDogFacade
    {
        DogDto GetDog(DogDto dog);
        DogDto CreateDog(DogDto dog);
        void UpdateDog(DogDto dog);
    }
}
