using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Queries;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Queries;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Queries;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;


namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.PersonalDetails.Presentation.Editor {

    public class PersonalDetailsEditorPresenter : Presenter {
        private IGetUpdateEmployeePersonalDetailsRequest get_update_request;
        private EditorBuilder<UpdateEmployeePersonalDetailsRequest> editor_builder;
        private IGetDetailsOfTitlesEligibleForEmployee get_eligible_titles;
        private IGetDetailsOfGendersEligibleForEmployee get_eligible_genders;
        private IGetDetailsOfMaritalStatusesEligibleForEmployee get_eligible_maritalStatuses;
        private IGetDetailsOfNationalitiesEligibleForEmployee get_eligible_nationalities;
        private IGetDetailsOfEthnicOriginsEligibleForEmployee get_eligible_ethnic_origins;

        public ActionResult Editor ( EmployeeIdentity for_employee ) {
            var update_request = get_update_request.execute( for_employee );
            var titles = get_eligible_titles
                            .execute( for_employee )
                            .result
                            .Select( t => new LookupValue {
                                id = t.id.ToString( CultureInfo.InvariantCulture ),
                                description = t.description,
                            });


            var genders = get_eligible_genders
                .execute( for_employee )
                .result
                .Select( t => new LookupValue {
                    id = t.id.ToString( CultureInfo.InvariantCulture ),
                    description = t.description,
                });

            var maritalStatuses = get_eligible_maritalStatuses
                .execute( for_employee )
                .result
                .Select( t => new LookupValue {
                    id = t.id.ToString( CultureInfo.InvariantCulture ),
                    description = t.description,
                });

            var nationalities = get_eligible_nationalities
                    .execute( for_employee )
                    .result
                    .Select( t => new LookupValue
                    {
                        id = t.id.ToString( CultureInfo.InvariantCulture ),
                        description = t.description
                    });

            var ethnic_origins = get_eligible_ethnic_origins
                        .execute( for_employee )
                        .result
                        .Select(t => new LookupValue
                        {
                            id = t.id.ToString( CultureInfo.InvariantCulture ),
                            description = t.description
                        });

            var view_model = editor_builder
                                .set_lookup_values( m => m.title_id, titles )
                                .set_lookup_values( m => m.gender_id, genders )
                                .set_lookup_values(m => m.marital_status_id, maritalStatuses)
                                .set_lookup_values( m => m.nationality_id, nationalities )
                                .set_lookup_values( m => m.ethnic_origin_id, ethnic_origins )
                                .build( update_request.result )
                                ;

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }

        public PersonalDetailsEditorPresenter 
            ( IGetUpdateEmployeePersonalDetailsRequest get_update_request_query
            , IGetDetailsOfTitlesEligibleForEmployee get_eligible_titles_query
            , IGetDetailsOfGendersEligibleForEmployee get_eligible_genders_query
            ,IGetDetailsOfMaritalStatusesEligibleForEmployee get_eligible_maritalStatuses_query
            , IGetDetailsOfNationalitiesEligibleForEmployee get_eligible_nationalities_query
            , IGetDetailsOfEthnicOriginsEligibleForEmployee get_eligible_ethnic_origins_query
            , EditorBuilder<UpdateEmployeePersonalDetailsRequest> the_editor_builder ) {

            get_update_request = Guard.IsNotNull(get_update_request_query, "get_update_request_query");
            editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
            
            get_eligible_titles = Guard.IsNotNull( get_eligible_titles_query, "get_eligible_titles_query" );
            get_eligible_genders = Guard.IsNotNull( get_eligible_genders_query, "get_eligible_genders_query" );
            get_eligible_maritalStatuses = Guard.IsNotNull(get_eligible_maritalStatuses_query, "get_eligible_genders_query");
            get_eligible_nationalities = Guard.IsNotNull( get_eligible_nationalities_query,
                "get_eligible_nationalities_query" );
            get_eligible_ethnic_origins = Guard.IsNotNull( get_eligible_ethnic_origins_query,
                "get_eligible_ethnic_origins_query" );
            }

    }
}
