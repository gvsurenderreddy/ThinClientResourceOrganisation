using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.Queries.GetResourceAllocationsByShiftCalendarPattern;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listItem;

namespace WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatedResources.listReport
{
    public class GetAllocatedResources :IGetAllocatedResources
    {
        public IEnumerable<ShiftCalendarPatternResource> execute(ShiftCalendarPatternIdentity request)
        {
            var get_resource_allocations = by_shift_calendar_pattern.execute(request);

            var create_merge_request = new MergeResourcesAndEmployeesRequest(get_resource_allocations.result,
                list_report_query.execute());

            var shift_calendar_pattern_resources = resources_and_employees_merge.execute(create_merge_request);
            return shift_calendar_pattern_resources;
        }

        public GetAllocatedResources(IGetResourceAllocationsByShiftCalendarPattern by_shift_calendar_pattern
                                    , ResourcesAndEmployeesMerge resources_and_employees_merge
                                    , AllocatedResourcesListReport list_report_query)
        {
            this.list_report_query = Guard.IsNotNull(list_report_query, "list_report_query");
            this.resources_and_employees_merge = Guard.IsNotNull(resources_and_employees_merge,
                "resources_and_employees_merge");
            this.by_shift_calendar_pattern = Guard.IsNotNull(by_shift_calendar_pattern, "by_shift_calendar_pattern");

        }

        private readonly AllocatedResourcesListReport list_report_query;
        private readonly IGetResourceAllocationsByShiftCalendarPattern by_shift_calendar_pattern;
        private readonly ResourcesAndEmployeesMerge resources_and_employees_merge;
    }
}
