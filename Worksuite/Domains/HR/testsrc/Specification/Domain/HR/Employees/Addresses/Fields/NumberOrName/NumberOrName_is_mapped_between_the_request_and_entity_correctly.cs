using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Update;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Fields.NumberOrName {


    public class NumberOrName_is_mapped_between_the_request_and_entity_correctly {
        
        [TestClass]
        public class verify_on_create 
                      : FieldIsMappedCorrectlySpecification<NewAddressRequest, NewAddressResponse, NewAddressFixture, Address> {

            protected override bool validate 
                                        ( NewAddressRequest request
                                        , Address entity ) {

              return request.number_or_name == entity.number_or_name;
          }

        }


        [TestClass]
        public class verify_on_edit 
                      : FieldIsMappedCorrectlySpecification<UpdateAddressRequest, UpdateAddressResponse, UpdateAddressFixture, Address> {

            protected override bool validate 
                                        ( UpdateAddressRequest request
                                        , Address entity ) {

                return request.number_or_name == entity.number_or_name;
            }

        }
    }
}