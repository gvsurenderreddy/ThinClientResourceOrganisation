using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New
{
    public class NewEmployeeSkillValidator : INewEmployeeSkillValidator
    {
        public NewEmployeeSkillValidator(Validator the_validator)
        {
            validator = Guard.IsNotNull(the_validator, "the_validator");
        }

        public IEnumerable<ResponseMessage> validate(NewEmployeeSkillRequest request)
        {

            return validator.errors;
        }
        private readonly Validator validator;
    }
}