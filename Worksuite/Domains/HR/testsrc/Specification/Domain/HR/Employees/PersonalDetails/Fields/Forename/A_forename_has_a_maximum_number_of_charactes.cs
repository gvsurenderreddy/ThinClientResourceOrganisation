﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.PersonalDetails.Fields.Forename {

    public class A_forename_has_a_maximum_number_of_charactes {

        [TestClass]
        public class verify_on_edit
                        : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<UpdateEmployeePersonalDetailsRequest, UpdateEmployeePersonalDetailsResponse, UpdateEmployeePersonalDetailsFixture> {

            public verify_on_edit ()
                    : base( (request, value) => request.forename = value ) { }
        }

    }
}