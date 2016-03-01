using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.Remove
{
    public class RemoveMaritalStatus
                    :   RemoveReferenceData< MaritalStatus, RemoveMaritalStatusRequest, RemoveMaritalStatusResponse >,
                        IRemoveMaritalStatus
    {
        public RemoveMaritalStatus( IUnitOfWork the_unit_of_work,
                            IEntityRepository< MaritalStatus > the_skill_repository
                          )
                :   base(   the_unit_of_work,
                            the_skill_repository
                        ) {}
    }
}
