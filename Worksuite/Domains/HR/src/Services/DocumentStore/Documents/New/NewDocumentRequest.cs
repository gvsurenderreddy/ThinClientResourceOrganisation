namespace WTS.WorkSuite.HR.DocumentStore.Documents.New
{
    public class NewDocumentRequest
    {
        public string name { get; set; }
        public byte[] data { get; set; }
        public string content_type { get; set; }
    }
}