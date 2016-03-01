using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Fields.Description
{
    public class Description_is_restricted_to_the_default_maximum_number_of_characters
    {
        [TestClass]
        public class verify_on_create
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_create<   EthnicOrigin,
                                                                                                            CreateEthnicOriginRequest,
                                                                                                            CreateEthnicOriginResponse,
                                                                                                            ICreateEthnicOrigin,
                                                                                                            NewEthnicOriginFixture
                                                                                                        > {}


        [TestClass]
        public class verify_on_update
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_update<   EthnicOrigin,
                                                                                                            UpdateEthnicOriginRequest,
                                                                                                            UpdateEthnicOriginResponse,
                                                                                                            IUpdateEthnicOrigin,
                                                                                                            UpdateEthnicOriginFixture
                                                                                                        > {}
    }
}