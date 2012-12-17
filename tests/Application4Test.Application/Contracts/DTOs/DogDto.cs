using Application4Test.Domain;

namespace Application4Test.Application.Contracts.DTOs
{
    public class DogDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public long Id  { get; set; }


//not need, just for allow test
        public override bool Equals(object obj)
        {
            var dog = obj as DogDto;

            if (dog == null)
                return false;

            return (
                       dog.Id == this.Id
                       &&
                       dog.Age == this.Age
                       &&
                       dog.Name == this.Name
                   );

        }
    }
}