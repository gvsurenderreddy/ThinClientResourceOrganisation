using System.IO;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New;
using WTS.WorkSuite.Service.Helpers.Domain.HR.Employees;
using WTS.WorkSuite.Service.Helpers.Framework.Request;

namespace WTS.WorkSuite.Service.Domain.HR.Employees.EmployeeImage.New
{
    public class NewEmployeeImageRequestBuilder : IRequestBuilder<NewEmployeeImageRequest>
    {
        public NewEmployeeImageRequestBuilder(EmployeeHelper theEmployeeHelper)
        {
            _employeeHelper = Guard.IsNotNull(theEmployeeHelper, "theEmployeeHelper");
        }

        public NewEmployeeImageRequest given_a_valid_request()
        {
            //Create an Employee
            var employee = _employeeHelper.add().entity;

            return new NewEmployeeImageRequest
                {
                    data = createAJpegImage(),
                    employee_id = employee.id,
                };

        }

        private byte[] createAJpegImage()
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("WTS.WorkSuite.Service.Specification.Domain.HR.Employees.EmployeeImage.New.employee_blank.png");

            var contentLength = (int)myStream.Length;
            byte[] filebytearray = new byte[contentLength];
            BinaryReader br = new BinaryReader(myStream);
            br.BaseStream.Position = 0;
            filebytearray = br.ReadBytes(contentLength);
            return filebytearray;

        }


        private EmployeeHelper _employeeHelper;
    }
}
