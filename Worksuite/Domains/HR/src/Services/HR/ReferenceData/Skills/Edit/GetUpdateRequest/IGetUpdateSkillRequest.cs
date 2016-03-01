using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.Edit.GetUpdateRequest
{
    /// <summary>
    ///     Creates an 'UpdateSkillRequest' object with the values of the skill that is to be edited.
    ///     This returns our standard response object.
    /// 
    ///     If the skill does not exits then an null object is returned and the response is set to have errors.
    /// </summary>
    public interface IGetUpdateSkillRequest
        :   IGetUpdateReferenceDataRequest<UpdateSkillRequest, GetUpdateSkillRequestResponse> {}
}
