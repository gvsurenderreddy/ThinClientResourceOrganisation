using System.IO;
using System.Linq;
using WTS.WorkSuite.Domain.DocumentStore.Images.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Persistence.Infrastructure;
using WTS.WorkSuite.Service.DocumentStore.Images;
using WTS.WorkSuite.Service.DocumentStore.Images.GetById;
using WTS.WorkSuite.Persistence.Domain.DocumentStore;
using WTS.WorkSuite.Service.DocumentStore.Images.New;

namespace WTS.WorkSuite.Domain.DocumentStore.Images.GetById
{
    public class GetImageById : IGetImageById
    {
        public GetImageById(
                            IEntityRepository<Image> theImageRepository,
                            IUnitOfWork theUnitOfWork,
                            ICanAddNewImage theExecutePermission,
                            INewImageValidator theValidator
                            )
        {
            _imageRepository = Guard.IsNotNull(theImageRepository, "theImageRepository");
            _unitOfWork = Guard.IsNotNull(theUnitOfWork, "theUnitOfWork");
            _theExecutePermission = Guard.IsNotNull(theExecutePermission, "theExecutePermission");
            _validator = Guard.IsNotNull(theValidator, "theValidator");
        }

        public Response<byte[]> execute(ImageIdentity request)
        {
            var imageId = getImageId(request);

            var image = getImageDetails(imageId);
            Guard.IsNotNull(image, "image");

            return new Response<byte[]>
            {
                result = image.data
            };
        }

        private Image getImageDetails(int imageId)
        {
            return _imageRepository.Entities.SingleOrDefault(i => i.id == imageId);
        }

        private int getImageId(ImageIdentity request)
        {
            var image = getImageDetails(request.imageId);
            if (image == null)
            {
                return getDefaultImageId();
            }
            else
            {
                return image.id;
            }
        }

        private int getDefaultImageId()
        {
            var defaultImage = _imageRepository.Entities.SingleOrDefault(i => i.isDefault == true);

            if (defaultImage == null)
            {
                createAndStoreDefaultImage();
                return _newImageResponse.result.imageId;
            }
            else
            {
                return defaultImage.id;
            }

        }

        private void createAndStoreDefaultImage()
        {
            NewImageRequest newImageRequest = new GetNewImageRequest().execute(new ImageIdentity());
            newImageRequest.isDefault = true;
            newImageRequest.data = getDefaultImageDetails();


            NewImage newImage = new NewImage( _imageRepository,
                                _unitOfWork,
                                _theExecutePermission,
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

        private readonly IEntityRepository<Image> _imageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private NewImageResponse _newImageResponse;
        private readonly INewImageValidator _validator;
        private readonly ICanAddNewImage _theExecutePermission;
    }
}
