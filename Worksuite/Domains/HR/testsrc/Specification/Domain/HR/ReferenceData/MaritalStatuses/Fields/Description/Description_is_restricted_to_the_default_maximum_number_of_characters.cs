using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Features.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.MaritalStatuses.Fields.Description
{
    public class Description_is_restricted_to_the_default_maximum_number_of_characters
    {
        [TestClass]
        public class verify_on_create
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_create<  MaritalStatus,
                                                                                                            CreateMaritalStatusRequest,
                                                                                                            CreateMaritalStatusResponse,
                                                                                                            ICreateMaritalStatus,
                                                                                                            NewMaritalStatusFixture
                                                                                                         > { }

        [TestClass]
        public class verify_on_update
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_update<  MaritalStatus,
                                                                                                            UpdateMaritalStatusRequest,
                                                                                                            UpdateMaritalStatusResponse,
                                                                                                            IUpdateMaritalStatus,
                                                                                                            UpdateMaritalStatusFixture
                                                                                                        > { }
    }
}