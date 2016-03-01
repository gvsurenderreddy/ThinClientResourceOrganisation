using WTS.WorkSuite.Persistence.Framework.Models;
using WTS.WorkSuite.Service.HR.ReferenceData.Generic;
using WTS.WorkSuite.Service.Specification.Domain.HR.ReferenceData.Generic.Base;
using WTS.WorkSuite.Service.Specification.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.Service.Specification.Infrastructure;

namespace WTS.WorkSuite.Service.Specification.Domain.HR.ReferenceData.Generic.GetAll {

    /// <summary>
    ///     Extends the reference data helper fixture by creating a 
    /// new instance of the reference data get all query before each 
    /// test.
    /// </summary>
    /// <inheritdoc/>
    public abstract class GetAll_fixture<P,Q,E,Eb,Er,Eid,Eh> 
                : base_fixture<E,Eb,Er,Eid,Eh> 
      where P   : ReferenceDataDetails 
      where Q   : IReferenceDataGetAll<P>
      where E   : ReferenceDataModel, new()
      where Eb  : ReferenceDataBuilder<E> 
      where Er  : FakeReferenceDataRepository<E> 
      where Eid : ReferenceDataIdentity 
      where Eh  : ReferenceDataHelper<E,Eb,Er,Eid>, new( ) {


        protected override void test_setup() {
            base.test_setup();

            query = DependencyResolver.resolve<Q>(  );
        }

        protected Q query;

    }
}