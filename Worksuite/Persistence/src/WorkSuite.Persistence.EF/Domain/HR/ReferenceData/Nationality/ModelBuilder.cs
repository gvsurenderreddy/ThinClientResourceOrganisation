using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.ReferenceData.Nationality
{
    public class ModelBuilder
                    : ModelConfiguration< WorkSuite.HR.HR.ReferenceData.Nationality >
    {
        public ModelBuilder( string schema )
        {
            Map( m => m.ToTable( "Nationality", schema ) );
        }
    }
}