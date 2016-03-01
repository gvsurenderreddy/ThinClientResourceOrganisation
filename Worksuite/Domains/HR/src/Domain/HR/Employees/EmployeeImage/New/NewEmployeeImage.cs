using System.Collections.Generic;
using System.IO;
using System.Linq;
using WTS.WorkSuite.Domain.DocumentStore.Images.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Persistence.Domain.DocumentStore;
using WTS.WorkSuite.Persistence.Domain.HR;
using WTS.WorkSuite.Persistence.Infrastructure;
using WTS.WorkSuite.Service.CustomTypes;
using WTS.WorkSuite.Service.DocumentStore.Images;
using WTS.WorkSuite.Service.DocumentStore.Images.New;
using WTS.WorkSuite.Service.Framework.Validation;
using WTS.WorkSuite.Service.HR.Employees.EmployeeImage;
using WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New;

namespace WTS.WorkSuite.Domain.HR.Employees.EmployeeImage.New
{
    public class NewEmployeeImage : INewEmployeeImage
    {
        public NewEmployeeImage(IEntityRepository<Image> theImageRepository
                ,IEntityRepository<Employee> theEmployeeRepository
                ,IUnitOfWork theUnitOfWork
                ,ICanAddNewEmployeeImage theExecutePermission
                , INewImageValidator theValidator)
        {
            _imageRepository = Guard.IsNotNull(theImageRepository, "theImageRepository");
            _employeeRepository = Guard.IsNotNull(theEmployeeRepository, "theEmployeeRepository");
            _unitOfWork = Guard.IsNotNull(theUnitOfWork, "theUnitOfWork");
            _executePermission = Guard.IsNotNull(theExecutePermission, "theExecutePermission");
            _validator = Guard.IsNotNull(theValidator, "theValidator");
        }

        public NewEmployeeImageResponse execute(NewEmployeeImageRequest theRequest)
        {
            _request = theRequest;
            _responseBuilder.set_response(new EmployeeImageIdentity { employee_id = _request.employee_id, imageId = _request.imageId });

            var hasPermission = _executePermission.IsGrantedFor(_request);

            if (!hasPermission)
            {
                setError(ValidationMessages.create_new_was_not_successfull);
                return _responseBuilder.build();
            }

            var confirmation = new List<string>();
  
            if (!_responseBuilder.has_errors)
            {
                createDefaultImage();

                if (_newImageResponse.has_errors)
                {
                    setError(ValidationMessages.create_new_was_not_successfull);
                    return _responseBuilder.build();
                }

                int imageId = _newImageResponse.result.imageId;
                
                GetEmployeeFromRequest();
                _employee.imageId = imageId;
                _unitOfWork.Commit();

                confirmation.Add(ValidationMessages.confirmation_04_0007);

                _responseBuilder.add_messages(confirmation);
                _responseBuilder.set_response(new EmployeeImageIdentity { imageId = imageId.ToImageId() });
            }
            else
            {
                setError(ValidationMessages.create_new_was_not_successfull);
            }
            return _responseBuilder.build();
        }

        private void createDefaultImage()
        {
            NewImageRequest newImageRequest = new GetNewImageRequest().execute(new ImageIdentity());
            newImageRequest.data = getDefaultImageDetails();
             
            ICanAddNewImage canAddNewImage = new CanAddNewImage(); // we have to look at this later on how to use _executePermission to pass-in.
            NewImage newImage = new NewImage(
                _imageRepository,
                _unitOfWork,
                canAddNewImage,
                _validator
                );

            _newImageResponse = newImage.execute(newImageRequest);
        }
        
        private byte[] getDefaultImageDetails()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            Stream myStream = myAssembly.GetManifestResourceStream("WTS.WorkSuite.Domain.DocumentStore.Images.employee_blank.png");

            var contentLength = (int)myStream.Length;
            byte[] filebytearray = new byte[contentLength];
            BinaryReader br = new BinaryReader(myStream);
            br.BaseStream.Position = 0;
            filebytearray = br.ReadBytes(contentLength);
            return filebytearray;

        }
        
        private void GetEmployeeFromRequest()
        {
            _employee = _employeeRepository
                                .Entities
                                .Single(e => e.id == _request.employee_id);
        }

        private void setError(string error)
        {
            _responseBuilder.add_errors(new List<string> { error, });            
        }

        private readonly ICanAddNewEmployeeImage _executePermission;
        private readonly IEntityRepository<Image> _imageRepository;
        private readonly IEntityRepository<Employee> _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private NewEmployeeImageRequest _request;
        private NewImageResponse _newImageResponse;
        private readonly INewImageValidator _validator;
        private readonly ResponseBuilder<EmployeeImageIdentity, NewEmployeeImageResponse> _responseBuilder = new ResponseBuilder<EmployeeImageIdentity, NewEmployeeImageResponse>();
        private Employee _employee;

    }
}
