using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.HR.DocumentStore;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.DocumentStore.Documents
{
    /// <summary>
    /// A fluent interface that makes building an Employee Model very simple.
    /// </summary>
    public class DocumentBuilder : IEntityBuilder<Document>
    {
        public Document entity
        {
            get { return document; }
        }

        public DocumentBuilder data(byte[] value)
        {
            document.data = value;
            return this;
        }

        public DocumentBuilder content_type(string value)
        {
            document.content_type = value;
            return this;
        }

        public DocumentBuilder md5_value(string value)
        {
            document.md5_value = value;
            return this;
        }

        public DocumentBuilder name(string value)
        {
            document.name = value;
            return this;
        }


        public DocumentBuilder(Document the_document)
        {
            Guard.IsNotNull(the_document, "the_document");

            document = new Document()
            {
                id = the_document.id,
                content_type = the_document.content_type,
                data = the_document.data,
                md5_value = the_document.md5_value,
                name = the_document.name 
            };
        }

        private readonly Document document;
    }
}