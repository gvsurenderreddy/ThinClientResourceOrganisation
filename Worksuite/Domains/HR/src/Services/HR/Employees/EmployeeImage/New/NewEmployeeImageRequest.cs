namespace WTS.WorkSuite.Service.HR.Employees.EmployeeImage.New
{
    public class NewEmployeeImageRequest : EmployeeImageIdentity
    {
        public bool isDefault { get; set; }
        public byte[] data { get; set; }
    }
}
