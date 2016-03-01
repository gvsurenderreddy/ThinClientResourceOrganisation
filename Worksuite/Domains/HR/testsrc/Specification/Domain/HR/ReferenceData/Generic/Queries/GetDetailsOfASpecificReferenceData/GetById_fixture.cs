using WTS.WorkSuite.Persistence.Framework.Models;
using WTS.WorkSuite.Service.Framework.Responses;
using WTS.WorkSuite.Service.HR.ReferenceData.Generic;
using WTS.WorkSuite.Service.Specification.Domain.HR.ReferenceData.Generic.Base;
using WTS.WorkSuite.Service.Specification.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Service.Specification.Infrastructure;

namespace WTS.WorkSuite.Service.Specification.Domain.HR.ReferenceData.Generic.GetById {

    public abstract class GetById_fixture<I,P,Q,E,Eb,Er,Eh> 
                : base_fixture<E,Eb,Er,I,Eh> 
      where I   : ReferenceDataIdentity, new()
      where P   : ReferenceDataDetails 
      where Q   : IReferenceDataGetById<P>
      where E   : ReferenceDataModel, new()
      where Eb  : ReferenceDataBuilder<E> 
      where Er  : FakeReferenceDataRepository<E>  
      where Eh  : ReferenceDataHelper<E,Eb,Er,I>, new( )  {

        protected override void test_setup ( ) {
            base.test_setup( );

            query = DependencyResolver.resolve<Q>( );
            builder = helper.add( );
        }

        protected Eb add_entity ( ) {
            return helper.add(  );
        }

        protected Response<P> execute_query ( E entity ) {
            return query.execute( new I {id = entity.id} );
        }


        protected Eb builder;
        protected Q query;
    }

}