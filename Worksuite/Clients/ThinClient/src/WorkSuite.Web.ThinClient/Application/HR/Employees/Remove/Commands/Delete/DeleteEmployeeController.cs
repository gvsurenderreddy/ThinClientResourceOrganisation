using System.Collections.Generic;
using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.DocumentStore.Documents;
using WTS.WorkSuite.HR.DocumentStore.Documents.Remove;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.GetAll;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.GetById;
using WTS.WorkSuite.HR.HR.Employees.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using System.Linq;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Remove.Commands.Delete {

    public class DeleteEmployeeController : Controller {

        public ActionResult SubmitRequest ( EmployeeIdentity remove_request ) {

            //cache the employees documents for deletion afterwards.
            var employee_image = get_employee_image.execute(remove_request);
            var documents = get_documents_to_delete(remove_request).ToList();
            
            var remove_response = remove_employee.execute( remove_request );

            if (remove_response.has_errors)
            {
                Response.StatusCode = 400;
            }
            else
            {

                delete_many_documents(documents);
                delete_document(employee_image.result.image_id);

                Response.StatusCode = 200;
            }



            return Json( remove_response, JsonRequestBehavior.AllowGet );
        }


        public DeleteEmployeeController(IRemoveEmployee remove_command
                                        , IGetAllEmployeeDocuments get_employee_documents
                                        , IRemoveManyDocuments remove_many_documents_command
                                        , IRemoveDocument remove_document_command
                                        , IGetImageOfAnEmployee get_image)
        {

            remove_employee = Guard.IsNotNull( remove_command, "remove_command" );
            get_all_employee_documents = Guard.IsNotNull(get_employee_documents, "get_employee_documents");
            remove_many_documents = Guard.IsNotNull(remove_many_documents_command, "remove_many_documents_command");
            get_employee_image = Guard.IsNotNull(get_image, "get_image");
            remove_document = Guard.IsNotNull(remove_document_command, "remove_document_command");
        }

        private readonly IRemoveEmployee remove_employee;

        private readonly IGetAllEmployeeDocuments get_all_employee_documents;

        private readonly IRemoveDocument remove_document;
        
        private readonly IRemoveManyDocuments remove_many_documents;

        private readonly IGetImageOfAnEmployee get_employee_image;



        private IEnumerable<DocumentIdentity> get_documents_to_delete(EmployeeIdentity employee_id)
        {

            var docs = get_all_employee_documents.execute(employee_id).result.ToList();

            var documents = docs.Select(dtls => new DocumentIdentity() {document_id = dtls.document_id});

            return documents;
        }


        private void delete_many_documents(IEnumerable<DocumentIdentity> documents)
        {
            remove_many_documents.execute(documents);
        }

        private void delete_document(int document_id)
        {
            remove_document.execute(new DocumentIdentity()
            {
                document_id = document_id
            });
        }
    }
}