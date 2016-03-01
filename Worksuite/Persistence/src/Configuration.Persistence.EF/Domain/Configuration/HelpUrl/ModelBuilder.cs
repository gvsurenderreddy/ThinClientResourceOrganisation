using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace Configuration.Persistence.EF.Domain.Configuration.HelpUrl
{
    public class ModelBuilder
                 :ModelConfiguration<HelpUrls>
    {
        public ModelBuilder
               ( string schema )
        {
            Map(m => m.ToTable("HelpUrls", schema));
        }
    }
}