using System.Linq;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries {

    public abstract class GetDetailsOfASpecificReferenceData<D, E>
                            : IGetDetailsOfASpecificReferenceData<D>
                    where D : ReferenceDataDetails, new( )
                    where E : ReferenceDataModel {


        public Response<D> execute 
                            ( ReferenceDataIdentity request ) {

            var title = repository
                .Entities
                .Single( e => e.id == request.id )
                ;

            return new Response<D> {
                result = new D {
                    id = request.id,
                    description = title.description.normalise_for_presentation(),
                    is_hidden = title.is_hidden,
                }
            };
        }

        protected GetDetailsOfASpecificReferenceData 
                        ( IQueryRepository<E> the_repository ) {
            
            repository = Guard.IsNotNull( the_repository, "the_repository" );
        }

        private readonly IQueryRepository<E> repository;
    }

}