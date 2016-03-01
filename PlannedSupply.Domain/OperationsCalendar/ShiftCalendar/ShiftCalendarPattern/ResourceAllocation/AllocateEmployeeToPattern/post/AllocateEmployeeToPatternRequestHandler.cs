using System;
using System.Collections.Generic;
using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.PlannedSupply.HR.Employee;
using WTS.WorkSuite.PlannedSupply.OperationsCalendars;

namespace WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ResourceAllocation.AllocateEmployeeToPattern.post
{
    public class AllocateEmployeeToPatternRequestHandler : IAllocateEmployeeToPatternRequestHandler
    {
        public AllocateEmployeeToPatternResponse execute(AllocateEmployeeToPatternRequest the_allocate_resource_request)
        {
            return this
                .set_request( the_allocate_resource_request )
                .find_operational_calendar( )
                .find_employee( )
                .find_shift_calendar( )
                .find_shift_calendar_pattern( )
                .remove_resource_from_other_patter_if_already_allocated( )
                .allocate_resource_to_pattern( )
                .commit( )
                .build_response( );
        }

        private AllocateEmployeeToPatternRequestHandler set_request( AllocateEmployeeToPatternRequest the_allocate_resource_request )
        {
            _new_allocate_resource_request = Guard.IsNotNull( the_allocate_resource_request, "the_allocate_resource_request" );

            _response_builder = new ResponseBuilder<ResourceAllocationIdentity, AllocateEmployeeToPatternResponse>();

            _response_builder
                        .set_response(new ResourceAllocationIdentity
                        {
                            resource_allocation_id = Null.Id
                        });

            return this;
        }

        private bool response_builder_has_errors( )
        {
            return _response_builder.has_errors;
        }

        private AllocateEmployeeToPatternRequestHandler find_operational_calendar( )
        {
            if ( response_builder_has_errors( ) ) return this;

            Guard.IsNotNull( _new_allocate_resource_request, "_new_allocate_resource_request" );
            Guard.IsNotNull( _operational_calendar_repository, "_operational_calendar_repository" );

            _operational_calendar = _operational_calendar_repository
                                            .Entities
                                            .Single( oc => oc.id == _new_allocate_resource_request.operations_calendar_id )
                                            ;

            return this;
        }

        private AllocateEmployeeToPatternRequestHandler find_employee( )
        {
             if ( response_builder_has_errors( ) ) return this;

            Guard.IsNotNull( _new_allocate_resource_request, "_new_allocate_resource_request" );
            Guard.IsNotNull( _operational_calendar, "_operational_calendar" );

            _employee =
                _employee_planned_supply_repository.Entities.Single( e => e.employee_id == _new_allocate_resource_request.employee_id );

            return this;
        }

        private AllocateEmployeeToPatternRequestHandler find_shift_calendar( )
        {
            if ( response_builder_has_errors( ) ) return this;

            Guard.IsNotNull( _new_allocate_resource_request, "_new_allocate_resource_request" );
            Guard.IsNotNull( _operational_calendar, "_operational_calendar" );

             _shift_calendar = _operational_calendar
                                    .ShiftCalendars
                                    .Single( sc => sc.id == _new_allocate_resource_request.shift_calendar_id )
                                    ;

            return this;
        }

        private AllocateEmployeeToPatternRequestHandler find_shift_calendar_pattern( )
        {
            if ( response_builder_has_errors( ) ) return this;

            Guard.IsNotNull( _new_allocate_resource_request, "_new_allocate_resource_request" );
            Guard.IsNotNull( _operational_calendar, "_operational_calendar" );

            _shift_calendar_pattern = _shift_calendar
                                        .ShiftCalendarPatterns
                                        .Single( sc => sc.id == _new_allocate_resource_request.shift_calendar_pattern_id );

            return this;
        }

