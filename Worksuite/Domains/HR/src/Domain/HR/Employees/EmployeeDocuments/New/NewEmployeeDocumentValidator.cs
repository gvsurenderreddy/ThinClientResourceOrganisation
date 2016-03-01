using System.Collections.Generic;
using Content.Services.HR.Messages;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New
{
    public class NewEmployeeDocumentValidator : INewEmployeeDocumentValidator
    {
        public NewEmployeeDocumentValidator(Validator the_validator)
        {
            validator = Guard.IsNotNull(the_validator, "the_validator");
        }

        public IEnumerable<ResponseMessage> validate(NewEmployeeDocumentRequest request)
        {
            //Need to keep on adding fields here.
            validator.field("name")
                .is_madatory(request.name, ValidationMessages.error_01_0003)
                ;

            validator.field("description")
                .is_madatory(request.description, ValidationMessages.error_01_0003)
                ;

            return validator.errors;
        }
        private readonly Validator validator;
    }
}