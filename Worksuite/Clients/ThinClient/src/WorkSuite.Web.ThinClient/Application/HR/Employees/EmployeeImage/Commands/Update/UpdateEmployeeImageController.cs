using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.DocumentStore.Documents;
using WTS.WorkSuite.HR.DocumentStore.Documents.New;
using WTS.WorkSuite.HR.DocumentStore.Documents.Remove;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Edit;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.GetById;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.IO;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeImage.Commands.Update
{
    public class UpdateEmployeeImageController : Controller
    {

        public UpdateEmployeeImageController(IUpdate update_image_command
                                            , INewDocument create_document_command
                                            , IRemoveDocument remove_document_command
                                            , IGetImageOfAnEmployee get_image)
        {
            update_employee_image = Guard.IsNotNull(update_image_command, "update_command");
            create_document = Guard.IsNotNull(create_document_command, "create_command");
            remove_document = Guard.IsNotNull(remove_document_command, "remove_document_command");
            get_employee_image = Guard.IsNotNull(get_image, "get_image");
        }


        public ActionResult SubmitRequest(EmployeeIdentity request)
        {
            var employee_image = get_employee_image.execute(request).result.image_id;

            //create a new Document and return the ID
            var create_document_response = create_new_document();

            if (!create_document_response.has_errors)
            {
                var updateRequest = new UpdateRequest()
                {
                    image_id = create_document_response.result.document_id,
                     employee_id = request.employee_id
                };

                var update_image_response = update_employee_image.execute(updateRequest);

                if (update_image_response.has_errors)
                {
                    delete_document(updateRequest.image_id);
                }
                else
                {
                    delete_document(employee_image);
                }

                Response.StatusCode = update_image_response.has_errors ? 400 : 200;
                return Json(update_image_response, JsonRequestBehavior.AllowGet);
            }

            Response.StatusCode = 400;
            return Json(create_document_response, JsonRequestBehavior.AllowGet);
        }

        private void delete_document(int document_id)
        {
            if (document_id != Null.Id)
            {
                remove_document.execute(new DocumentIdentity()
                {
                    document_id = document_id
                });
            }
        }


        private NewDocumentResponse create_new_document()
        {
            var posted_File = Request.Files["data"];

            if (posted_File != null)
            {
                content_type = posted_File.ContentType;
                file_name = posted_File.FileName;
                file_data = FileHelper.get_file_as_byte_array_from_stream(posted_File.InputStream);
            }


            var create_document_response = create_document.execute(new NewDocumentRequest()
            {
                data = file_data,
                content_type = content_type,
                name = file_name
            });

            return create_document_response;
        }

        private readonly IUpdate update_employee_image;
        private readonly INewDocument create_document;
        private readonly IRemoveDocument remove_document;
        private readonly IGetImageOfAnEmployee get_employee_image;
        private byte[] file_data = null;
        private string content_type = string.Empty;
        private string file_name = string.Empty;
    }
}
