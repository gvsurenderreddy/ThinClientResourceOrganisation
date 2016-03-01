using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeQualifications.Presentation.New
{
    public class NewEmployeeQualificationPresenter
                            : Presenter
    {
        public ActionResult Editor( EmployeeIdentity employee )
        {
            IEnumerable<LookupValue> eligible_qualifications = get_qualifications_eligible_for_lookup( employee );

            var new_request = _new_employee_qualification_request
                                        .execute( new EmployeeIdentity
                                                        {
                                                            employee_id = employee.employee_id
                                                        })
                                        ;

            var view_model = _new_employee_qualification_request_editor_builder
                                    .set_lookup_values( q => q.qualification_id, eligible_qualifications )
                                    .build( new_request )
                                    ;

            return View( @"~\Views\Shared\Views\Editor.cshtml", view_model );
        }

        private IEnumerable<LookupValue> get_qualifications_eligible_for_lookup( EmployeeIdentity employee )
        {
            var qualifications = _get_eligible_qualifications_for_an_employee
                                        .execute( new EmployeeQualificationIdentity
                                                            {
                                                                employee_id = employee.employee_id,
                                                                employee_qualification_id = NotSpecified.Id
                                                            })
                                        .result
                                        .Select( q => new LookupValue
                                                            {
                                                                id = q.id.ToString( CultureInfo.InvariantCulture ),
                                                                description = q.description
                                                            })
                                        ;

            if ( qualifications.Any() )
            {
                qualifications = default_lookup()
                                        .Union(qualifications)
                                        ;

            }

            return qualifications;
        }

        private IEnumerable<LookupValue> default_lookup()
        {
            yield return new LookupValue
            {
                id = "-2",
                description = "Please select an option"
            };
        }

        public NewEmployeeQualificationPresenter(   IGetNewEmployeeQualificationRequest the_get_new_employee_qualification_request,
                                                    IGetDetailsOfQualificationsEligibleForEmployee the_get_details_of_qualifications_eligible_for_an_employee,
                                                    EditorBuilder<NewEmployeeQualificationRequest> the_new_employee_qualification_request_editor_builder
                                                )
        {
            _new_employee_qualification_request = Guard.IsNotNull(the_get_new_employee_qualification_request,
                "the_get_new_employee_qualification_request");

            _get_eligible_qualifications_for_an_employee =
                Guard.IsNotNull( the_get_details_of_qualifications_eligible_for_an_employee,
                    "the_get_details_of_qualifications_eligible_for_an_employee" );

            _new_employee_qualification_request_editor_builder =
                Guard.IsNotNull( the_new_employee_qualification_request_editor_builder,
                    "the_new_employee_qualification_request_editor_builder" );
        }

        private readonly IGetNewEmployeeQualificationRequest _new_employee_qualification_request;
        private readonly IGetDetailsOfQualificationsEligibleForEmployee _get_eligible_qualifications_for_an_employee;
        private readonly EditorBuilder<NewEmployeeQualificationRequest>
            _new_employee_qualification_request_editor_builder;
    }
}