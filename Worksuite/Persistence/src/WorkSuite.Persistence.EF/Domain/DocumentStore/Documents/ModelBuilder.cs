using WTS.WorkSuite.HR.DocumentStore;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.DocumentStore.Documents
{
    public class ModelBuilder : ModelConfiguration<Document>
    {

        public ModelBuilder(string schema)
        {

            Map(m => m.ToTable("Document", schema));
        }
    }
}
