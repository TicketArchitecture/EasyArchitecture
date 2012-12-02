using System.Collections.Generic;
using System.Linq;
using Application4Test.Application.Contracts.DTOs;
using Application4Test.Application.Queries;
using EasyArchitecture.Data;
using EasyArchitecture.Plugins.NHibernate;

namespace Application4Test.Infrastructure.Queriers
{
   

    public class DogQuerier : NHibernateQuerier<DogDto>
    {
        //TODO: nao gostei desse IF =(
        public override IList<DogDto> Execute(NamedQuery<DogDto> namedQuery)
        {
            if (namedQuery is GetAgedDogs)
                return InternalExecute(namedQuery as GetAgedDogs);

            if (namedQuery is GetAllDogs)
                return InternalExecute(namedQuery as GetAllDogs);


            return null;
        }

        private IList<DogDto> InternalExecute (GetAgedDogs namedQuery)
        {
            var age = namedQuery.Age;

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

        private IList<DogDto> InternalExecute(GetAllDogs namedQuery)
        {

            var query = CreateSqlQuery("select Id, Age, Name from Dog ");

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
