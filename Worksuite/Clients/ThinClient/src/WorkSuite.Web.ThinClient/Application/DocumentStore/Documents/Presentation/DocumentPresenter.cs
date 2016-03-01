using System.Net.Mime;
using System.Web.Mvc;
using WTS.WorkSuite.HR.DocumentStore.Documents;
using WTS.WorkSuite.HR.DocumentStore.Documents.GetById;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.DocumentStore.Documents.Presentation
{
    public class DocumentPresenter : Presenter
    {
        public ActionResult Download(int document_id)
        {
            var document = get_document.execute(new DocumentIdentity { document_id = document_id }).result;

            Response.AppendHeader("Content-Disposition", new ContentDisposition
            {
                FileName = document.name,
                // always prompt the user for downloading, set to true if you want 
                // the browser to try to show the file inline
                Inline = false,
            }.ToString());
            return File(document.data, document.content_type);
        }

        public DocumentPresenter(IGetDocumentById document_query)
        {
            get_document = Guard.IsNotNull(document_query, "document_query");
        }

        private readonly IGetDocumentById get_document;
    }
}