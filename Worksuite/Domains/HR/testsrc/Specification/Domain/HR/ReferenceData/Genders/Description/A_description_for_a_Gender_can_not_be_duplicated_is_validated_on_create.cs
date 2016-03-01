﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Description {

    [TestClass]
    public class A_description_for_a_Gender_can_not_be_duplicated_is_validated_on_create
                    : A_description_can_not_be_duplicated_is_validated_on_create<Gender,CreateGenderRequest, CreateGenderResponse,ICreateGender,NewGenderFixture> {}

}