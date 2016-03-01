using System.Web.Mvc;
using WTS.WorkSuite.HR.DocumentStore.Documents;
using WTS.WorkSuite.HR.DocumentStore.Documents.New;
using WTS.WorkSuite.HR.DocumentStore.Documents.Remove;
using WTS.WorkSuite.HR.HR.Employees.EmployeeDocuments.New;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.IO;
using WTS.WorkSuite.Library.IO.Cryptography;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeDocuments.Commands.Create
{
    public class CreateEmployeeDocumentController : Controller
    {
        public ActionResult SubmitRequest(NewEmployeeDocumentRequest create_request)
        {
            var create_document_response = create_new_document();

            if (!create_document_response.has_errors)
            {
                create_request.document_id = create_document_response.result.document_id;
                create_request.md5_hash = md5_value;
                create_request.content_type = content_type;
                create_request.name = file_name;

                var create_response = create_employee_document.execute(create_request);
                
                if (create_response.has_errors)
                {
                    delete_document(create_request.document_id);
                }
                
                Response.StatusCode = create_response.has_errors ? 400 : 200;
                return Json(create_response, JsonRequestBehavior.AllowGet);
            }


            Response.StatusCode = 400;
            return Json(create_document_response, JsonRequestBehavior.AllowGet);
        }

        public CreateEmployeeDocumentController(INewEmployeeDocument create_command
                                                , INewDocument document_create_command
                                                , IRemoveDocument document_remove_command)
        {
            create_employee_document = Guard.IsNotNull(create_command, "create_command");

            create_document = Guard.IsNotNull(document_create_command, "document_create_command");

            remove_document = Guard.IsNotNull(document_remove_command, "document_remove_command");
        }

        private readonly INewEmployeeDocument create_employee_document;
        private readonly IRemoveDocument remove_document;
        private readonly INewDocument create_document;
        private byte[] file_data = null;
        private string content_type = string.Empty;
        private string file_name = string.Empty;
        private string md5_value = string.Empty;


        private NewDocumentResponse create_new_document()
        {
            var posted_File = Request.Files["data"];

            if (posted_File != null)
            {
                content_type = posted_File.ContentType;
                file_name = posted_File.FileName;
                file_data = FileHelper.get_file_as_byte_array_from_stream(posted_File.InputStream);
                md5_value = new FileHelper().GetMD5Value(file_data);
            }


            var create_document_response = create_document.execute(new NewDocumentRequest()
            {
                data = file_data,
                content_type = content_type,
                name = file_name
            });

            return create_document_response;
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