using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Persistence.Domain.HR;
using WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New;
using WTS.WorkSuite.Service.Helpers.Domain.DocumentStore.Images;
using WTS.WorkSuite.Service.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Service.Helpers.Framework.Specifications;
using WTS.WorkSuite.Service.Infrastructure;

namespace WTS.WorkSuite.Service.Domain.HR.Employees.Images.New
{
    [TestClass]
    public class adding_an_image_first_time_should 
                    : Specification {

        [TestMethod]
        [TestCategory("Unit Test")]
        public void save_the_image_for_the_employee_if_it_is_a_jpeg_image_type()
        {
            given_an_employee_with_forename("john")
                .with_a_jpeg_image_is_provided()
                .when_the_image_is_added_to_the_employee()
                .then_it_should_save_the_image_for_later_use();
        }

        private adding_an_image_first_time_should then_it_should_save_the_image_for_later_use()
        {
            var image = _imageHelper.entities.Single(i => i.id == _response.result.imageId.Value);
            Assert.IsNotNull(image);
            return this;
        }

        private adding_an_image_first_time_should when_the_image_is_added_to_the_employee()
        {
            _response = _newEmployeeImage.execute(new NewEmployeeImageRequest()
            {
                data = _image.data,
                employee_id = _employee.id
            });

            return this;
        }

        private adding_an_image_first_time_should with_a_jpeg_image_is_provided()
        {
            _imageBuilder = _imageHelper.add();
            _image = _imageBuilder.withData(createAJpegImage()).entity;

            return this;
        }

        private adding_an_image_first_time_should given_an_employee_with_forename(string forename)
        {
            _employeeBuilder = _employeeHelper.add().forename(forename);
            _employee = _employeeHelper.entities.Single(e => e.forename == forename);

            return this;
        }
        
        private byte[] createAJpegImage()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("WTS.WorkSuite.Service.Helpers.Domain.DocumentStore.Images.Nick.jpg");
            var contentLength = (int)myStream.Length;
            byte[] filebytearray = new byte[contentLength];
            BinaryReader br = new BinaryReader(myStream);
            br.BaseStream.Position = 0;
            filebytearray = br.ReadBytes(contentLength);
            return filebytearray;

        }

        protected override void test_setup()
        {
            base.test_setup();

            _imageHelper = DependencyResolver.resolve<ImageHelper>();
            _employeeHelper = DependencyResolver.resolve<EmployeeHelper>();
            _newEmployeeImage = DependencyResolver.resolve<INewEmployeeImage>();

        }

        private NewEmployeeImageResponse _response;
        private  WTS.WorkSuite.Persistence.Domain.DocumentStore.Image _image;
        private INewEmployeeImage _newEmployeeImage;
        private ImageHelper _imageHelper;
        private ImageBuilder _imageBuilder;
        private EmployeeHelper _employeeHelper;
        private Employee _employee;
        private EmployeeBuilder _employeeBuilder;
    }
}
