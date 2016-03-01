using System.Collections.Generic;
using Content.Services.HR.Messages;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.DocumentStore.Documents.New
{
    public class NewDocumentValidator : INewDocumentValidator
    {
        public NewDocumentValidator(Validator the_validator)
        {
            _validator = Guard.IsNotNull(the_validator, "the_validator");
        }

        public IEnumerable<ResponseMessage> validate(NewDocumentRequest request)
        {
            _validator.field("name")
                     .is_madatory(request.name, ValidationMessages.error_01_0003)
                     ;

            _validator.field("content_type")
                .is_madatory(request.content_type, ValidationMessages.error_01_0003)
                ;

            _validator.field("data")
                      .premise_holds(request.data != null, ValidationMessages.error_00_0029)
                      .premise_holds(request.data == null || request.data.Length > 0, ValidationMessages.error_00_0029);

            return _validator.errors;
        }



        private readonly Validator _validator;
    }
}