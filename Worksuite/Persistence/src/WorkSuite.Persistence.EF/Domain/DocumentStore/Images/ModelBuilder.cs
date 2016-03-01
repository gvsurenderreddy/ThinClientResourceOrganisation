using WTS.WorkSuite.Library.EntityFramework.Configuration;
using WTS.WorkSuite.Persistence.Domain.DocumentStore;

namespace WTS.WorkSuite.Persistence.EF.Domain.DocumentStore.Images
{
    public class ModelBuilder : ModelConfiguration<Image>
    {

        public ModelBuilder(string schema)
        {

            Map(m => m.ToTable("Image", schema));
        }
    }
}
