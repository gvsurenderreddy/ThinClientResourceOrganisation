using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmploymentDetails.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.JobTitles.Queries;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmploymentDetails.Presentation.Editor
{
    public class EmploymentDetailsEditorPresenter : Presenter
    {
        public ActionResult Editor(EmployeeIdentity employee)
        {
            var updateEmploymentDetailsResponse = _getUpdateEmploymentDetailsRequest.execute(employee);

            var all_eligible_job_titles = _getEligibleJobTitles
                                                .execute(employee)
                                                .result
                                                .Select(t => new LookupValue
                                                {
                                                    id = t.id.ToString(CultureInfo.InvariantCulture),
                                                    description = t.description,
                                                });

            var all_eligible_locations = _getEligibleLocations
                                            .execute(employee)
                                            .result
                                            .Select(t => new LookupValue
                                            {
                                                id = t.id.ToString(CultureInfo.InvariantCulture),
                                                description = t.description,
                                            });

            var viewModel = _editorBuilder
                                    .set_lookup_values(m => m.job_title_id, all_eligible_job_titles)
                                    .set_lookup_values(m => m.location_id, all_eligible_locations)
                                    .build(updateEmploymentDetailsResponse.result);
            ;

            return View(@"~\Views\Shared\Views\Editor.cshtml", viewModel);
        }

        public EmploymentDetailsEditorPresenter(IGetUpdateEmploymentDetailsRequest getUpdateEmploymentDetailsRequest,
                                                EditorBuilder<UpdateEmploymentDetailsRequest> theEditorBuilder,
                                                IGetDetailsOfJobTitlesEligibleForEmployee theGetEligibleJobTitles,
                                                IGetDetailsOfLocationsEligibleForEmployee theGetEligibleLocations
                                               )
        {
            _getUpdateEmploymentDetailsRequest = Guard.IsNotNull(getUpdateEmploymentDetailsRequest,
                                                                 "getUpdateEmploymentDetailsRequest");
            _editorBuilder = Guard.IsNotNull(theEditorBuilder, "theEditorBuilder");
            _getEligibleJobTitles = Guard.IsNotNull(theGetEligibleJobTitles, "theGetEligibleJobTitles");
            _getEligibleLocations = Guard.IsNotNull(theGetEligibleLocations, "theGetEligibleLocations");
        }

        private IGetUpdateEmploymentDetailsRequest _getUpdateEmploymentDetailsRequest;
        private IGetDetailsOfJobTitlesEligibleForEmployee _getEligibleJobTitles;
        private IGetDetailsOfLocationsEligibleForEmployee _getEligibleLocations;
        private EditorBuilder<UpdateEmploymentDetailsRequest> _editorBuilder;
    }
}