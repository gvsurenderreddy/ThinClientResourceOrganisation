using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.GetAll;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Presentation.List
{
    public class EmployeeSkillsListPresenter : Presenter
    {
        public ActionResult List(EmployeeIdentity employee)
        {

            var employee_skills = get_all.execute(employee);
            var view_model = list_builder.build(employee_skills.result, () => new { employee.employee_id });

            return View(@"~\Views\Shared\Views\DetailsList.cshtml", view_model);
        }


        public EmployeeSkillsListPresenter(IGetAllEmployeeSkills get_all_query
                                              , DetailsListBuilder<EmployeeSkillDetails> the_list_builder)
        {

            Guard.IsNotNull(get_all_query, "get_all_query");
            Guard.IsNotNull(the_list_builder, "the_list_builder");

            get_all = get_all_query;
            list_builder = the_list_builder;
        }

        private readonly IGetAllEmployeeSkills get_all;
        private readonly DetailsListBuilder<EmployeeSkillDetails> list_builder;

    }
}