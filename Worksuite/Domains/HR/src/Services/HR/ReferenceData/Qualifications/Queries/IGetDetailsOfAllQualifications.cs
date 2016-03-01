using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Queries
{
    /// <summary>
    ///     Get full details of all the qualifications in the system
    /// </summary>
    public interface IGetDetailsOfAllQualifications
                        : IGetDetailsOfAllReferenceData< QualificationDetails > {}
}
