using System.Collections.Generic;
using System.Linq;
using EasyArchitecture.Data;
using Application4Test.Application.Contracts.DTOs;

namespace Application4Test.Application.Queriers
{
    public class DogQuerier : NHibernateQuerier
    {
        public List<DogDto> GetAllOldDogs(int age)
        {
            var query = CreateSqlQuery("select Id, Age, Name from Dog where age < :age");
            query.SetParameter("age", age);

            query.SetResultTransformer(new GenericResultTransformer<DogDto>(
                               tuple => new DogDto
                               {
                                   Id = (long)tuple[0],
                                   Age = (int)tuple[1],
                                   Name = (string)tuple[2]
                               }));

            return query.List<DogDto>().ToList();
        }
    }
}
