using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.Edit;
using WTS.WorkSuite.HR.HR.Employees.EmergencyContacts.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Features.Update;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmergencyContacts.Fields.Name {

    public class has_a_maximum_number_of_characters {

        [TestClass]
        public class verify_on_create
                        : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<NewEmergencyContactRequest, NewEmergencyContactResponse, NewEmergencyContactFixture> {

            public verify_on_create()
                    : base((request, value) => request.name = value) { }
        }


        [TestClass]
        public class verify_on_update
                        : TextFieldDoesNotExceedDefaultMaximumNumberOfCharactersSpecification<UpdateRequest, UpdateResponse, UpdateFixture> {

            public verify_on_update()
                    : base((request, value) => request.name = value) { }
        }

    }
}