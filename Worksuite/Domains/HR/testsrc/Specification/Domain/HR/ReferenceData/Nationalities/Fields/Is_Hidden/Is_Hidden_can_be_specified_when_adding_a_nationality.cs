using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Is_Hidden;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Fields.Is_Hidden
{
    [TestClass]
    public class Is_Hidden_can_be_specified_when_adding_a_nationality
                    : Is_Hidden_can_be_specified_when_adding_a_new_entry< Nationality, CreateNationalityRequest, CreateNationalityResponse, ICreateNationality, NewNationalityFixture > {}
}