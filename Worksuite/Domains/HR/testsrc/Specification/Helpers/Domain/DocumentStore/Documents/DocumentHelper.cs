using System.Reflection;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.HR.DocumentStore;
using WTS.WorkSuite.Library.IO;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.DocumentStore.Documents
{
    public class DocumentHelper : EnityHelper<Document, int, DocumentBuilder, FakeDocumentRepository>
    {


        public static byte[] valid_document()
        {
            return new DocumentHelper().valid_docx_document();
        }



        public static byte[] invalid_document()
        {
            return new byte[] { };
        }


        private byte[] valid_docx_document()
        {
            byte[] data;

            var myAssembly = Assembly.GetExecutingAssembly();

            //using (var myStream = myAssembly.GetManifestResourceStream("WTS.WorkSuite.Service.Helpers.Domain.DocumentStore.Documents.Testing.docx"))
            //using (var myStream = myAssembly.GetManifestResourceStream("WTS.WorkSuite.HR.Services.Specification.Helpers.Domain.DocumentStore.Documents.Testing.docx"))
            using (var myStream = myAssembly.GetManifestResourceStream("WTS.WorkSuite.HR.Services.Helpers.Domain.DocumentStore.Documents.Testing.docx"))
            {
                data = FileHelper.get_file_as_byte_array_from_stream(myStream);
            }
            return data;
        }
    }
}