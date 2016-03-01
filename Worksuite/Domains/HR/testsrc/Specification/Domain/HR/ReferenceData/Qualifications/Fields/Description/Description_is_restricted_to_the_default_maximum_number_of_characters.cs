using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Fields.Description
{
    public class Description_is_restricted_to_the_default_maximum_number_of_characters
    {
        [TestClass]
        public class verify_on_create
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_create<  Qualification,
                                                                                                            CreateQualificationRequest,
                                                                                                            CreateQualificationResponse,
                                                                                                            ICreateQualification,
                                                                                                            NewQualificationFixture
                                                                                                         > { }

        [TestClass]
        public class verify_on_update
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_update<  Qualification,
                                                                                                            UpdateQualificationRequest,
                                                                                                            UpdateQualificationResponse,
                                                                                                            IUpdateQualification,
                                                                                                            UpdateQualificationFixture
                                                                                                        > { }
    }
}