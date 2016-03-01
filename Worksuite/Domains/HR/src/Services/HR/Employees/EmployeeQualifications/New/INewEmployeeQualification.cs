using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New
{
    public interface INewEmployeeQualification
                            : IResponseCommand< NewEmployeeQualificationRequest,
                                                NewEmployeeQualificationResponse
                                              > {}
}