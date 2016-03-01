using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeSkills.New
{
    public interface INewEmployeeSkillValidator
    {
        IEnumerable<ResponseMessage> validate(NewEmployeeSkillRequest request);  
    }
}