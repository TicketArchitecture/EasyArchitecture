using Application4Test.Application.Contracts.DTOs;
using EasyArchitecture.Common.Persistence;

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