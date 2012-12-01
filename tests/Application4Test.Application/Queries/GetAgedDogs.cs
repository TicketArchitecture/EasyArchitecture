using Application4Test.Application.Contracts.DTOs;
using EasyArchitecture.Data;

namespace Application4Test.Application.Queries
{
    public class GetAgedDogs : NamedQuery<DogDto>//TODO: analisar specifications que recebam parameters[]
    {
        public int Age { get; private set; }

        public GetAgedDogs(int age)
        {
            Age = age;
        }
    }
}