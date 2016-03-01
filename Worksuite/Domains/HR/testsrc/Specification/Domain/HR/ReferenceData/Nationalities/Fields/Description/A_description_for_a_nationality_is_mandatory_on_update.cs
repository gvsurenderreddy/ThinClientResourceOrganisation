using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Fields.Description
{
    [TestClass]
    public class A_description_for_a_nationality_is_mandatory_on_update
                            : A_description_is_mandatory_on_update< Nationality,
                                                                    UpdateNationalityRequest,
                                                                    UpdateNationalityResponse,
                                                                    IUpdateNationality,
                                                                    UpdateNationalityFixture
                                                                  > { }
}