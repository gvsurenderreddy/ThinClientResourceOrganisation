using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.EthnicOrigins.Remove
{
    public class RemoveEthnicOrigin
                    :   RemoveReferenceData< EthnicOrigin, RemoveEthnicOriginRequest, RemoveEthnicOriginResponse >,
                        IRemoveEthnicOrigin
    {
        public RemoveEthnicOrigin(  IUnitOfWork the_unit_of_work,
                                    IEntityRepository< EthnicOrigin > the_title_repository
                                 )
                    :   base( the_unit_of_work, the_title_repository ) {}
    }
}