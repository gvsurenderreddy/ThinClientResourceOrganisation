using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Update;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Fields.Line3 {

    public class Line3_is_restricted_to_the_default_maximum_number_of_charactes {
        
        [TestClass]
        public class verify_on_create
                        : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<NewAddressRequest, NewAddressResponse, NewAddressFixture> {

            public verify_on_create()
                    : base( (request, value) => request.line_three = value) { }
        }

        [TestClass]
        public class verify_on_update
                        : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<UpdateAddressRequest, UpdateAddressResponse, UpdateAddressFixture> {

            public verify_on_update ()
                    : base( (request, value) => request.line_three = value) { }
        }
    } 
}
