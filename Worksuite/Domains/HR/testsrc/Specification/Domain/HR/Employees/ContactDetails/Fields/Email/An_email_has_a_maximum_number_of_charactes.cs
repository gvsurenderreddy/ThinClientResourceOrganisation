﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.ContactDetails.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Features.Update.UpdateCommand;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.ContactDetails.Fields.Email {

    public class An_email_has_a_maximum_number_of_charactes {

        [TestClass]
        public class verify_on_edit 
                        : IsEmailSpecification<UpdateRequest, UpdateResponse, UpdateFixture>  {

            public verify_on_edit()
                    : base((request, value) => request.email = value, request => request.email) {}
        }
    }
}
