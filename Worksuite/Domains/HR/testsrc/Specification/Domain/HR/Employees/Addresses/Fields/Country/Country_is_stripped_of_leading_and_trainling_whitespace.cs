using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Update;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Fields.Country {

    public class Country_is_stripped_of_leading_and_trainling_whitespace  {

        [TestClass]
        public class verify_on_create
                        : TextFieldHasLeadingAndTrailingWhitespaceStrippedSpecification<NewAddressRequest, NewAddressResponse, NewAddressFixture,Address> {

            public verify_on_create ()
                        : base ( ( request ) => request.country
                               , ( value, request ) => request.county = value
                               , ( entity ) => entity.country ) {}
                               
        }

        [TestClass]
        public class verify_on_update 
                        : TextFieldHasLeadingAndTrailingWhitespaceStrippedSpecification<UpdateAddressRequest, UpdateAddressResponse, UpdateAddressFixture,Address> {

            public verify_on_update () 
                        : base ( ( request ) => request.country
                               , ( value, request ) => request.country = value
                               , ( entity ) => entity.country ) {}
        }       
    }
}