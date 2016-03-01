using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Description
{
    public class Description_is_restricted_to_the_default_maximum_number_of_characters
    {
        [TestClass]
        public class verify_on_create
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_create<   Gender,
                                                                                                            CreateGenderRequest,
                                                                                                            CreateGenderResponse,
                                                                                                            ICreateGender,
                                                                                                            NewGenderFixture
                                                                                                         > { }

        [TestClass]
        public class verify_on_update
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_update<  Gender,
                                                                                                            UpdateGenderRequest,
                                                                                                            UpdateGenderResponse,
                                                                                                            IUpdateGender,
                                                                                                            UpdateGenderFixture
                                                                                                         > { }
    }
}