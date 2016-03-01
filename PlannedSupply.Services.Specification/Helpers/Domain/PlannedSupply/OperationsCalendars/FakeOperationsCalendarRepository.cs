using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars
{
    public class FakeOperationsCalendarRepository
                        : FakeEntityRepository<WTS.WorkSuite.PlannedSupply.OperationsCalendars.OperationalCalendar, int>
    {
        public FakeOperationsCalendarRepository()
            : base(new IntIdentityProvider<WTS.WorkSuite.PlannedSupply.OperationsCalendars.OperationalCalendar>())
        {
        }
    }
}