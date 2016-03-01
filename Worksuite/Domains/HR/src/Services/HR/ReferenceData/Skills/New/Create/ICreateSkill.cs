using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Skills.New.Create
{
    /// <summary>
    ///     Provide a service to create a new skill reference data, if the request is valid.
    /// </summary>
    public interface ICreateSkill
                            :   ICreateReferenceData<CreateSkillRequest, CreateSkillResponse> {}
}