        private AllocateEmployeeToPatternRequestHandler remove_resource_from_other_patter_if_already_allocated( )
        {
            if ( response_builder_has_errors( ) ) return this;

            Guard.IsNotNull( _new_allocate_resource_request, "_new_allocate_resource_request" );
            Guard.IsNotNull( _operational_calendar, "_operational_calendar" );

            //Unallocate it and allocate to different pattern if they are on same shift calendar.

            var resource_allocated = _operational_calendar_repository
                .Entities
                .Where( op => op.id == _new_allocate_resource_request.operations_calendar_id )
                .SelectMany( op => op.ShiftCalendars )
                .Where( sc => sc.id == _new_allocate_resource_request.shift_calendar_id )
                .SelectMany( sc => sc.ShiftCalendarPatterns )
                .SelectMany( scp => scp.ResourceAllocations
                    .Where( r=>r.employee.employee_id == _new_allocate_resource_request.employee_id )
                    .Select( ra => new ResourceAllocationIdentity
                    {
                        resource_allocation_id = ra.id,
                        operations_calendar_id = _new_allocate_resource_request.operations_calendar_id,
                        shift_calendar_id = _new_allocate_resource_request.shift_calendar_id,
                        shift_calendar_pattern_id = scp.id
                    }
                    ));
           
            if ( resource_allocated.Any( ) )
            {
               remove_resource_allocation_for_shift_pattern.execute( resource_allocated.First( ) );
            }
            return this;
        }

        private AllocateEmployeeToPatternRequestHandler allocate_resource_to_pattern( )
        {
            Guard.IsNotNull( _new_allocate_resource_request, "_new_allocate_resource_request" );
            Guard.IsNotNull( _operational_calendar, "_operational_calendar" );

            _resource = new ResourceAllocations.ResourceAllocation
            {
                created_date = DateTime.Now,
                employee = _employee
            };
            _shift_calendar_pattern.ResourceAllocations.Add( _resource );

            return this;

        }

        private AllocateEmployeeToPatternRequestHandler commit( )
        {
            if ( response_builder_has_errors( ) ) return this;
            
            _unit_of_work.Commit( );

            return this;
        }

        private AllocateEmployeeToPatternResponse build_response()
        {
            if ( response_builder_has_errors( ) )
            {
                _response_builder.add_errors( new List<string> { WarningMessages.warning_2301151309 } );
            }
            else
            {
                _response_builder.add_message(ConfirmationMessages.confirmation_2302151303 );
                _response_builder
                    .set_response( new ResourceAllocationIdentity
                    {
                        resource_allocation_id = _resource.id
                    });
            }
            return _response_builder.build( );
        }

        public AllocateEmployeeToPatternRequestHandler( IEntityRepository<OperationalCalendar> the_operational_calendar_repository
                                        , IEntityRepository<EmployeePlannedSupply> the_employee_planned_supply_repository
                                        , IUnitOfWork the_unit_of_work
                                        , AggregateRoot.RemoveResourceAllocation the_remove_resource_allocation_for_shift_pattern )
        {
            _operational_calendar_repository = Guard.IsNotNull( the_operational_calendar_repository, "the_operational_calendar_repository" );
            _employee_planned_supply_repository = Guard.IsNotNull( the_employee_planned_supply_repository, "the_employee_planned_supply_repository" );
            _unit_of_work = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );

            remove_resource_allocation_for_shift_pattern = Guard.IsNotNull( the_remove_resource_allocation_for_shift_pattern, "the_remove_resource_allocation_for_shift_pattern");
        }


        private readonly IEntityRepository<OperationalCalendar>
           _operational_calendar_repository;

        private readonly IEntityRepository<EmployeePlannedSupply>
          _employee_planned_supply_repository;

        private readonly AggregateRoot.RemoveResourceAllocation remove_resource_allocation_for_shift_pattern;

        private OperationalCalendar _operational_calendar;
        private ShiftCalendars.ShiftCalendar _shift_calendar;
        private ShiftCalendarPatterns.ShiftCalendarPattern _shift_calendar_pattern;
        private ResourceAllocations.ResourceAllocation _resource;
        private EmployeePlannedSupply _employee;

        private ResponseBuilder<ResourceAllocationIdentity, AllocateEmployeeToPatternResponse> _response_builder;
        private AllocateEmployeeToPatternRequest _new_allocate_resource_request;
        private readonly IUnitOfWork _unit_of_work;
       
    }
}
