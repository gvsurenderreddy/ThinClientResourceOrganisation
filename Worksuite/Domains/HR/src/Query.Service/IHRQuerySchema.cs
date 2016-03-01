using System.Linq;

namespace WTS.WorkSuite.HR.Query
{
    /// <summary>
    ///     Schema that allows you to query the HR data.
    /// </summary>
    public interface IHRQuerySchema
    {
        IQueryable<EmployeeView> employees { get; }
    }
}
