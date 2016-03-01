using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Fields.Description
{
    [TestClass]
    public class The_description_for_a_nationality_is_sanatised_when_updating
                        : The_description_is_sanatised_when_updating< Nationality, UpdateNationalityRequest, UpdateNationalityResponse, IUpdateNationality, UpdateNationalityFixture > {}
}