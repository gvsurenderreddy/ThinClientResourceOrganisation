using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Skills.Queries;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeSkills.Presentation.New
{
    public class NewEmployeeSkillPresenter : Presenter
    {
        public ActionResult Editor(EmployeeIdentity employee)
        {
            var skills = get_entries_eligible_for_dropdown(employee);

            var new_request = new_employee_skill_request.execute(new EmployeeIdentity { employee_id = employee.employee_id });

            var view_model = editor_builder
                            .set_lookup_values(m => m.skill_id, skills)
                            .build(new_request);

            return View(@"~\Views\Shared\Views\Editor.cshtml", view_model);
        }

        public NewEmployeeSkillPresenter
            (IGetNewEmployeeSkillRequest get_new_employee_skill_request
            , IGetDetailsOfSkillsEligibleForEmployee the_get_eligible_skills_query
            , EditorBuilder<NewEmployeeSkillRequest> the_editor_builder)
        {

            Guard.IsNotNull(get_new_employee_skill_request, "get_new_employee_skill_request");
            Guard.IsNotNull(the_editor_builder, "the_editor_builder");

            get_eligible_skills = Guard.IsNotNull(the_get_eligible_skills_query, "the_get_eligible_skills_query");

            new_employee_skill_request = get_new_employee_skill_request;
            editor_builder = the_editor_builder;
        }

        private readonly IGetDetailsOfSkillsEligibleForEmployee get_eligible_skills;
        private readonly IGetNewEmployeeSkillRequest new_employee_skill_request;
        private readonly EditorBuilder<NewEmployeeSkillRequest> editor_builder;



        private IEnumerable<LookupValue> get_entries_eligible_for_dropdown(EmployeeIdentity employee)
        {
            var skills = get_eligible_skills
                            .execute(new EmployeeSkillIdentity() { employee_skill_id = NotSpecified.Id, employee_id = employee.employee_id })
                            .result
                            .Select(t => new LookupValue
                            {
                                id = t.id.ToString(CultureInfo.InvariantCulture),
                                description = t.description,
                            });


            if (skills.Any())
            {
                skills = blank().Union(skills);
            }

            return skills;
        }

        private static IEnumerable<LookupValue> blank()
        {
            yield return new LookupValue
            {
                id = "-2",
                description = "Please select an option.",
            };
        }

    }
}