using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Features.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeSkills.Fields.Skill
{

    public class A_forename_is_mandatory
    {

        [TestClass]
        public class verify_on_create
                        : MandatoryTextFieldSpecification<NewEmployeeSkillRequest, NewEmployeeSkillResponse, NewEmployeeSkillFixture>
        {

            public verify_on_create()
                : base((request, value) => request.skill_id = Null.Id) { }
        }

    }
}