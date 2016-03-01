using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.GetAll;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDetails.ViewModel;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeQualifications.Presentation.Page
{
    public class EmployeeQualificationsPresenter
                        : Presenter
    {
        public ActionResult Page( EmployeeIdentity employee )
        {
            var view_model = _employee_details_view_model_builder
                                    .For(employee)
                                    .add_details_list(  _get_all_employee_qualifications.execute(employee).result,
                                                        () => new {employee.employee_id}
                                                     )
                                    .build()
                                    ;

            return View( @"~\Views\HR\Employees\EmployeeQualifications\Page.cshtml", view_model );
        }

        public EmployeeQualificationsPresenter( EmployeeDetailsViewModelBuilder the_employee_details_view_model_builder,
                                                IGetAllEmployeeQualifications the_get_all_employee_qualifications
                                              )
        {
            _employee_details_view_model_builder = Guard.IsNotNull( the_employee_details_view_model_builder,
                "the_employee_details_view_model_builder" );
            _get_all_employee_qualifications = Guard.IsNotNull( the_get_all_employee_qualifications,
                "the_get_all_employee_qualifications" );
        }

        private readonly EmployeeDetailsViewModelBuilder _employee_details_view_model_builder;
        private readonly IGetAllEmployeeQualifications _get_all_employee_qualifications;
    }
}