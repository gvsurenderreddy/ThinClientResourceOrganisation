using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New.Create
{
    /// <summary>
    ///     Provide a service to create a nationality reference data, if the request is valid.
    /// </summary>
    public interface ICreateNationality
                            : ICreateReferenceData< CreateNationalityRequest, CreateNationalityResponse > {}
}
