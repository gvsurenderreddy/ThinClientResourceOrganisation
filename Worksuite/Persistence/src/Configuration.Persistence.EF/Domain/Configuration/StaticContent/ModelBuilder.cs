using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace Configuration.Persistence.EF.Domain.Configuration.StaticContent
{
    public class ModelBuilder
             :ModelConfiguration < StaticContents > {
        
        public ModelBuilder
                ( string schema)
        {

            Map(m => m.ToTable ( "StaticContents", schema ));
        }
    }
}