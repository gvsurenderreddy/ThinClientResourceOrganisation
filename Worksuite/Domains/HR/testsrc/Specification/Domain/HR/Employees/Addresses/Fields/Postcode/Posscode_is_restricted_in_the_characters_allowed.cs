﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Update;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Fields.Postcode {

    public class Posscode_is_restricted_in_the_characters_allowed {

        [TestClass]
        public class verify_on_create 
                        : IsAPostCodeSpecification<NewAddressRequest, NewAddressResponse, NewAddressFixture> {

            public verify_on_create ()
                    : base( ( request, value ) => request.postcode = value
                          , ( request ) => request.postcode ) { }
           
        }

        [TestClass]
        public class verify_on_update 
                        : IsAPostCodeSpecification<UpdateAddressRequest, UpdateAddressResponse, UpdateAddressFixture> {

            public verify_on_update ()
                    : base( ( request, value ) => request.postcode = value
                          , ( request ) => request.postcode ) { }
           
        }
    }
}