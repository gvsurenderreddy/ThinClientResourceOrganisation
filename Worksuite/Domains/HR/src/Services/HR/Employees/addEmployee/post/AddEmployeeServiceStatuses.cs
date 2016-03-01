using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.addEmployee.post
{
    public class AddEmployeeServiceStatuses
    {
        public class EmployeeReferenceIsMandatory : AServiceErrorStatus { }

        public class EmployeeReferenceExceedsMaxCharacters : AServiceErrorStatus { }

        public class EmployeeReferenceIsNotUnique : AServiceErrorStatus { }

        public class EmployeeForenameIsMandatory : AServiceErrorStatus { }

        public class EmployeeForenameHasInvalidCharacters : AServiceErrorStatus { }

        public class EmployeeForenameExceedsMaxCharacters : AServiceErrorStatus { }

        public class EmployeeSurnameIsMandatory : AServiceErrorStatus { }

        public class EmployeeSurnameHasInvalidCharacters : AServiceErrorStatus { }

        public class EmployeeSurnameExceedsMaxCharacters : AServiceErrorStatus { }

    }
}
