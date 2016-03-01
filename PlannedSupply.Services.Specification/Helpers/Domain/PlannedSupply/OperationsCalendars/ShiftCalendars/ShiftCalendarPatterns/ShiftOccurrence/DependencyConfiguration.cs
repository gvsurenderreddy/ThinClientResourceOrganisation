using Ninject;
using Ninject.Activation;
using System;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.Ninject.Configuration;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot.FindOrCreate;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.Edit;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.EditAll;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.New;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.NewFromTemplate;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.AggregateRoot.FindOrCreate;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Edit;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.EditAll;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.New;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.NewFromTemplate;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.Remove;
using WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.RemoveAll;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ShiftOccurrence
{
    public class DependencyConfiguration : ADependencyConfiguration
    {
        public override void configure(IKernel kernel, Func<IContext, object> scope)
        {
            kernel
                .Rebind<IRequestHelper<NewShiftOccurrenceFromShiftTemplateRequest>, NewShiftOccurrenceFromShiftTemplateRequestHelper>()
                .To<NewShiftOccurrenceFromShiftTemplateRequestHelper>();

            kernel
                .Rebind<IRequestHelper<ShiftOccurrenceIdentity>
                                       , RemoveShiftOccurrenceRequestHelper>()
                .To<RemoveShiftOccurrenceRequestHelper>()
                ;

            kernel
                .Rebind<IRequestHelper<ShiftOccurrenceIdentity>
                                       , RemoveAllShiftOccurrenceRequestHelper>()
                .To<RemoveAllShiftOccurrenceRequestHelper>()
                ;


            kernel
                .Rebind<IQueryRepository<TimeAllocation>
                                         , IEntityRepository<TimeAllocation>
                                         , FakeTimeAllocationRepository>()
               .To<FakeTimeAllocationRepository>()
               .InScope(x => scope);

            kernel.
               Rebind<IRequestHelper<NewShiftOccurrenceRequest>
                                     , NewShiftOccurrenceRequestHelper>()
              .To<NewShiftOccurrenceRequestHelper>();

            kernel
                .Rebind<IRequestHelper<EditSingleShiftOccurrenceRequest>
                                       , EditSingleShiftOccurrenceRequestHelper>()
               .To<EditSingleShiftOccurrenceRequestHelper>();

            kernel
               .Rebind<IRequestHelper<EditAllShiftOccurrencesRequest>
                                      , EditAllShiftOccurrenceRequestHelper>()
              .To<EditAllShiftOccurrenceRequestHelper>();


            kernel
               .Rebind<IRequestHelper<FindOrCreateAndReturnTimeAllocationRequest>
                                      , FindOrCreateAndReturnTimeAllocationRequestHelper>()
              .To<FindOrCreateAndReturnTimeAllocationRequestHelper>();

        }
    }
}