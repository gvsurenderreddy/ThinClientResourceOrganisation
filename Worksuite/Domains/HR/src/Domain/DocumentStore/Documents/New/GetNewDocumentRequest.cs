namespace WTS.WorkSuite.HR.DocumentStore.Documents.New
{
    class GetNewDocumentRequest : IGetNewDocumentRequest
    {
        public NewDocumentRequest execute()
        {
            return new NewDocumentRequest
            {
                name = string.Empty,
                data = null,
                content_type = string.Empty
            };
        }
    }
}
