using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.HR.HR.Employees.Notes.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.New {

    public class A_Note_is_mandatory {

        
        [TestClass]
        public class A_Note_is_specified_when_adding_an_note 
                        : FieldIsMappedCorrectlySpecification<NewNoteRequest, NewNoteResponse, NewNoteFixture, Note> {

            protected override bool validate
                                        ( NewNoteRequest request
                                        , Note entity ) {

                return request.note == entity.Notes;
            }
        }

    }
}