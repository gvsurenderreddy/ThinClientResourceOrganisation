using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.Publish;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.GetDetailsById;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.Features.Publish;
using WTS.WorkSuite.PlannedSupply.ShiftCalendars;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Rebind<IQueryRepository<ShiftCalendar>,
                    IEntityRepository<ShiftCalendar>,
                    FakeShiftCalendarRepository
                    >()
                .To<FakeShiftCalendarRepository>()
                .InScope(x => scope)
                ;

            kernel
                .Rebind<IRequestHelper<NewShiftCalendarRequest>,
                    NewShiftCalendarRequestHelper
                    >()
                .To<NewShiftCalendarRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<UpdateShiftCalendarRequest>,
                    UpdateShiftCalendarRequestHelper
                    >()
                .To<UpdateShiftCalendarRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<ShiftCalendarIdentity>,
                        ShiftCalendarIdentityRequestHelper>()
                .To<ShiftCalendarIdentityRequestHelper>();

            kernel
                .Rebind<IRequestHelper<PublishShiftCalendarRequest>,
                        PublishDatesShiftCalendarRequestHelper>()
                .To<PublishDatesShiftCalendarRequestHelper>();


            
        }
    }
}