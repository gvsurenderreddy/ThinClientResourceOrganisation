using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.GetCreateRequest
{
    /// <summary>
    ///     Creates a 'CreateSkillRequest' and fills it out with any default values.
    ///     This returns our standard response object.
    /// 
    ///     Default values:
    ///         'description' defaults to not specified to force user entry.
    ///         'is_hidden' defaults to false.
    /// </summary>

    public interface IGetCreateSkillRequest
                        : IGetCreateReferenceDataRequest<CreateSkillRequest, GetCreateSkillRequestResponse> {}
}
