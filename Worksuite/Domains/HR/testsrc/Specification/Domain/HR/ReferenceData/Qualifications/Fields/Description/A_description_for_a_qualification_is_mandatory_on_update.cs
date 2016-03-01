﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Qualifications.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Features.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Qualifications.Fields.Description
{
    [TestClass]
    public class A_description_for_a_qualification_is_mandatory_on_update
                        : A_description_is_mandatory_on_update< Qualification,
                                                                UpdateQualificationRequest,
                                                                UpdateQualificationResponse,
                                                                IUpdateQualification,
                                                                UpdateQualificationFixture
                                                              > { }
}