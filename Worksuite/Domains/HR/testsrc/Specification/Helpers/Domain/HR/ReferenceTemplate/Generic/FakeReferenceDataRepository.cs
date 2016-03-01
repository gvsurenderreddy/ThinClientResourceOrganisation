using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic {

    public class FakeReferenceDataRepository<E> 
                : FakeEntityRepository<E,int> 
        where E : BaseEntity<int> {

        public FakeReferenceDataRepository() : base( new IntIdentityProvider<E>() ){ }

    }
}