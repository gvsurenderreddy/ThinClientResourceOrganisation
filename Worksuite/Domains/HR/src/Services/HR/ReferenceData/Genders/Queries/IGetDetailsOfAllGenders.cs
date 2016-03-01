using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Genders.Queries {

    /// <summary>
    ///     Get the full details of all genders in the system
    /// </summary>
    public interface IGetDetailsOfAllGenders 
                        : IGetDetailsOfAllReferenceData<GenderDetails>  { }

}