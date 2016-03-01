using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Fields.Description
{
    [TestClass]
    public class A_description_for_an_ethnic_origin_can_not_be_duplicated_is_validated_on_create
                        : A_description_can_not_be_duplicated_is_validated_on_create<   EthnicOrigin,
                                                                                        CreateEthnicOriginRequest,
                                                                                        CreateEthnicOriginResponse,
                                                                                        ICreateEthnicOrigin,
                                                                                        NewEthnicOriginFixture
                                                                                    > {}
}
