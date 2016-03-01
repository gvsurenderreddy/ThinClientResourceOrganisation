using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Remove;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Locations.Remove
{
    public class RemoveLocation
                    : RemoveReferenceData<Location, RemoveLocationRequest, RemoveLocationResponse>,
                        IRemoveLocation
    {
        public RemoveLocation(IUnitOfWork the_unit_of_work,
                              IEntityRepository<Location> the_title_repository)
            : base(the_unit_of_work,
                   the_title_repository
                  ) { }
    }
}