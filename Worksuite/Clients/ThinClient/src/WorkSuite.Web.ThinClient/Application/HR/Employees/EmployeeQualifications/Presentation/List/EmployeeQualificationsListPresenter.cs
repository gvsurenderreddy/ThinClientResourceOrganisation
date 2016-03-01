using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.GetAll;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeQualifications.Presentation.List
{
    public class EmployeeQualificationsListPresenter
                        : Presenter
    {
        public ActionResult List( EmployeeIdentity employee )
        {
            GetAllEmployeeQualificationsResponse response = _get_all_employee_qualification
                                                                    .execute(employee)
                                                                    ;

            IsAViewElement view_model = _employee_qualification_details_list_builder
                                        .build( response.result, () => new { employee.employee_id } )
                                        ;

            return View( @"~\Views\Shared\Views\DetailsList.cshtml", view_model );
        }

        public EmployeeQualificationsListPresenter( IGetAllEmployeeQualifications the_get_all_employee_qualification,
                                                    DetailsListBuilder<EmployeeQualificationDetails> the_employee_qualification_details_list_builder
                                                  )
        {
            _get_all_employee_qualification = Guard.IsNotNull( the_get_all_employee_qualification,
                "the_get_all_employee_qualification" );

            _employee_qualification_details_list_builder =
                Guard.IsNotNull( the_employee_qualification_details_list_builder,
                    "the_employee_qualification_details_list_builder" );
        }

        private readonly IGetAllEmployeeQualifications _get_all_employee_qualification;
        private readonly DetailsListBuilder<EmployeeQualificationDetails> _employee_qualification_details_list_builder;
    }
}