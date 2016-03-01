using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.GetDetailsById;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.Features.New;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns
{
    public class DependencyConfiguration
                        : ADependencyConfiguration
    {
        public override void configure(IKernel kernel,
                                        Func<IContext, object> scope
                                      )
        {
            kernel
                .Rebind<IQueryRepository<ShiftCalendarPattern>,
                    IEntityRepository<ShiftCalendarPattern>,
                    FakeShiftCalendarPatternRepository
                    >()
                .To<FakeShiftCalendarPatternRepository>()
                .InScope(x => scope)
                ;

            kernel
                .Rebind<IRequestHelper<NewShiftCalendarPatternRequest>,
                    NewShiftCalendarPatternRequestHelper
                    >()
                .To<NewShiftCalendarPatternRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<UpdateShiftCalendarPatternRequest>,
                    UpdateShiftCalendarPatternRequestHelper
                    >()
                .To<UpdateShiftCalendarPatternRequestHelper>()
                ;
        }
    }
}