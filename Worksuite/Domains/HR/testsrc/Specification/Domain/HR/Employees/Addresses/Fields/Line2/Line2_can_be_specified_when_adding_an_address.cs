using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Fields.Line2 {

    public class Line2_can_be_specified_when_adding_an_address
                        : FieldIsMappedCorrectlySpecification<NewAddressRequest, NewAddressResponse, NewAddressFixture, Address> {

            protected override bool validate
                                        ( NewAddressRequest request
                                        , Address entity ) {

                return request.line_two == entity.line_two;
            }
    }
}