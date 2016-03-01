using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Service.Specification.Helpers.Specifications;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Notes.addNote.get.fields.note
{
    [TestClass]
    public class Note_is_returned_empty_to_force_user_entry : Specification<HRTestBootstrap>
    {
        [TestMethod]
        public void verify()
        {
            //Arrange
            test_setup();

            //Act
            fixture.execute_command();

            //Assert
            Assert.IsTrue(fixture.response.result.note == string.Empty);
        }

        private void test_setup()
        {
            fixture = DependencyResolver.resolve<GetAddNoteRequestHandler_fixture>();
        }

        private GetAddNoteRequestHandler_fixture fixture;
    }
}
