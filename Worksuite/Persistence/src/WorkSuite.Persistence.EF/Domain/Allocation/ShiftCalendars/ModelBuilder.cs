using WTS.WorkSuite.Allocation.OperationCalendars;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.Allocation.ShiftCalendars {

    /// <summary>
    ///     Allocation's ShiftCalendar persistence model defintion
    /// </summary>
    public class ModelBuilder 
                    : ModelConfiguration<AllocatedShiftCalendar> {
        
        public ModelBuilder
                ( string schema ) {

            Map( m => m.ToTable("ShiftCalendar", schema));
            
        }         
    }
}