using System.Collections.Generic;
using System.Globalization;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableFieldMetadataRepository;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Configuration.TableModelMetadataRepository;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.viewEmployees.get {


    public class ViewEmployeesPageViewModelBuilder {
         

        public IsAViewElement build
                               ( IEnumerable<EmployeeDetail> employees ) {

            return this
                    .set_employees( employees )
                    .define_table_model()
                    .define_table_rows()
                    .build_view_model()
                    ;
        }


        public ViewEmployeesPageViewModelBuilder
                ( ITableModelMetadataBuilder<EmployeeDetail> table_model_metadata_builder
                , ITableFieldsMetadataBuilder<EmployeeDetail> table_field_metadata_builder
                , TableBuilder<EmployeeDetail> table_builder ) {


            this.table_model_metadata_builder = Guard.IsNotNull( table_model_metadata_builder, "table_model_metadata_builder" );
            this.table_field_metadata_builder = Guard.IsNotNull( table_field_metadata_builder, "table_field_metadata_builder" );
            this.table_builder = Guard.IsNotNull(  table_builder, "table_builder" );
        }



        private ViewEmployeesPageViewModelBuilder set_employees
                                                   ( IEnumerable<EmployeeDetail> employees ) {

            this.employees = Guard.IsNotNull( employees, "employees" );
            return this;
        }

        private ViewEmployeesPageViewModelBuilder define_table_model ( ) { 

            table_model_metadata_builder
                .id( Resources.page_id )
                .field_id_extension( employee_detail => employee_detail.employee_id.ToString( CultureInfo.InvariantCulture ))
                .row_details_route_id( employee.details.Get.Resources.page_id )
                .row_details_route_pramameter_factory( e => new { e.employee_id })
                ;
            
            return this;
        }

        private ViewEmployeesPageViewModelBuilder define_table_rows () {

            table_field_metadata_builder
                .for_field( m => m.forename )
                .id( "forename" )
                .lable( "Forename" )
                ;

            table_field_metadata_builder
                .for_field( m => m.surname )
                .id( "surname" )
                .lable( "Surname" )
                ;

            table_field_metadata_builder
                .for_field( m => m.employee_reference )
                .id( "employeeReference" )
                .lable( "Employee reference" )
                ;

            table_field_metadata_builder
                .for_field( m => m.location )
                .id( "location" )
                .lable( "Location" )
                ;

            table_field_metadata_builder
                .for_field( m => m.job_title )
                .id( "job_title" )
                .lable( "Job title" )
                ;

            table_field_metadata_builder
                .for_field( m => m.mobile )
                .id( "mobile" )
                .lable( "Mobile" )
                ;

            table_field_metadata_builder
                .for_field( m => m.phone )
                .id( "phone" )
                .lable( "Phone" )
                ;

            table_field_metadata_builder
                .for_field( m => m.email )
                .id( "email" )
                .lable( "Email" )
                ;

            return this;
        }

        private IsAViewElement build_view_model () {

            Guard.IsNotNull( employees, "employees" );

            return table_builder.build( employees );
        }

        private IEnumerable<EmployeeDetail> employees;

        private readonly ITableModelMetadataBuilder<EmployeeDetail> table_model_metadata_builder;
        private readonly ITableFieldsMetadataBuilder<EmployeeDetail> table_field_metadata_builder;
        private readonly TableBuilder<EmployeeDetail> table_builder;
    }
}