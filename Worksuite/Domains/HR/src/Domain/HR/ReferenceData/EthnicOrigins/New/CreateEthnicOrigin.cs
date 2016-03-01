using WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New.Create;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.New
{
    public class CreateEthnicOrigin
                            :   CreateReferenceData<  EthnicOrigin,
                                                      CreateEthnicOriginRequest,
                                                        CreateEthnicOriginResponse
                                                   >,
                                ICreateEthnicOrigin
    {
        public CreateEthnicOrigin(    IUnitOfWork the_unit_of_work,
                                        Validator the_validator,
                                        IEntityRepository< EthnicOrigin > the_repository
                                   )
                            :   base (  the_unit_of_work,
                                        the_validator,
                                        the_repository
                                     ) {}
    }
}