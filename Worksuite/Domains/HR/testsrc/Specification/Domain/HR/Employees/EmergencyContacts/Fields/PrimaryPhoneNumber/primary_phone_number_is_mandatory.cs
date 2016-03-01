using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.Update;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Fields.PrimaryPhoneNumber {

    public class primary_phone_number_is_mandatory {

        [TestClass]
        public class verify_on_create
                        : MandatoryTextFieldSpecification<NewEmergencyContactRequest, NewEmergencyContactResponse, NewEmergencyContactFixture> {

            public verify_on_create ()
                    : base( (request, value) => request.primary_phone_number = value ) { }
        }

        [TestClass]
        public class verify_on_edit
                        : MandatoryTextFieldSpecification<UpdateRequest, UpdateResponse, UpdateFixture> {

            public verify_on_edit()
                : base((request, value) => request.primary_phone_number = value) { }
        }        

    }
}