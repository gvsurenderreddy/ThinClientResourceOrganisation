using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Queries
{
    /// <summary>
    ///     Get full details of all the nationalities in the system
    /// </summary>
    public interface IGetDetailsOfAllNationalities
                            : IGetDetailsOfAllReferenceData< NationalityDetails > {}
}