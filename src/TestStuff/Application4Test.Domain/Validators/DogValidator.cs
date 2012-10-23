using EasyArchitecture.Domain;

namespace Application4Test.Domain.Validators
{
    public class DogValidator:Validator<Dog>
    {
        public DogValidator() {
            AddRule(d => d.Age > 10, "There's no dog so old");
        }
    }
}
