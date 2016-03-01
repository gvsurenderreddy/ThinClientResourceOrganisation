using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New.Create;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.HR.ReferenceData.MaritalStatuses.New
{

    /// <summary>
    ///     Creates a new MaritalStatus entry, if the request is valid
    /// </summary>

    public class CreateMaritalStatus
                :   CreateReferenceData<MaritalStatus, CreateMaritalStatusRequest, CreateMaritalStatusResponse>,
                    ICreateMaritalStatus
    {
        public CreateMaritalStatus( IUnitOfWork the_unit_of_work,
                            Validator the_validator,
                            IEntityRepository<MaritalStatus> the_repository
                          )
                          : base(   the_unit_of_work,
                                    the_validator,
                                    the_repository
                                )
        {
        }
    }
}
