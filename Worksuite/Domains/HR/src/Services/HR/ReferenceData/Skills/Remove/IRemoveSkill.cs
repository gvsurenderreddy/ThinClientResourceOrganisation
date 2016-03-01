using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.Remove
{
    /// <summary>
    ///     Removes the skill specified in the supplied request.
    ///     It is not considered an error if the skill does not exist.
    /// </summary>
    public interface IRemoveSkill
        :   IRemoveReferenceData<RemoveSkillRequest, RemoveSkillResponse> {}
}
