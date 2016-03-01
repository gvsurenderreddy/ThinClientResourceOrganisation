using System.ComponentModel.DataAnnotations.Schema;
namespace WTS.WorkSuite.Persistence.EF.Domain.Allocation.OperationCalendars {
    using Library.EntityFramework.Configuration;


    public class ModelBuilder
                    : ModelConfiguration<WTS.WorkSuite.Allocation.OperationCalendars.AllocatedOperationCalendar> {

        public ModelBuilder
                ( string schema ) {

            Map( m => m.ToTable("OperationCalendar", schema));
            
            // primary keys are not generated as this is a copy of the actual operation calendar
            Property( m => m.id ).HasDatabaseGeneratedOption( DatabaseGeneratedOption.None );
        }
    }
}