using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.Create
{
    /// <summary>
    ///     Provide a service to create a new qualification reference data, if the request is valid.
    /// </summary>
    public interface ICreateQualification
                            : ICreateReferenceData<CreateQualificationRequest, CreateQualificationResponse > { }
}
