using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Report;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.PersonalDetails.Presentation.Report {

    public class MetadataConfiguration : ReportMetadataBuilder<EmployeePersonalDetails> {

        protected override void build_model_metadata 
            ( IReportModelMetadataBuilder<EmployeePersonalDetails> builder ) {
            
            builder
                .presenter_id( Resources.id )
                .title(PersonalDetailsResources.title)
                ;
        }

        protected override void build_field_metadata 
            ( IReportFieldsMetadataBuilder<EmployeePersonalDetails> builder ) {

            builder
                .for_field( m => m.title )
                .is_included(m => !string.IsNullOrEmpty(m.title))
                .id( "title" )
                .label( "Title" )
                ;

            builder
                .for_field( m => m.forename )
                .id( "forename" )
                .label( "Forename" )
                ;

            builder
                .for_field(m => m.othername)
                .is_included(m => !string.IsNullOrEmpty(m.othername))
                .id("othername")
                .label("Other names")
                ;

            builder
                .for_field( m => m.surname )
                .id( "surname" )
                .label( "Surname" )
                ;

            builder
                .for_field( m => m.gender )
                .is_included( m => !string.IsNullOrWhiteSpace( m.gender ))                
                .id( "gender" )
                .label( "Gender" )
                ;

            builder
               .for_field(m => m.maritalStatus)
               .is_included(m => !string.IsNullOrWhiteSpace(m.maritalStatus))
               .id("maritalstatus")
               .label("Marital status")
               ;

            builder
                .for_field(m => m.nationality)
                .is_included(m => !string.IsNullOrWhiteSpace(m.nationality))
                .id("nationality")
                .label("Nationality")
                ;

            builder
                .for_field( m => m.birth_place )
                .is_included( m => !string.IsNullOrWhiteSpace( m.birth_place ))
                .id("birth_place")
                .label("Place of birth")
                ;

            builder
                .for_field( m => m.ethnic_origin )
                .is_included( m => !string.IsNullOrWhiteSpace( m.ethnic_origin ) )
                .id( "ethnic_origin" )
                .label( "Ethnic origin" )
                ;

            builder
                .for_field(m => m.date_of_birth)
                .is_included(m => !string.IsNullOrWhiteSpace(m.date_of_birth))
                .id("date_of_birth")
                .label("Date of birth")
                ;
                
        }

        protected override void build_action_metadata ( IReportActionsMetadataBuilder<EmployeePersonalDetails> builder ) {
            
            // to do: add actions once the report has been built
            builder
                .add_action<Edit>(  )
                .id( Editor.Resources.id )
                .route_parameter_factory( m => new { m.employee_id } )
                ;

        }

    }

}