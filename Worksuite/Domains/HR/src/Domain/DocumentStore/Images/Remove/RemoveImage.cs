using System.Linq;
using WTS.WorkSuite.Domain.Framework.Validation;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Persistence.Domain.DocumentStore;
using WTS.WorkSuite.Persistence.Infrastructure;
using WTS.WorkSuite.Service.DocumentStore.Images;
using WTS.WorkSuite.Service.DocumentStore.Images.Remove;
using WTS.WorkSuite.Service.Framework.DefaultValues;
using WTS.WorkSuite.Service.Framework.Validation;

namespace WTS.WorkSuite.Domain.DocumentStore.Images.Remove
{
    public class RemoveImage : IRemoveImage
    {
        public RemoveImage(IUnitOfWork theUnitOfWork
                          , IEntityRepository<Image> theRepository
                          , IValidator theValidator
                          , ICanRemoveImage theExecutePermission)
        {

            _unitOfWork = Guard.IsNotNull(theUnitOfWork, "the_unit_of_work");
            _imageRepository = Guard.IsNotNull(theRepository, "the_repository");
            _executePermission = Guard.IsNotNull(theExecutePermission, "the_execute_permission");
            _validator = Guard.IsNotNull(theValidator, "the_validator");
        }


        public RemoveImageResponse execute(ImageIdentity request)
        {
            // - initialise the request
            _responseBuilder.set_response(new ImageIdentity { imageId = Null.Id });

            _validator.premise_holds(_executePermission.IsGrantedFor(request), ValidationMessages.default_update_permission_not_granted);

            _responseBuilder.add_errors(_validator.errors);

            if (_responseBuilder.has_errors)
            {
                return _responseBuilder.build();
            }


            // - validate the request
            var image = _imageRepository
                                .Entities
                                .SingleOrDefault(e => e.id == request.imageId)
                                ;

            _imageRepository.remove(image);

            _unitOfWork.Commit();
            _responseBuilder.add_message(ValidationMessages.update_was_successfull);


            // - report the status
            _responseBuilder.set_response(request);
            return _responseBuilder.build();
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityRepository<Image> _imageRepository;
        private readonly IValidator _validator;
        private readonly ICanRemoveImage _executePermission;
        private readonly ResponseBuilder<ImageIdentity, RemoveImageResponse> _responseBuilder = new ResponseBuilder<ImageIdentity, RemoveImageResponse>();
    }
}
