using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries {

    /// <summary>
    ///     Generic ReferenceData GetAll query
    /// </summary>
    public abstract class GetDetailsOfAllReferenceData<E,Q> 
                            : IGetDetailsOfAllReferenceData<Q>
                    where E : ReferenceDataModel 
                    where Q : ReferenceDataDetails, new() {


        public Response<IEnumerable<Q>> execute ( ) {

            return new Response<IEnumerable<Q>> {

                result = repository
                            .Entities
                            .OrderBy( m => m.description )
                            // from this point treat as enumerable 
                            // as we are using extension methods 
                            // that can not be converted to a query
                            // language in the projection 
                            .AsEnumerable()
                            .Select( t => new Q {
                              id  = t.id,
                              description = t.description.normalise_for_presentation(),
                              is_hidden = t.is_hidden,
                            }),
            };
        }

        protected GetDetailsOfAllReferenceData 
                    ( IQueryRepository<E> the_repository ) {

            Guard.IsNotNull( the_repository, "the_repository" );

            repository = the_repository;
        }

        // entity repository that the result are mapped from
        private readonly IQueryRepository<E> repository;
    }
}