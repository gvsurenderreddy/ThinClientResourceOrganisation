using System;
using Ninject;
using Ninject.Activation;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.ApplyFromTemplate;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.ShiftBreaks.Remove;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.ApplyFromTemplate;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.EditShiftBreak;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.NewShiftBreak;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks.Features.RemoveShiftBreak;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ShiftOccurrence.ShiftBreaks
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Rebind<IRequestHelper<ApplyShiftBreaksFromBreakTemplateRequest>, ApplyShiftBreaksFromBreakTemplateRequestHelper>()
                .To<ApplyShiftBreaksFromBreakTemplateRequestHelper>();

            kernel
                .Rebind<IRequestHelper<NewShiftBreakRequest>, NewShiftBreakRequestHelper>()
                .To<NewShiftBreakRequestHelper>();

            kernel
                .Rebind<IRequestHelper<EditShiftBreakRequest>, EditShiftBreakRequestHelper>()
                .To<EditShiftBreakRequestHelper>();

            kernel
                .Rebind<IRequestHelper<RemoveShiftBreakRequest>, RemoveShiftBreakRequestHelper>()
                .To<RemoveShiftBreakRequestHelper>();
        }
    }
}