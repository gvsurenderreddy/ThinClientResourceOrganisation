using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Fields.NumberOrName {


    public class NumberOrName_is_restricted_to_the_default_maximum_number_of_charactes {

        [TestClass]
        public class verify_on_create
                        : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<NewAddressRequest, NewAddressResponse, NewAddressFixture> {

            public verify_on_create()
                : base((request, value) => request.number_or_name = value) { }
        }

        [TestClass]
        public class verify_on_edit
                        : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<NewAddressRequest, NewAddressResponse, NewAddressFixture> {

            public verify_on_edit()
                : base((request, value) => request.number_or_name = value) { }
        }
    }
}