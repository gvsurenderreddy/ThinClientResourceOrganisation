using System.Collections.Generic;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.HR.Employees.Notes.GetAll
{
    public interface IGetAllNotes : IQuery<EmployeeIdentity, Response<IEnumerable<EmployeeNoteDetails>>> { }
}