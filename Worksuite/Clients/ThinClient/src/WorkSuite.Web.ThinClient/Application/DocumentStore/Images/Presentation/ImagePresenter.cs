using System.Reflection;
using System.Web.Mvc;
using WTS.WorkSuite.HR.DocumentStore.Documents;
using WTS.WorkSuite.HR.DocumentStore.Documents.GetById;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.IO;

namespace WTS.WorkSuite.Web.ThinClient.Application.DocumentStore.Images.Presentation
{
    public class ImagePresenter : Presenter
    {

        public ActionResult Image(int document_id)
        {
            var data = document_id == Null.Id ? default_image() : get_document_by_id.execute(new DocumentIdentity() { document_id = document_id }).result.data;
            return File(data, "Image/jpg");
        }

        public ImagePresenter(IGetDocumentById get_document)
        {
            Guard.IsNotNull(get_document, "get_document");

            get_document_by_id = get_document;
        }


        private static byte[] default_image()
        {
            byte[] data;

            var myAssembly = Assembly.GetExecutingAssembly();

            using (var myStream = myAssembly.GetManifestResourceStream("WTS.WorkSuite.Web.ThinClient.Application.DocumentStore.Images.Presentation.employee_blank.png"))
            {
                data = FileHelper.get_file_as_byte_array_from_stream(myStream);
            }
            return data;
        }


        private readonly IGetDocumentById get_document_by_id;
    }
}