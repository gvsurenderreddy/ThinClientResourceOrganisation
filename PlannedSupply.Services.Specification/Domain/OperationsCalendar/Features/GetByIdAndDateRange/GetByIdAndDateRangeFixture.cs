using System;
using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.HR.Employee;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.GetOverRange;
using WTS.WorkSuite.PlannedSupply.ResourceAllocations;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ResourceAllocations;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.PlannedSupply.ShiftCalendarPatterns;
using WTS.WorkSuite.PlannedSupply.TimeAllocationOccurrences;
using WTS.WorkSuite.PlannedSupply.TimeAllocations;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.Features.OperationsCalendarDetails.OperationsCalendarSummary
{
    public class GetByIdAndDateRangeFixture
                        : PlannedSupplySpecification
    {
        protected OperationsCalendarBuilder add_operations_calendar()
        {
            var shift_pattern_builder = new ShiftCalendarPatternBuilder(new ShiftCalendarPattern());
            var shift_calendar_builder = new ShiftCalendarBuilder(new ShiftCalendars.ShiftCalendar());
            var operations_calendar_builder = new OperationsCalendarBuilder(new OperationsCalendars.OperationalCalendar());

            
            shift_pattern_builder.add_occurrence(the_time_allocation_occurrence);

            var resource_allocation_builder = new ResourceAllocationBuilder();
            var resource_allocation = resource_allocation_builder.entity;

            shift_pattern_builder.entity
                .ResourceAllocations
                .Add(resource_allocation)
                ;

            shift_calendar_builder.add_shift_calendar_pattern(shift_pattern_builder.entity);

            operations_calendar_builder.add_shift_calendar(shift_calendar_builder.entity)
                                            .add_time_allocation(the_time_allocation);

            operations_calendar_entity_repository.add(operations_calendar_builder.entity);

            return operations_calendar_builder;
        }

        protected override void test_setup()
        {
            base.test_setup();

            the_start_date_context = DateTime.Now.Date;

            get_operations_calendar_summary = DependencyResolver.resolve<IGetOperationsCalendarAggregateOverRange>();
            operations_calendar_entity_repository = DependencyResolver.resolve<IEntityRepository<OperationsCalendars.OperationalCalendar>>();

            the_time_allocation = new TimeAllocation()
            {
                colour = "A colour",
                duration_in_seconds = 40,
                start_time_in_seconds_from_midnight = 60,
                title = "A time allocation"
            };

            the_time_allocation_occurrence = new TimeAllocationOccurrence()
            {
                start_date = the_start_date_context,
                time_allocation = the_time_allocation
            };
          
        }

        protected DateTime the_start_date_context;

        protected TimeAllocationOccurrence the_time_allocation_occurrence;

        protected TimeAllocation the_time_allocation;

        protected IGetOperationsCalendarAggregateOverRange get_operations_calendar_summary;

        protected IEntityRepository<OperationsCalendars.OperationalCalendar> operations_calendar_entity_repository;

        
    }
}