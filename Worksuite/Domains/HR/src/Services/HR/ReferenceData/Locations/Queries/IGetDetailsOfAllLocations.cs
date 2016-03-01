using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.Queries
{
    /// <summary>
    ///     Get the full details of all locations in the system.
    /// </summary>
    public interface IGetDetailsOfAllLocations
                        : IGetDetailsOfAllReferenceData<LocationDetails> { }
}