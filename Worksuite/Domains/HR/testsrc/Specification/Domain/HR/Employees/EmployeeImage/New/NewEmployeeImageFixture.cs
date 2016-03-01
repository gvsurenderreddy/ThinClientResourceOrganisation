using WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New;
using WTS.WorkSuite.Service.Helpers.Framework.Request;
using WTS.WorkSuite.Service.Helpers.Framework.Specifications.ForResponseCommands;

namespace WTS.WorkSuite.Service.Domain.HR.Employees.EmployeeImage.New {

    public class NewEmployeeImageFixture 
                    : ResponseCommandFixture<NewEmployeeImageRequest,NewEmployeeImageResponse, INewEmployeeImage> {
                    //: ARequestResponseCommandAndEntityFixture<NewEmployeeImageRequest, NewEmployeeImageResponse, INewEmployeeImage, Image> {


        public NewEmployeeImageFixture 
                       ( INewEmployeeImage the_command
                       , IRequestBuilder<NewEmployeeImageRequest> the_request_builder ) 
                : base ( the_command
                       , the_request_builder ) {}

    }
}
