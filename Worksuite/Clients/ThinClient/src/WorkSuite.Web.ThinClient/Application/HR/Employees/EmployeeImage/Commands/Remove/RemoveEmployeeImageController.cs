using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.DocumentStore.Documents;
using WTS.WorkSuite.HR.DocumentStore.Documents.Remove;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.GetById;
using WTS.WorkSuite.HR.HR.Employees.EmployeeImage.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.EmployeeImage.Commands.Remove
{
    public class RemoveEmployeeImageController : Controller
    {
        public RemoveEmployeeImageController(IRemove Remove_image_command
                                            , IRemoveDocument remove_document_command
                                            , IGetImageOfAnEmployee get_image)
        {
            Remove_employee_image = Guard.IsNotNull(Remove_image_command, "Remove_command");
            remove_document = Guard.IsNotNull(remove_document_command, "remove_document_command");
            get_employee_image = Guard.IsNotNull(get_image, "get_image");
        }


        public ActionResult SubmitRequest(EmployeeIdentity remove_request)
        {
            var employee_image = get_employee_image.execute(remove_request);

            var remove_image_response = Remove_employee_image.execute(remove_request);

            if (!remove_image_response.has_errors)
            {
                delete_document(employee_image.result.image_id);
            }

            Response.StatusCode = remove_image_response.has_errors ? 400 : 200;
            return Json(remove_image_response, JsonRequestBehavior.AllowGet);

        }

        private void delete_document(int document_id)
        {
            remove_document.execute(new DocumentIdentity()
            {
                document_id = document_id
            });
        }

        private readonly IRemove Remove_employee_image;
        private readonly IRemoveDocument remove_document;
        private readonly IGetImageOfAnEmployee get_employee_image;
    }
}