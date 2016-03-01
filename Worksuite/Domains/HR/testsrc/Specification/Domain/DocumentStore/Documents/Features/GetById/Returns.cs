using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WTS.WorkSuite.HR.Services.Domain.DocumentStore.Documents.Features.GetById
{

    [TestClass]
    public class Returns : GetByIdFixture
    {

        // return a personal details of the employee
        [TestMethod]
        public void return_details_of_a_specific_document()
        {
            var document = add_document().entity;
            var response = execute_query(document);

            Assert.AreEqual(document.id, response.result.document_id);
        }

    }

}