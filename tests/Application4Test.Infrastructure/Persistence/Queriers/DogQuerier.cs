using System.Collections.Generic;
using Application4Test.Application.Contracts.DTOs;
using EasyArchitecture.Persistence.Plugin.BultIn;

namespace Application4Test.Infrastructure.Persistence.Queriers
{
    public class DogQuerier:Querier<DogDto>
    {
        public IList<DogDto> GetAllDogs()
        {

            //var query = CreateSqlQuery("select Id, Age, Name from Dog ");

            //query.SetResultTransformer(new GenericResultTransformer<DogDto>(
            //                   tuple => new DogDto
            //                   {
            //                       Id = (long)tuple[0],
            //                       Age = (int)tuple[1],
            //                       Name = (string)tuple[2]
            //                   }));

            //return query.List<DogDto>().ToList();
            return null;

        }

        private IList<DogDto> GetAllOldDogs(params object [] @params)
        {
            //var age = @params[0];

            //var query = CreateSqlQuery("select Id, Age, Name from Dog where age < :age");
            //query.SetParameter("age", age);

            //query.SetResultTransformer(new GenericResultTransformer<DogDto>(
            //                   tuple => new DogDto
            //                   {
            //                       Id = (long)tuple[0],
            //                       Age = (int)tuple[1],
            //                       Name = (string)tuple[2]
            //                   }));

            //return query.List<DogDto>().ToList();
            return null;
        }


    }
}
