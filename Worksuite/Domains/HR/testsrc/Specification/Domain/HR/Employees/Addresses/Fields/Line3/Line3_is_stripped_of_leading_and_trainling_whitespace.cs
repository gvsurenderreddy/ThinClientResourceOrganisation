using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Update;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Fields.Line3 {

    public class Line3_is_stripped_of_leading_and_trainling_whitespace  {

        [TestClass]
        public class verify_on_create
                        : TextFieldHasLeadingAndTrailingWhitespaceStrippedSpecification<NewAddressRequest, NewAddressResponse, NewAddressFixture,Address> {

            public verify_on_create ()
                        : base ( ( request ) => request.line_three
                               , ( value, request ) => request.line_three = value
                               , ( entity ) => entity.line_three ) {}
                               
        }

        [TestClass]
        public class verify_on_update 
                        : TextFieldHasLeadingAndTrailingWhitespaceStrippedSpecification<UpdateAddressRequest, UpdateAddressResponse, UpdateAddressFixture,Address> {

            public verify_on_update () 
                        : base ( ( request ) => request.line_three
                               , ( value, request ) => request.line_three = value
                               , ( entity ) => entity.line_three ) {}
        }       
    }
}