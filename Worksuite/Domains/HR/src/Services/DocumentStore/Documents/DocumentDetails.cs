namespace WTS.WorkSuite.HR.DocumentStore.Documents
{
    public class DocumentDetails : DocumentIdentity
    {
        public string name { get; set; }
        public byte[] data { get; set; }
        public string content_type { get; set; }
        public string md5_value { get; set; }
    }
}