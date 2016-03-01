﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Nationalities.Fields.Description
{
    [TestClass]
    public class The_description_for_a_nationality_is_sanatised_when_creating
                        : A_description_is_mandatory_on_create< Nationality, CreateNationalityRequest, CreateNationalityResponse, ICreateNationality, NewNationalityFixture > {}
}