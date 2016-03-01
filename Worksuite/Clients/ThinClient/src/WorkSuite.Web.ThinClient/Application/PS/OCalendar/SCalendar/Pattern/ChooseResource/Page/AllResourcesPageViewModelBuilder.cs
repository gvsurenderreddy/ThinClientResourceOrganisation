using System.Collections.Generic;
using System.Globalization;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableFieldMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableModelMetadataRepository;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.ThinClient.Query.Application.PlannedSupply.OperationsCalendar.ShiftCalendars.Patterns.Allocations.AllocatableResources.tableItem;
using WTS.WorkSuite.Web.ThinClient.Application.Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.AllResources.get;

namespace WTS.WorkSuite.Web.ThinClient.Application.Ops.OpCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.allResources.get
{
    public class AllResourcesPageViewModelBuilder
    {
        public AllResourcesPageViewModelBuilder add_table_list_element
                       (IEnumerable<EmployeeWithAllocationStatus> employees)
        {

            return this
                    .set_employees(employees)
                    .define_table_model()
                    .define_table_rows()
                    ;
        }

        public IsAViewElement build()
        {
            Guard.IsNotNull(employees, "employees");

            return table_builder.build(employees);
        }

        public AllResourcesPageViewModelBuilder
                ( ITableModelMetadataBuilder<EmployeeWithAllocationStatus> table_model_metadata_builder
                , ITableFieldsMetadataBuilder<EmployeeWithAllocationStatus> table_field_metadata_builder
                , TableBuilder<EmployeeWithAllocationStatus> table_builder ) {

            this.table_model_metadata_builder = Guard.IsNotNull( table_model_metadata_builder, "table_model_metadata_builder" );
            this.table_field_metadata_builder = Guard.IsNotNull( table_field_metadata_builder, "table_field_metadata_builder" );
            this.table_builder = Guard.IsNotNull(  table_builder, "table_builder" );
        }

        private AllResourcesPageViewModelBuilder set_employees
                                                   (IEnumerable<EmployeeWithAllocationStatus> employees)
        {
            this.employees = Guard.IsNotNull( employees, "employees" );
            return this;
        }

        private AllResourcesPageViewModelBuilder define_table_model ( ) { 

            table_model_metadata_builder
                .id( Resources.page_id )
                .field_id_extension( employee_detail => employee_detail.employee_id.ToString( CultureInfo.InvariantCulture ))
                .row_details_route_id(Operations.OperationalCalendars.PlannedSupply.ShiftCalendars.Patterns.Allocations.ConfirmAllocation.get.Resources.page_id)
                .row_details_route_pramameter_factory(e => new { e.operations_calendar_id, e.shift_calendar_id, e.shift_calendar_pattern_id, e.employee_id })
                ;
            
            return this;
        }

        private AllResourcesPageViewModelBuilder define_table_rows()
        {
            table_field_metadata_builder
                .for_field(m => m.forename)
                .id("forename")
                .lable("Forename")
                ;

            table_field_metadata_builder
                .for_field(m => m.surname)
                .id("surname")
                .lable("Surname")
                ;

            table_field_metadata_builder
                .for_field(m => m.employee_reference)
                .id("employeeReference")
                .lable("Employee reference")
                ;

            table_field_metadata_builder
                .for_field(m => m.location)
                .id("location")
                .lable("Location")
                ;

            table_field_metadata_builder
                .for_field(m => m.job_title)
                .id("job_title")
                .lable("Job title")
                ;

            table_field_metadata_builder
                .for_field(m => m.status)
                .id("allocation_status")
                .lable("Status")
                ;

            return this;

        }

        private IEnumerable<EmployeeWithAllocationStatus> employees;

        private readonly ITableModelMetadataBuilder<EmployeeWithAllocationStatus> table_model_metadata_builder;
        private readonly ITableFieldsMetadataBuilder<EmployeeWithAllocationStatus> table_field_metadata_builder;
        private readonly TableBuilder<EmployeeWithAllocationStatus> table_builder;
    }
}