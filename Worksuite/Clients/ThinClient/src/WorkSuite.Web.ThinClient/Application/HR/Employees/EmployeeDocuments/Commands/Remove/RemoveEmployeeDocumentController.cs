using System.Web.Mvc;
using WTS.WorkSuite.HR.DocumentStore.Documents;
using WTS.WorkSuite.HR.DocumentStore.Documents.Remove;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDocuments.Commands.Remove
{
    public class RemoveEmployeeDocumentController : Controller
    {
        public ActionResult SubmitRequest ( EmployeeDocumentIdentity remove_request, int document_id ) {

            var remove_response = remove.execute( remove_request );

            if (!remove_response.has_errors)
            {
                remove_document.execute(new DocumentIdentity {document_id = document_id});
            }

            Response.StatusCode = remove_response.has_errors ? 400 : 200;
            return Json( remove_response, JsonRequestBehavior.AllowGet );
        }


        public RemoveEmployeeDocumentController(IRemoveEmployeeDocument remove_command, IRemoveDocument the_remove_document)
        {
            remove = Guard.IsNotNull( remove_command, "remove_command" );
            remove_document = Guard.IsNotNull(the_remove_document, "the_remove_document");
        }

        private readonly IRemoveEmployeeDocument remove;
        private readonly IRemoveDocument remove_document;
    }
}