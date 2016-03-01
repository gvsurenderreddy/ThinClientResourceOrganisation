using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.HR.Framework.Models;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic {

    public class ReferenceDataHelper<E,Eb,Er>
                 : EnityHelper<E,int,Eb,Er> 
        where E  : ReferenceDataModel 
        where Eb : IEntityBuilder<E> 
        where Er : FakeReferenceDataRepository<E> {

    }
}