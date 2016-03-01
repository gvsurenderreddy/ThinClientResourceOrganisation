using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.EmergencyContacts
{
    public class ModelBuilder : ModelConfiguration<EmergencyContact>
    {
        public ModelBuilder(string schema)
        {
            Map(m => m.ToTable("EmergencyContact", schema));
        }
    }
}