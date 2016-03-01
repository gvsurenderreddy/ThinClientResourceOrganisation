using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.New.Create;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.New
{
    /// <summary>
    ///     Creates a new location entry if the request is valid.
    /// </summary>
    public class CreateLocation
                    : CreateReferenceData<Location, CreateLocationRequest, CreateLocationResponse>,
                        ICreateLocation
    {
        public CreateLocation(IUnitOfWork the_unit_of_work,
                              Validator the_validator,
                              IEntityRepository<Location> the_repository
                             )
            : base(the_unit_of_work,
                   the_validator,
                   the_repository
                  ) { }
    }
}