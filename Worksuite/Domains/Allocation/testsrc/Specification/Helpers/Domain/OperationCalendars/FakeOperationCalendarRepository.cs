using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.Allocation.OperationCalendars;

namespace WTS.WorkSuite.Allocation.Services.Helpers.Domain.OperationCalendars {

    public class FakeOperationCalendarRepository 
                    : FakeEntityRepository<AllocatedOperationCalendar,int>  {

        public FakeOperationCalendarRepository () 
                : base( new IntIdentityProvider<AllocatedOperationCalendar>() ) { }
    }
}