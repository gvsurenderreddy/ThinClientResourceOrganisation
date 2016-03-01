using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.GetById
{

    [TestClass]
    public class Correctly_maps_the_fields : GetByIdFixture
    {
        [TestMethod]
        public void correctly_maps_the_document_name()
        {
            var document = add_document()
                                .name("document")
                                .entity;

            var response = execute_query(document);

            Assert.AreEqual(document.name, response.result.name);
        }

        [TestMethod]
        public void correctly_maps_the_documents_content_type()
        {
            var document = add_document()
                                .content_type("content-type")
                                .entity;

            var response = execute_query(document);

            Assert.AreEqual(document.content_type, response.result.content_type);

        }

        [TestMethod]
        public void correctly_maps_the_md5_value_when_the_document_has_one()
        {
            var document = add_document()
                                .md5_value("f45tyu89276438h")
                                .entity;

            var response = execute_query(document);

            Assert.AreEqual(document.md5_value, response.result.md5_value);
        }

        [TestMethod]
        public void correctly_maps_the_binary_data_when_the_document_has_one()
        {
            var document = add_document()
                                .data(new byte[] { 0x20, 0x20, 0x20 })
                                .entity;

            var response = execute_query(document);

            Assert.AreEqual(document.data[0], response.result.data[0]);
            Assert.AreEqual(document.data[1], response.result.data[1]);
            Assert.AreEqual(document.data[2], response.result.data[2]);
        }

    }

}