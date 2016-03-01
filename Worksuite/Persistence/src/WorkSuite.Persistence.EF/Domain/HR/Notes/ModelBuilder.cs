using WTS.WorkSuite.HR.HR;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.Notes
{
    public class ModelBuilder : ModelConfiguration<Note>
    {
        public ModelBuilder(string schema)
        {

            Map(m => m.ToTable("Note", schema));
        }
    }
}