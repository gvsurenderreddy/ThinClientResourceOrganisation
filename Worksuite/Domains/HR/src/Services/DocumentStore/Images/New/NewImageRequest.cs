using WTS.WorkSuite.Service.HR.Employees;

namespace WTS.WorkSuite.Service.DocumentStore.Images.New
{
    public class NewImageRequest : ImageIdentity
    {
        public bool isDefault { get; set; }
        public byte[] data { get; set; }
    }
}
