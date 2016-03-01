using System.Collections.Generic;
using System.Linq;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Persistence.Domain.DocumentStore;
using WTS.WorkSuite.Persistence.Infrastructure;
using WTS.WorkSuite.Service.DocumentStore.Images;
using WTS.WorkSuite.Service.DocumentStore.Images.New;
using WTS.WorkSuite.Service.Framework.DefaultValues;
using WTS.WorkSuite.Service.Framework.Validation;

namespace WTS.WorkSuite.Domain.DocumentStore.Images.New
{
    public class NewImage : INewImage
    {

        public NewImage(
                        IEntityRepository<Image> theImageRepository,
                        IUnitOfWork theUnitOfWork,
                        ICanAddNewImage theExecutePermission,
                        INewImageValidator theValidator
                        )
        {
            _imageRepository = Guard.IsNotNull(theImageRepository, "theImageRepository");
            _unitOfWork = Guard.IsNotNull(theUnitOfWork, "theUnitOfWork");
            _executePermission = Guard.IsNotNull(theExecutePermission, "theExecutePermission");
            _validator = Guard.IsNotNull(theValidator, "theValidator");
        }

        public NewImageResponse execute(NewImageRequest theRequest)
        {
            _request = theRequest;
            _responseBuilder.set_response(new ImageIdentity { imageId = Null.Id });

            var hasPermission = _executePermission.IsGrantedFor(_request);

            if (!hasPermission)
            {
                _responseBuilder.add_errors(new List<string> {
                    ValidationMessages.warning_03_0001,
                });

                return _responseBuilder.build();
            }

            // validate the request  
            var validation_errors = _validator.validateImage(_request);
            if (validation_errors.Any())
            {
                _responseBuilder.add_errors(validation_errors);
            }

            var confirmation = new List<string>();
  
            if (!_responseBuilder.has_errors)
            {

                // create the image
                var newImage = new Image()
                {
                    isDefault = _request.isDefault,
                    data = _request.data
                };
                _imageRepository.add(newImage);
                _unitOfWork.Commit();

                confirmation.Add(ValidationMessages.confirmation_04_0007);

                _responseBuilder.add_messages(confirmation);
                _responseBuilder.set_response(new ImageIdentity { imageId = newImage.id });
            }
            else
            {
                _responseBuilder.add_errors(new List<string> {
                    ValidationMessages.warning_03_0001,
                });
            }
            return _responseBuilder.build();
        }

        private readonly ICanAddNewImage _executePermission;
        private readonly IEntityRepository<Image> _imageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private NewImageRequest _request;
        private readonly INewImageValidator _validator;
        private readonly ResponseBuilder<ImageIdentity, NewImageResponse> _responseBuilder = new ResponseBuilder<ImageIdentity, NewImageResponse>();
    }
}
