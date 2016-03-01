using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.New
{
    public interface IGetNewNoteRequest : ICommand<EmployeeIdentity, NewNoteRequest> { }
}