using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Fields.Description
{
    public class Description_is_restricted_to_the_default_maximum_number_of_characters
    {

        [TestClass]
        public class verify_on_create
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_create<  Nationality,
                                                                                                            CreateNationalityRequest,
                                                                                                            CreateNationalityResponse,
                                                                                                            ICreateNationality,
                                                                                                            NewNationalityFixture
                                                                                                         > {}

        [TestClass]
        public class verify_on_update
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_update<  Nationality,
                                                                                                            UpdateNationalityRequest,
                                                                                                            UpdateNationalityResponse,
                                                                                                            IUpdateNationality,
                                                                                                            UpdateNationalityFixture
                                                                                                         > {}
    }
}