using System.Collections.Generic;
using WTS.WorkSuite.Domain.Framework.Validation;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Service.DocumentStore.Images.New;

namespace WTS.WorkSuite.Domain.DocumentStore.Images.New
{
    public class NewImageValidator : INewImageValidator
    {
        public NewImageValidator(IValidator theValidator)
        {
            _validator = Guard.IsNotNull(theValidator, "theValidator");
        }

        public IEnumerable<ResponseMessage> validateImage(NewImageRequest request)
        {

            // Validate the image byte

            return _validator.errors;
        }
        private readonly IValidator _validator;
    }
}
