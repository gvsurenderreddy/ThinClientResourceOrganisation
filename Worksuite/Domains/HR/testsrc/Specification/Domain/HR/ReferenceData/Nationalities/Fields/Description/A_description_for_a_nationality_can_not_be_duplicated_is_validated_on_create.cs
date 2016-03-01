using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Fields.Description
{
    [TestClass]
    public class A_description_for_a_nationality_can_not_be_duplicated_is_validated_on_create
                        : A_description_can_not_be_duplicated_is_validated_on_create< Nationality, CreateNationalityRequest, CreateNationalityResponse, ICreateNationality, NewNationalityFixture > {}
}