﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Update;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Fields.Postcode {

    public class Postcode_is_restricted_to_a_maximum_number_of_character {
        
        [TestClass]
        public class verify_on_create
                        : PostCodeTextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<NewAddressRequest, NewAddressResponse, NewAddressFixture> {

            public verify_on_create()
                        : base( (request, value) => request.postcode = value) { }
        }

        [TestClass]
        public class verify_on_update
                        : PostCodeTextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<UpdateAddressRequest, UpdateAddressResponse, UpdateAddressFixture> {

            public verify_on_update ()
                        : base( (request, value) => request.postcode = value ) { }
        }

    }
}
