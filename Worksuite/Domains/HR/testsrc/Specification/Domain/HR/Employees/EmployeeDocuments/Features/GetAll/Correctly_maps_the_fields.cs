using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.EmployeeDocuments.Features.GetAll {

    [TestClass]
    public class Correctly_maps_the_fields : GetAllFixture
    {
        [TestMethod]
        public void maps_the_employee_documents_name()
        {
            var employee_document = employee_document_builder.name("A name").entity;
            var employee = add_employee()
                              .forename("Fred")
                              .employee_document(employee_document)
                              .entity
                              ;

            var response = query.execute(new EmployeeIdentity { employee_id = employee.id }).result.First();

            Assert.IsTrue(response.name == employee_document.name);
        }

        [TestMethod]
        public void maps_the_employee_documents_content_type()
        {
            
            var employee_document = employee_document_builder.content_type("content/type").entity;
            
            var employee = add_employee()
                              .forename("Fred")
                              .employee_document(employee_document)
                              .entity
                              ;

            var response = query.execute(new EmployeeIdentity { employee_id = employee.id }).result.First();

            Assert.IsTrue(response.content_type == employee_document.content_type);
        }

        [TestMethod]
        public void correctly_maps_the_md5_value_when_the_document_has_one()
        {
            var employee_document = employee_document_builder.name("A name").md5_hash("jhsghsgfshsg").entity;

            var employee = add_employee()
                             .forename("Fred")
                             .employee_document(employee_document)
                             .entity
                             ;

            var response = query.execute(new EmployeeIdentity { employee_id = employee.id }).result.First();

            Assert.IsTrue(response.md5_value == employee_document.md5_hash);
        }

        [TestMethod]
        public void correctly_maps_the_document_id_value_when_the_document_has_one()
        {
            var employee_document = employee_document_builder.name("A name").document_id(1).entity;

            var employee = add_employee()
                             .forename("Fred")
                             .employee_document(employee_document)
                             .entity
                             ;

            var response = query.execute(new EmployeeIdentity { employee_id = employee.id }).result.First();

            Assert.IsTrue(response.document_id == employee_document.document_id);
        }
        
    }
 }