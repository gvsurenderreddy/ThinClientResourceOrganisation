using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.EthnicOrigins.Features.Edit
{
    public class UpdateEthnicOriginFixture
                        : UpdateRefereceDataFixture<EthnicOrigin,
                                                        UpdateEthnicOriginRequest,
                                                        UpdateEthnicOriginResponse,
                                                        IUpdateEthnicOrigin
                                                   >
    {
        public UpdateEthnicOriginFixture(IUpdateEthnicOrigin the_command,
                                            IRequestHelper<UpdateEthnicOriginRequest> the_request_builder,
                                            IEntityRepository<EthnicOrigin> the_repository
                                        )
            : base(the_command,
                    the_request_builder,
                    the_repository
                  ) { }
    }

}