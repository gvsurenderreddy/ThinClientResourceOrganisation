using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.Employees {

    public class ModelBuilder : ModelConfiguration<Employee>  {

        public ModelBuilder( string schema ) {

            Map(m => m.ToTable("Employee", schema ));

            // Set up cascading delete on Collection Navigation properties
            HasMany( m => m.Address )
                .WithRequired();

            HasMany(m => m.Note)
                .WithRequired();

            HasMany(m => m.EmergencyContacts)
                .WithRequired();

            HasMany(m => m.EmployeeDocuments)
                .WithRequired();

            HasMany(m => m.EmployeeSkills)
                .WithRequired();

            HasMany(m => m.EmployeeQualifications)
                .WithRequired();

            Property(u => u.dateofbirth).HasColumnType("datetime2");
        }

    }

}