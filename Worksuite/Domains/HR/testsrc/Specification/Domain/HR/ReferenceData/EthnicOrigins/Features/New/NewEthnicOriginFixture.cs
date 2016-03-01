using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.Create;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.New
{
    public class NewEthnicOriginFixture
                        : NewReferenceDataFixture<  EthnicOrigin,
                                                    CreateEthnicOriginRequest,
                                                    CreateEthnicOriginResponse,
                                                    ICreateEthnicOrigin
                                                 >
    {
        public NewEthnicOriginFixture(    ICreateEthnicOrigin the_command,
                                            IRequestHelper< CreateEthnicOriginRequest > the_request_builder,
                                            IEntityRepository< EthnicOrigin > the_repository
                                       )
                        : base( the_command,
                                the_request_builder,
                                the_repository
                              ) {}
    }
}