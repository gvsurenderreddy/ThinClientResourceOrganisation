using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Update;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Fields.Country {

    public class Country_can_be_specified_when_editing_an_address
                        : FieldIsMappedCorrectlySpecification<UpdateAddressRequest, UpdateAddressResponse, UpdateAddressFixture, Address> {


        protected override bool validate 
                                    ( UpdateAddressRequest request
                                    , Address entity ) {

            return request.country == entity.country;
        }
    }
}