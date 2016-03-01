using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.DocumentStore
{
    public class Document : BaseEntity<int>
    {
        public string name { get; set; }
        public byte[] data { get; set; }
        public string content_type { get; set; }
        public string md5_value { get; set; }
    }
}